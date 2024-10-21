using System.Runtime.Versioning;
using BookManagementSys.Domain.Entities;
using BookManagementSys.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

/*
Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int authorId);
        Task<int> CreateAuthorAsync(Author author);
        Task<int> UpdateAuthorAsync(Author author);
        Task<int> DeleteAuthorAsync(int authorId);*/

namespace BookManagementSys.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            var result = await _categoryService.CreateCategoryAsync(category);
            if(result > 0)
            {
                return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryID}, category);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if(id != category.CategoryID)
            {
                return BadRequest();
            }
            var result = await _categoryService.UpdateCategoryAsync(category);
            if( result > 0)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if(result > 0)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}