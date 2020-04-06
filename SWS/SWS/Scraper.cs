using HtmlAgilityPack;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWS
{

    class Scraper
    {
        Form1 fm1 = new Form1();
        Form2 fm2 = new Form2();

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

            int PointStart = 0;
            int PointEnd = 161;

            int number = 0;
            for (int i = PointStart; i < PointEnd; i++)
            {
                var htmlDoc = web.Load(html + "/" + "?page=" + i);
                var posts = htmlDoc.DocumentNode.SelectNodes(".//div[@class='content-page categories-page']/div[@class='anime-column']"); // Берем все div внутри content-page categories-page, класс у которых = anime-column.

                try
                {
                    foreach (var post in posts) // Проходимся по всем аниме
                    {
                        number++;
                        var title = post.SelectSingleNode("./div[@class='anime-column-info']/a[@class='anime-title']")?.InnerText;
                        var type = post.SelectSingleNode("./div[@class='anime-column-info']/p")?.InnerText;
                        var view = post.SelectSingleNode("./div[@class='anime-column-info']/div[@class='icons-row']/div[@title='Количество просмотров']")?.InnerText;
                        var vote = post.SelectSingleNode("./div[@class='anime-column-info']/div[@class='icons-row']/div[@title='Количество голосов']")?.InnerText ?? "Рейтинг недоступен";
                        var rating = post.SelectSingleNode("./div[@class='anime-column-info']/div[@class='rating-info']/span[@class='main-rating-block']/span[@class='main-rating']")?.InnerText ?? "Рейтинг недоступен";
                        var release = post.SelectSingleNode("./a[@class='image-block']/span[@class='year-block']")?.InnerText ?? post.SelectSingleNode("./a[@class='image-block']/div[@class='status-label']")?.InnerText;
                        var poster = post.SelectSingleNode("./a[@class='image-block']/img")?.GetAttributeValue("src", "");

                        _entries.Add(new EntryModel { Number = number, Title = title, Type = type, View = view, Vote = vote, Rating = rating, Release = release, Poster = page.Replace("/catalog", "") + poster });                  
                    }
                }
                catch (Exception exc)
                {
                    Notify?.Invoke("SelectSingleNode not found!");
                }
            }
        }
    }
}
