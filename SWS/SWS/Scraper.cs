using HtmlAgilityPack;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWS
{

    class Scraper
    {
        public delegate void ScraperHandler(string message);
        public event ScraperHandler Notify;

        private ObservableCollection<EntryModel> _entries = new ObservableCollection<EntryModel>();

        public ObservableCollection<EntryModel> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }

        public void ScrapeData(string page)
        {
            HtmlWeb web = new HtmlWeb();
            var html = page;

            int number = 0;
            int pageCount = 0;

            Notify?.Invoke("Start parsing");

            for (int i = FormMain.PageStart; i < FormMain.PageEnd; i++)
            {
                pageCount++;
                var htmlDoc = web.Load(html + "/" + "?page=" + i);
                var posts = htmlDoc.DocumentNode.SelectNodes(".//div[@class='content-page categories-page']/div[@class='anime-column']"); // Берем все div внутри content-page categories-page, класс у которых = anime-column.

                Thread.Sleep(1000);

                try
                {
                    foreach (var post in posts) // Проходимся по всем аниме
                    {
                        number++;
                        var title = post.SelectSingleNode("./div[@class='anime-column-info']/a[@class='anime-title']")?.InnerText.Trim();
                        var type = post.SelectSingleNode("./div[@class='anime-column-info']/p")?.InnerText.Trim();
                        var view = post.SelectSingleNode("./div[@class='anime-column-info']/div[@class='icons-row']/div[@title='Количество просмотров']")?.InnerText.Trim().Replace(" ", "");
                        var vote = post.SelectSingleNode("./div[@class='anime-column-info']/div[@class='icons-row']/div[@title='Количество голосов']")?.InnerText.Trim().Replace(" ", "") ?? "Рейтинг недоступен";
                        var rating = post.SelectSingleNode("./div[@class='anime-column-info']/div[@class='rating-info']/span[@class='main-rating-block']/span[@class='main-rating']")?.InnerText.Trim() ?? "Рейтинг недоступен";
                        var release = post.SelectSingleNode("./a[@class='image-block']/span[@class='year-block']")?.InnerText.Trim() ?? post.SelectSingleNode("./a[@class='image-block']/div[@class='status-label']")?.InnerText.Trim();
                        var poster = post.SelectSingleNode("./a[@class='image-block']/img")?.GetAttributeValue("src", "").Trim();

                        _entries.Add(new EntryModel { Number = number, Title = title, Type = type, View = view, Vote = vote, Rating = rating, Release = release, Poster = page.Replace("/catalog", "") + poster, DateParse = DateTime.Now.ToShortDateString() });
                    }
                }
                catch (NullReferenceException exc)
                {
                    Notify?.Invoke("Err: " + exc.Message);
                }
                catch (System.Xml.XPath.XPathException exc)
                {
                    Notify?.Invoke("Err: " + exc.Message);
                }
                finally
                {
                    if (posts == null)
                    {
                        Notify?.Invoke($"Page {pageCount} was not loaded.");
                    }
                    else
                    {
                        Notify?.Invoke($"Page {pageCount} done!");
                    }
                }
            }

            if (_entries.Count() == 0)
            {
                Notify?.Invoke("Parsing failed!");
            }
            else
            {
                Notify?.Invoke("Parsing complited.");
            }
        }
    }
}
