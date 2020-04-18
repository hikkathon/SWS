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

        public void Alert(string title, string message, FormAlert.enmType type)
        {
            FormAlert frm = new FormAlert();
            frm.showAlert(title, message, type);
        }

        public async Task GetContent(HttpClient httpClient)
        {
            RemoveSpaces rs = new RemoveSpaces();

            try
            {
                int counter = 0;
                int pointStart = 1;
                int pointEnd = 3;
                int CounterSleep = 0;

                for (int i = pointStart; i <= pointEnd; i++)
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
                            CounterSleep++;

                            var hrefitem = post.SelectSingleNode("./a[@class='image-block']")?.GetAttributes("href"); // вытягиваем ссылки на страницу с аниме

                            response = await httpClient.GetAsync("https://yummyanime.club" + hrefitem.ElementAt(0).Value); // получаем ссылку на item анимешки
                            string responceStatus = response.StatusCode.ToString();

                            if(responceStatus == "NotFound")
                            {
                                continue;
                            }

                            response.EnsureSuccessStatusCode(); // Высвобождает ресурсы если соеденение не удалось
                            var htmlinfo = await response.Content.ReadAsStringAsync();
                            var item = new HtmlAgilityPack.HtmlDocument();
                            item.LoadHtml(htmlinfo);
                            
                            var alternativeTitle = item.DocumentNode.SelectNodes(".//ul[@class='alt-names-list']/li"); // находим альтернативные названия TODO: в некоторых аниме нет алт. названия и вылетает NullReferenceException

                            var infolists = item.DocumentNode.SelectNodes(".//div/div[@class='content-page anime-page']/ul[@class='content-main-info']/li"); // находим просмотры,статус,сезон,возростной рейтинг,жанр,первоисточник,студия,режиссер,тип,серия,перевод,озвучка

                            var title = item.DocumentNode.SelectSingleNode("//h1")?.InnerText.Trim(); // находим название 
                            var rating = item.DocumentNode.SelectSingleNode("//span[@class='main-rating']")?.InnerText.Trim() ?? "Рейтинг недоступен"; // находим рейтинг 
                            var vote = item.DocumentNode.SelectSingleNode("//span[@class='main-rating-info']")?.InnerText.Trim().Replace("(", string.Empty).Replace(")", string.Empty).Replace("голосов", string.Empty) ?? "Рейтинг недоступен"; // находим количество голосов
                            var urlimage = item.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div/div/div[1]/div[1]/img")?.GetAttributeValue("src", "").Trim(); // находим ссылку на постер
                            var description = item.DocumentNode.SelectSingleNode(".//div[@class='content-desc']/div[@id='content-desc-text']/p")?.InnerText.Trim(); // находим описание
                            var license = item.DocumentNode.SelectSingleNode(".//div[@id='video']/div[@class='status-bg alert-bg']/text()")?.InnerText.Trim() ?? "Не лицензировано"; // находим инфу о локализаторе в рф

                            string view = "нет данных";
                            string status = "нет данных";
                            string released = "нет данных";
                            string season = "нет данных";
                            string ageRating = "нет данных";
                            string genre = "нет данных";
                            string primarySourse = "нет данных";
                            string studio = "нет данных";
                            string producer = "нет данных";
                            string type = "нет данных";
                            string series = "нет данных";
                            string transfer = "нет данных";
                            string voiceActing = "нет данных";
                            string aTitle = "нет данных";

                            List<string> temptitle = new List<string>();

                            if(alternativeTitle == null)
                            {

                            }
                            else
                            {
                                foreach (var titlelist in alternativeTitle)
                                {
                                    if (titlelist != null)
                                    {
                                        temptitle.Add(titlelist.InnerText);
                                        temptitle.Remove("...");
                                        aTitle = String.Join(" | ", temptitle.ToArray());
                                    }
                                }
                            }

                            foreach (var infolist in infolists)
                            {
                                var tempinfolist = infolist.InnerText.Trim().Replace("\r\n", string.Empty);
                                var selection = tempinfolist.Substring(0, tempinfolist.IndexOf(":") + 1);

                                switch (selection)
                                {
                                    case "Просмотров:":
                                         view = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Replace(" ", string.Empty);
                                        break;
                                    case "Статус:":
                                         status = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Год:":
                                         released = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Сезон:":
                                         season = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Возрастной рейтинг:":
                                         ageRating = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Жанр:":
                                        //genre = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        genre = rs.Remove(tempinfolist, " ").Substring(tempinfolist.IndexOf(":") + 1);
                                        break;
                                    case "Первоисточник:":
                                         primarySourse = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Студия:":
                                         studio = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Режиссер:":
                                         producer = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Тип:":
                                         type = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Серии:":
                                         series = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        break;
                                    case "Перевод:":
                                        //transfer = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim();
                                        //transfer = string.Join(", ", transfer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                                        transfer = rs.Remove(tempinfolist, " ").Substring(tempinfolist.IndexOf(":") + 1);
                                        break;
                                    case "Озвучка:":
                                         voiceActing = tempinfolist.Substring(tempinfolist.IndexOf(":") + 1).Trim().Replace("amp;", string.Empty);
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
                            //_entries.Add(new EntryModel() { titleList = new List<string>(temptitle) });

                            _entries.Add(new EntryModel
                            {
                                Number = counter,
                                Title = title,
                                Rating = rating,
                                Vote = vote,
                                alternativeTitle = aTitle,
                                View = view,
                                Status = status,
                                Released = released,
                                Season = season,
                                ageRating = ageRating,
                                Genre = genre,
                                primarySource = primarySourse,
                                Studio = studio,
                                Producer = producer,
                                Type = type,
                                Series = series,
                                transfer = transfer,
                                voiceActing = voiceActing,
                                Description = description,
                                urlImage = "https://yummyanime.club" + urlimage,
                                License = license
                            });
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
                    finally
                    {
                        response.EnsureSuccessStatusCode();
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

            MessageBox.Show("Готово", "Success!",
           MessageBoxButtons.OK,
           MessageBoxIcon.Warning,
           MessageBoxDefaultButton.Button1,
           MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}