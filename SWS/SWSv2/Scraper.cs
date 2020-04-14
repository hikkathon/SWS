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

                for (int i = pointStart; i < pointEnd; i++)
                {
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
                            
                            foreach (var titlelist in titlelists)
                            {
                                _entries.Add(new EntryModel() {});
                            }

                            foreach (var infolist in infolists)
                            {
                                var temp = infolist.InnerText.Trim().Replace("\r\n", string.Empty);
                                var selection = temp.Substring(0, temp.IndexOf(":") + 1);

                                switch (selection)
                                {
                                    case "Просмотров:":
                                        // TODO:
                                        break;
                                    case "Статус:":
                                        // TODO:
                                        break;
                                    case "Год:":
                                        // TODO:
                                        break;
                                    case "Сезон:":
                                        // TODO:
                                        break;
                                    case "Возрастной рейтинг:":
                                        // TODO:
                                        break;
                                    case "Жанр:":
                                        // TODO:
                                        break;
                                    case "Первоисточник:":
                                        // TODO:
                                        break;
                                    case "Студия:":
                                        // TODO:
                                        break;
                                    case "Режиссер:":
                                        // TODO:
                                        break;
                                    case "Тип:":
                                        // TODO:
                                        break;
                                    case "Серии:":
                                        // TODO:
                                        break;
                                    case "Перевод:":
                                        // TODO:
                                        break;
                                    case "Озвучка:":
                                        // TODO:
                                        break;
                                    default:
                                        // TODO:
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
                }
                FormMain fm = new FormMain();
                fm.GetDataViewGrid(_entries);
            }
            catch (HttpRequestException exc)
            {
                MessageBox.Show($"{exc.Message}", "Http Request Exception!",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}