namespace Wikipedia
{
    public class WikipediaArticle : IWikipediaArticle
    {
        public string Title { get; }
        public string Url { get; }

        public WikipediaArticle(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}