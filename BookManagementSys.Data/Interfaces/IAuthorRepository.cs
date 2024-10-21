using BookManagementSys.Domain.Entities;

namespace BookManagementSys.Data.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int authorId);
        Task<int> CreateAuthorAsync(Author author);
        Task<int> UpdateAuthorAsync(Author author);
        Task<int> DeleteAuthorAsync(int authorId);
    }
}