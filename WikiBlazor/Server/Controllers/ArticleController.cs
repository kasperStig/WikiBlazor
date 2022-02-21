using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiBlazor.Server.Data;
using WikiBlazor.Shared.DTOs;
using WikiBlazor.Shared.Models;
using Wikipedia;

namespace WikiBlazor.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ArticleController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await GetArticlesFromDatabase();
            return Ok(articles);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetArticle(long id)
        {
            var article = await GetArticleById(id);
            if (article == null)
            {
                return NotFound("No article found with the given Id");
            }
            return Ok(article);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateArticle([FromBody] ArticleCategoryUpdateDTO articleCategoryUpdateDto)
        {
            var dbArticle = await GetArticleById(articleCategoryUpdateDto.ArticleId);
            if (dbArticle == null)
            {
                return NotFound("No article found for the given id");
            }

            var dbCategories = await GetCategoriesFromDatabase();
            var newCategoriesForArticle = dbCategories.Where(c => articleCategoryUpdateDto.CategoryIds.Contains(c.Id));
            dbArticle.Categories.Clear();
            dbArticle.Categories.AddRange(newCategoriesForArticle);
            await _dataContext.SaveChangesAsync();

            var articles = await GetArticlesFromDatabase();
            return Ok(articles);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateArticles([FromBody] ArticleCreationDTO creationDto)
        {
            var wikipediaArticles = await WikipediaAdapter.GetWikipediaArticles(creationDto.NumberOfArticlesToCreate);
            var articlesToInsert = wikipediaArticles.Select(w => new Article {Title = w.Title, Url = w.Url});
            _dataContext.Articles.AddRange(articlesToInsert);
            await _dataContext.SaveChangesAsync();
            var articlesFromDb = await GetArticlesFromDatabase();
            return Ok(articlesFromDb);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete()
        {
            _dataContext.Articles.RemoveRange(_dataContext.Articles);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

        private async Task<List<Article>> GetArticlesFromDatabase()
        {
            return await _dataContext.Articles.Include(a => a.Categories).ToListAsync();
        }

        private async Task<List<Category>> GetCategoriesFromDatabase()
        {
            return await _dataContext.Categories.Include(c => c.Articles).ToListAsync();
        }

        private async Task<Article> GetArticleById(long id)
        {
            return await _dataContext.Articles.Include(a => a.Categories).FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}