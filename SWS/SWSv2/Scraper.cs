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

                            var _titlelist = item.DocumentNode.SelectNodes(".//ul[@class='alt-names-list']/li"); // находим альтернативные названия
                            var _info = item.DocumentNode.SelectNodes(".//div/div[@class='content-page anime-page']/ul[@class='content-main-info']/li"); // находим просмотры,статус,сезон,возростной рейтинг,жанр,первоисточник,студия,режиссер,тип,серия,перевод,озвучка

                            var title = item.DocumentNode.SelectSingleNode("//h1")?.InnerText.Trim(); // находим название 
                            var rating = item.DocumentNode.SelectSingleNode("//span[@class='main-rating']")?.InnerText.Trim() ?? "Рейтинг недоступен"; // находим рейтинг 
                            var vote = item.DocumentNode.SelectSingleNode("//span[@class='main-rating-info']")?.InnerText.Trim().Replace("(",string.Empty).Replace(")",string.Empty).Replace("голосов",string.Empty) ?? "Рейтинг недоступен"; // находим количество голосов
                            var urlimage = item.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/div[1]/div[1]/img")?.GetAttributeValue("src", "").Trim(); // находим ссылку на постер
                            var description = item.DocumentNode.SelectSingleNode(".//div[@class='content-desc']/div[@id='content-desc-text']/p")?.InnerText.Trim(); // находим описание
                            var license = item.DocumentNode.SelectSingleNode(".//div[@id='video']/div[@class='status-bg alert-bg']/text()")?.InnerText.Trim() ?? "Не лицензировано"; // находим инфу о локализаторе в рф

                            switch (selection)
                            {
                                case "Просмотров:":
                                    //TODO:
                                    break;
                                case "Статус:":
                                    //TODO:
                                    break;
                                case "Год:":
                                    //TODO:
                                    break;
                                case "Сезон:":
                                    //TODO:
                                    break;
                                case "Возрастной рейтинг:":
                                    //TODO:
                                    break;
                                case "Жанр:":
                                    //TODO:
                                    break;
                                case "Первоисточник:":
                                    //TODO:
                                    break;
                                case "Студия:":
                                    //TODO:
                                    break;
                                case "Режиссер:":
                                    //TODO:
                                    break;
                                case "Тип:":
                                    //TODO:
                                    break;
                                case "Серии:":
                                    //TODO:
                                    break;
                                case "Перевод:":
                                    //TODO:
                                    break;
                                case "Озвучка:":
                                    //TODO:
                                    break;
                                default:
                                    Console.WriteLine("Вы нажали неизвестную букву");
                                    break;
                            }

                            var view = _info.ElementAt(0).SelectSingleNode("text()")?.InnerText.Replace(" ", string.Empty);

                            if (_info.ElementAt(1).SelectSingleNode("span[@class='badge']/text()") == null)
                            {
                                var status = _info.ElementAt(1).SelectSingleNode("span[@class='badge attention']/text()")?.InnerText.Replace(" ", string.Empty);
                            }
                            else
                            {
                                var status = _info.ElementAt(1).SelectSingleNode("span[@class='badge']/text()")?.InnerText.Replace(" ", string.Empty);
                            }

                            var released = _info.ElementAt(2).SelectSingleNode("text()")?.InnerText.Replace(" ", string.Empty);
                            var season = _info.ElementAt(3).SelectSingleNode("text()")?.InnerText.Replace(" ", string.Empty);
                            var ageRating = _info.ElementAt(4).SelectSingleNode("text()")?.InnerText.Replace(" ", string.Empty);
                            var genre = _info.ElementAt(5).SelectSingleNode("text()")?.InnerText.Replace(" ", string.Empty);

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
