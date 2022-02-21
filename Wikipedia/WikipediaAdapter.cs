using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Wikipedia
{
    public class WikipediaAdapter
    {
        private const string WikipediaUrlPrefix = "https://en.wikipedia.org/wiki/";
        public static async Task<List<IWikipediaArticle>> GetWikipediaArticles(int count)
        {
            var articles = new List<IWikipediaArticle>();
            for (var i = 0; i < count; i++)
            {
                var requestUrl = $"{WikipediaUrlPrefix}Special:Random";
                var request = WebRequest.Create(requestUrl);
                var response = await request.GetResponseAsync();
                var articleTitle = WebUtility.UrlDecode(response.ResponseUri.AbsoluteUri.Substring(WikipediaUrlPrefix.Length)).Replace("_", " ");
                var articleUrl = response.ResponseUri.AbsoluteUri;
                var article = new WikipediaArticle(articleTitle, articleUrl);
                articles.Add(article);
            }

            return articles;
        }
    }
}
