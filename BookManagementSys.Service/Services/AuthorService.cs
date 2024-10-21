using BookManagementSys.Data.Interfaces;
using BookManagementSys.Domain.Entities;
using BookManagementSys.Service.Interfaces;

/*
Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int authorId);
        Task<int> CreateAuthorAsync(Author author);
        Task<int> UpdateAuthorAsync(Author author);
        Task<int> DeleteAuthorAsync(int authorId);
*/

namespace BookManagementSys.Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAuthorsAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int authorId)
        {
            return await _authorRepository.GetAuthorByIdAsync(authorId);
        }

        public async Task<int> CreateAuthorAsync(Author author)
        {
            return await _authorRepository.CreateAuthorAsync(author);
        }

        public async Task<int> UpdateAuthorAsync(Author author)
        {
            return await _authorRepository.UpdateAuthorAsync(author);
        }

        public async Task<int> DeleteAuthorAsync(int authorId)
        {   
            return await _authorRepository.DeleteAuthorAsync(authorId);

        }
    }
}