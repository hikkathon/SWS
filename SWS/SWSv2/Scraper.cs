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
                HttpResponseMessage response = await httpClient.GetAsync("https://yummyanime.club/catalog");
                response.EnsureSuccessStatusCode(); // Высвобождает ресурсы если соеденение не удалось
                var html = await response.Content.ReadAsStringAsync();

                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(html);

                int counter = 0;
                try
                {
                    var posts = htmlDoc.DocumentNode.SelectNodes(".//div[@class='content-page categories-page']/div[@class='anime-column']");

                    foreach (var post in posts)
                    {
                        counter++;
                        var number = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var title = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var rating = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var vote = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var titleList = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var view = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var status = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var released = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var season = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var ageRating = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var genre = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var primarySourse = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var studio = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var producer = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var type = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var series = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var transfer = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var voiceActing = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var description = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var urlImage = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();
                        var licende = post.SelectSingleNode("")?.GetAttributeValue("src", "").Trim();

                        _entries.Add(new EntryModel
                        {
                            Number = counter,
                            Title = title,
                            Rating = rating,
                            Vote = vote,
                            titleList = titleList,
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
                            Transfer = transfer,
                            voiceActing = voiceActing,
                            Description = description,
                            urlImage = "https://yummyanime.club" + urlImage,
                            License = licende
                        });
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
