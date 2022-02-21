using System.Collections.Generic;
using System.Threading.Tasks;
using WikiBlazor.Shared.Models;

namespace WikiBlazor.Client.Services.WikiService
{
    public interface IWikiService
    {
        List<Article> Articles { get; }
        List<Category> Categories { get; }

        Task PopulateArticles();
        Task PopulateCategories();
        Task<Article> GetArticle(long id);
        Task CreateCategory(Category category);
        Task UpdateArticleCategoryRelation(List<long> categoryIds, long articleId);
        Task CreateArticles();
        Task Clear();
    }
}