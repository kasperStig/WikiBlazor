using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiBlazor.Server.Data;
using WikiBlazor.Shared.DTOs;
using WikiBlazor.Shared.Models;

namespace WikiBlazor.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CategoryController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await GetCategoriesFromDatabase();
            return Ok(categories);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreationDTO creationDto)
        {
            var category = new Category
            {
                Name = creationDto.Name
            };
            _dataContext.Categories.Add(category);
            await _dataContext.SaveChangesAsync();
            var categories = await GetCategoriesFromDatabase();
            return Ok(categories);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete()
        {
            _dataContext.Categories.RemoveRange(_dataContext.Categories);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

        private async Task<List<Category>> GetCategoriesFromDatabase()
        {
            return await _dataContext.Categories.ToListAsync();
        }
    }
}