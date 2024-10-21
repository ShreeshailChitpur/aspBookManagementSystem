using BookManagementSys.Domain.Entities;

namespace BookManagementSys.Service.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBooksByIdAsync(int bookId);
        Task<int> CreateBookAsync(Book book);
        Task<int> UpdateBookAsync(Book book);
        Task<int> DeleteBookAsync(int bookId);
        Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId);
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId);
    }
}