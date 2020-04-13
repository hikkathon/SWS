using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWSv2
{
    class Scraper
    {
        private ObservableCollection<EntryModel> _entries = new ObservableCollection<EntryModel>();

        //Form1 fm1 = new Form1();
        public ObservableCollection<EntryModel> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }

        public async Task GetContent(HttpClient httpClient)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://yummyanime.club/catalog");
                response.EnsureSuccessStatusCode(); // Высвобождает ресурсы если соеденение не удалось
                var html = await response.Content.ReadAsStringAsync();

                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(html);

                int counter = 0;
                try
                {
                    var posts = htmlDoc.DocumentNode.SelectNodes(".//div[@class='content-page categories-page']/div[@class='anime-column']"); // в переменную post парсим аниме из каталога

                    for (int i = 0; i < htmlDoc.DocumentNode.SelectNodes(".//div[@class='content-page categories-page']/div[@class='anime-column']").Count(); i++)
                    {
                        // Циклом проходимся по всем аниме
                        foreach (var post in posts)
                        {
                            counter++;

                            var hrefitem = post.SelectSingleNode("./a[@class='image-block']")?.GetAttributes("href"); // вытягиваем ссылки на страницу с аниме

                            var web = new HtmlWeb();
                            var item = web.Load("https://yummyanime.club" + hrefitem.ElementAt(0).Value);

                            var title = item.DocumentNode.SelectSingleNode("//h1")?.InnerText.Trim();
                            var rating = item.DocumentNode.SelectSingleNode("//span[@class='main-rating']")?.InnerText.Trim() ?? "Рейтинг недоступен";
                            var vote = item.DocumentNode.SelectSingleNode("//span[@class='main-rating-info']")?.InnerText.Trim() ?? "Рейтинг недоступен";
                            var titlelist = item.DocumentNode.SelectNodes(".//ul[@class='alt-names-list']/li");
                            var urlimage = item.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/div[1]/div[1]/img")?.GetAttributeValue("src", "").Trim();
                            var content_main_info = item.DocumentNode.SelectNodes(".//div/div[@class='content-page anime-page']/ul[@class='content-main-info']/li");
                            var description = item.DocumentNode.SelectSingleNode(".//div[@class='content-desc']/div[@id='content-desc-text']/p")?.InnerText.Trim();
                            var license = item.DocumentNode.SelectSingleNode(".//div[@id='video']/div[@class='status-bg alert-bg']/text()")?.InnerText.Trim() ?? "Не лицензировано";

                            List<string> temp = new List<string>();
                            string[] @enum = { "Просмотров:", "Статус:", "Год:", "Сезон:", "Возрастной рейтинг:", "Жанр:", "Первоисточник:","Студия:", "Режиссер:", "Тип:", "Серии:", "Перевод:","Озвучка:" };
                            foreach (var cmi in content_main_info)
                            {
                                temp.Add(cmi.InnerText.Replace("\r\n", string.Empty).Trim());
                            }

                            #region вытягиваем инфу об анимках
                            //var title = htmlitem.DocumentNode.SelectSingleNode("//h1")?.InnerText.Trim();
                            //var rating = htmlitem.DocumentNode.SelectSingleNode("//span[@class='main-rating']")?.InnerText.Trim() ?? "Рейтинг недоступен";
                            //var vote = htmlitem.DocumentNode.SelectSingleNode("//span[@class='main-rating-info']")?.InnerText.Trim() ?? "Рейтинг недоступен";

                            //var titleList = htmlitem.DocumentNode.SelectNodes(".//ul[@class='alt-names-list']/li");

                            //var view = htmlitem.DocumentNode.SelectSingleNode(".//ul[@class='content-main-info']/li[1]/text()")?.InnerText.Trim().Replace(" ", "") ?? "Нет просмотров";
                            //var status = htmlitem.DocumentNode.SelectSingleNode(".//html/body/div[3]/div[3]/div/div/ul[2]/li[2]/span[2]")?.InnerText.Trim();
                            //var released = htmlitem.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/ul[2]/li[3]/text()")?.InnerText.Trim();
                            //var season = htmlitem.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/ul[2]/li[4]/text()")?.InnerText.Trim();
                            //var ageRating = htmlitem.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/ul[2]/li[5]/text()")?.InnerText.Trim() ?? "Не установлен";

                            //var genre = htmlitem.DocumentNode.SelectNodes(".//ul[@class='categories-list']/li[6]/ul");

                            //var primarySourse = htmlitem.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/ul[2]/li[7]/text()")?.InnerText.Trim();
                            //var studio = htmlitem.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/ul[2]/li[8]/ul/li/a")?.InnerText.Trim();
                            //var producer = htmlitem.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/ul[2]/li[9]/a")?.InnerText.Trim();
                            //var type = htmlitem.DocumentNode.SelectSingleNode("//*[@id='animeType']/text()")?.InnerText.Trim();
                            //var series = htmlitem.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/ul[2]/li[11]/text()")?.InnerText.Trim();

                            //var transfer = htmlitem.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div/div/ul[2]/li[12]/ul/li/text()");

                            //var voiceActing = htmlitem.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/ul[2]/li[13]/ul/li/text()");

                            //var description = htmlitem.DocumentNode.SelectSingleNode("//*[@id='content - desc - text']/p/text()")?.InnerText.Trim();

                            //var urlImage = htmlitem.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/div[1]/div[1]/img")?.GetAttributeValue("src", "").Trim();
                            //var licende = htmlitem.DocumentNode.SelectSingleNode(".//div[@id='video']/div[@class='status-bg alert-bg']/text()")?.InnerText.Trim();
                            #endregion

                            //_entries.Add(new EntryModel
                            //{
                            //    Number = counter,
                            //    Title = title,
                            //    Rating = rating,
                            //    Vote = vote,
                            //    titleList = titleList,
                            //    View = view,
                            //    Status = status,
                            //    Released = released,
                            //    Season = season,
                            //    ageRating = ageRating,
                            //    Genre = genre,
                            //    primarySource = primarySourse,
                            //    Studio = studio,
                            //    Producer = producer,
                            //    Type = type,
                            //    Series = series,
                            //    Transfer = transfer,
                            //    voiceActing = voiceActing,
                            //    Description = description,
                            //    urlImage = "https://yummyanime.club" + urlImage,
                            //    License = license
                            //});
                        }
                    }
                }
                catch (NullReferenceException exc)
                {
                    MessageBox.Show($"{exc.Message}", "Exception Caught!",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning,
                               MessageBoxDefaultButton.Button1,
                               MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (System.Xml.XPath.XPathException exc)
                {
                    MessageBox.Show($"{exc.Message}", "Exception Caught!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            catch (HttpRequestException exc)
            {
                MessageBox.Show($"{exc.Message}", "Exception Caught!",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
