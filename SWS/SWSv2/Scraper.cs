using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWSv2
{
    class Scraper
    {
        private ObservableCollection<EntryModel> _entries = new ObservableCollection<EntryModel>();

        public ObservableCollection<EntryModel> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }

        public async Task GetContent(HttpClient httpClient)
        {
            try
            {
                int counter = 0;
                int pointStart = 1;
                int pointEnd = 3;
                int sleep = 2000;

                for (int i = pointStart; i < pointEnd; i++)
                {
                    Thread.Sleep(sleep);

                    HttpResponseMessage response = await httpClient.GetAsync("https://yummyanime.club/catalog?page=" + i);
                    response.EnsureSuccessStatusCode(); // Высвобождает ресурсы если соеденение не удалось
                    var html = await response.Content.ReadAsStringAsync();

                    var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                    htmlDoc.LoadHtml(html);

                    var posts = htmlDoc.DocumentNode.SelectNodes(".//div[@class='content-page categories-page']/div[@class='anime-column']"); // в переменную post парсим аниме из каталога
                    try
                    {
                        // Циклом проходимся по всем аниме
                        foreach (var post in posts)
                        {
                            counter++;

                            var hrefitem = post.SelectSingleNode("./a[@class='image-block']")?.GetAttributes("href"); // вытягиваем ссылки на страницу с аниме

                            Thread.Sleep(sleep);
                            response = await httpClient.GetAsync("https://yummyanime.club" + hrefitem.ElementAt(0).Value); // получаем ссылку на item анимешки
                            response.EnsureSuccessStatusCode(); // Высвобождает ресурсы если соеденение не удалось
                            var htmlinfo = await response.Content.ReadAsStringAsync();
                            var item = new HtmlAgilityPack.HtmlDocument();
                            item.LoadHtml(htmlinfo);


                            var titlelists = item.DocumentNode.SelectNodes(".//ul[@class='alt-names-list']/li"); // находим альтернативные названия
                            var infolists = item.DocumentNode.SelectNodes(".//div/div[@class='content-page anime-page']/ul[@class='content-main-info']/li"); // находим просмотры,статус,сезон,возростной рейтинг,жанр,первоисточник,студия,режиссер,тип,серия,перевод,озвучка

                            var title = item.DocumentNode.SelectSingleNode("//h1")?.InnerText.Trim(); // находим название 
                            var rating = item.DocumentNode.SelectSingleNode("//span[@class='main-rating']")?.InnerText.Trim() ?? "Рейтинг недоступен"; // находим рейтинг 
                            var vote = item.DocumentNode.SelectSingleNode("//span[@class='main-rating-info']")?.InnerText.Trim().Replace("(", string.Empty).Replace(")", string.Empty).Replace("голосов", string.Empty) ?? "Рейтинг недоступен"; // находим количество голосов
                            var urlimage = item.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/div[1]/div[1]/img")?.GetAttributeValue("src", "").Trim(); // находим ссылку на постер
                            var description = item.DocumentNode.SelectSingleNode(".//div[@class='content-desc']/div[@id='content-desc-text']/p")?.InnerText.Trim(); // находим описание
                            var license = item.DocumentNode.SelectSingleNode(".//div[@id='video']/div[@class='status-bg alert-bg']/text()")?.InnerText.Trim() ?? "Не лицензировано"; // находим инфу о локализаторе в рф

                            List<string> temptitle = new List<string>();
                            List<string> tempgenre = new List<string>();
                            List<string> tempstudio = new List<string>();
                            List<string> temptransfer = new List<string>();



                            foreach (var titlelist in titlelists)
                            {
                                if (titlelist != null)
                                {
                                    temptitle.Add(titlelist.InnerText);
                                    temptitle.Remove("...");
                                }
                            }
                            _entries.Add(new EntryModel() { titleList = new List<string>(temptitle) });

                            foreach (var infolist in infolists)
                            {
                                var tempinfolist = infolist.InnerText.Trim().Replace("\r\n", string.Empty);
                                var selection = tempinfolist.Substring(0, tempinfolist.IndexOf(":") + 1);

                                switch (selection)
                                {
                                    case "Просмотров:":
                                        string view = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Replace(" ", string.Empty);
                                        break;
                                    case "Статус:":
                                        string status = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Год:":
                                        string released = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Сезон:":
                                        string season = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Возрастной рейтинг:":
                                        string ageRating = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Жанр:":
                                        string[] genre = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                        for (int j = 0; j < genre.Count(); j++)
                                        {
                                            tempgenre.Add(genre[j]);
                                        }
                                        break;
                                    case "Первоисточник:":
                                        string primarySourse = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Студия:":
                                        string studio = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Режиссер:":
                                        string producer = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Тип:":
                                        string type = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Серии:":
                                        string series = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Перевод:":
                                        string[] transfer = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                        for (int j = 0; j < transfer.Count(); j++)
                                        {
                                            temptransfer.Add(transfer[j]);
                                        }
                                        break;
                                    case "Озвучка:":
                                        string voiceActing = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim().Replace("amp;", string.Empty);
                                        break;
                                    default:
                                        MessageBox.Show("Что то пошло не так!", "Exception Caught!",
                                                   MessageBoxButtons.OK,
                                                   MessageBoxIcon.Warning,
                                                   MessageBoxDefaultButton.Button1,
                                                   MessageBoxOptions.DefaultDesktopOnly);
                                        break;
                                }
                            }

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
                        //FormMain fm = new FormMain();
                        //fm.SetDataViewGrid(_entries);
                    }
                    catch (NullReferenceException exc)
                    {
                        MessageBox.Show($"{exc.Message}", "Null Reference Exception!",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning,
                                   MessageBoxDefaultButton.Button1,
                                   MessageBoxOptions.DefaultDesktopOnly);
                    }
                    catch (System.Xml.XPath.XPathException exc)
                    {
                        MessageBox.Show($"{exc.Message}", "XPath Exception!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.DefaultDesktopOnly);
                    }
                    finally
                    {
                        MessageBox.Show($"{_entries.ToList()}", "Success!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            }
            catch (HttpRequestException exc)
            {
                MessageBox.Show($"{exc.Message}", "Http Request Exception!",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.DefaultDesktopOnly);
            }
            FormMain fm = new FormMain();
            fm.SetDataViewGrid(_entries);
        }
    }
}