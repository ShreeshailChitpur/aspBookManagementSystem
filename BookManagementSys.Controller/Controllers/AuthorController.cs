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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if( author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] Author author)
        {
            var result = await _authorService.CreateAuthorAsync(author);
            if(result > 0)
            {
                return CreatedAtAction(nameof(GetAuthorById), new { id = author.AuthorID}, author);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            if(id != author.AuthorID)
            {
                return BadRequest();
            }
            var result = await _authorService.UpdateAuthorAsync(author);
            if( result > 0)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _authorService.DeleteAuthorAsync(id);
            if(result > 0)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}