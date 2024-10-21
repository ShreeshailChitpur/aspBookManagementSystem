using BookManagementSys.Domain.Entities;

namespace BookManagementSys.Service.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int authorId);
        Task<int> CreateAuthorAsync(Author author);
        Task<int> UpdateAuthorAsync(Author author);
        Task<int> DeleteAuthorAsync(int authorId);
    }
}