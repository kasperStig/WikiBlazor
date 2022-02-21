using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WikiBlazor.Shared.DTOs;
using WikiBlazor.Shared.Models;

namespace WikiBlazor.Client.Services.WikiService
{
    public class WikiService : IWikiService
    {
        public List<Article> Articles { get; } = new List<Article>();
        public List<Category> Categories { get; } = new List<Category>();

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public WikiService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task PopulateCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("/api/v1/category/getAll");
            if (result != null)
            {
                Categories.Clear();
                Categories.AddRange(result);
            }
        }

        public async Task CreateCategory(Category category)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/v1/category/create", new CategoryCreationDTO { Name = category.Name });
            var response = await result.Content.ReadFromJsonAsync<List<Category>>();
            if (response != null)
            {
                Categories.Clear();
                Categories.AddRange(response);
                _navigationManager.NavigateTo("categories");
            }
        }

        public async Task PopulateArticles()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Article>>("/api/v1/article/getAll");
            if (result != null)
            {
                Articles.Clear();
                Articles.AddRange(result);
            }
        }

        public async Task<Article> GetArticle(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<Article>($"/api/v1/article/get?id={id}");
            if (result != null)
            {
                return result;
            }
            throw new ArgumentException("No article found for the given argument.", nameof(id));
        }

        public async Task CreateArticles()
        {
            var result = await _httpClient.PostAsJsonAsync("/api/v1/article/create", new ArticleCreationDTO { NumberOfArticlesToCreate = 10});
            var response = await result.Content.ReadFromJsonAsync<List<Article>>();
            if (response != null)
            {
                Articles.Clear();
                Articles.AddRange(response);
                _navigationManager.NavigateTo("articles");
            }
        }

        public async Task UpdateArticleCategoryRelation(List<long> categoryIds, long articleId)
        {
            var requestDto = new ArticleCategoryUpdateDTO {ArticleId = articleId, CategoryIds = categoryIds};
            var result = await _httpClient.PutAsJsonAsync("/api/v1/article/update", requestDto);
            var response = await result.Content.ReadFromJsonAsync<List<Article>>();
            if (response != null)
            {
                Articles.Clear();
                Articles.AddRange(response);
                _navigationManager.NavigateTo("articles");
            }
        }

        public async Task Clear()
        {
            await _httpClient.DeleteAsync("/api/v1/category/delete");
            await _httpClient.DeleteAsync("/api/v1/article/delete");
            Categories.Clear();
            Articles.Clear();
            _navigationManager.NavigateTo("articles");
        }
    }
}