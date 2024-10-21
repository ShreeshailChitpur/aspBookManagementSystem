using Dapper;
using System.Data;
using BookManagementSys.Domain.Entities;
using BookManagementSys.Data.Interfaces;
using BookManagementSys.Common;

namespace BookManagementSys.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _dbConnection;

        public BookRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var query = $"SELECT * FROM {BookTableConfiguration.TableName}";
            return await _dbConnection.QueryAsync<Book>(query);
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            var query = $"SELECT * FROM {BookTableConfiguration.TableName} WHERE {BookTableConfiguration.BookID} = @BookID";
            return await _dbConnection.QueryFirstOrDefaultAsync<Book>(query, new { BookID = bookId });
        }

        public async Task<int> CreateBookAsync(Book book)
        {
            var query = $@"
                INSERT INTO {BookTableConfiguration.TableName} 
                ({BookTableConfiguration.Title}, {BookTableConfiguration.Description}, {BookTableConfiguration.PublishedYear}, {BookTableConfiguration.AuthorID}, {BookTableConfiguration.CategoryID})
                VALUES (@Title, @Description, @PublishedYear, @AuthorID, @CategoryID)";
            return await _dbConnection.ExecuteAsync(query, book);
        }

        public async Task<int> UpdateBookAsync(Book book)
        {
            var query = $@"
                UPDATE {BookTableConfiguration.TableName}
                SET {BookTableConfiguration.Title} = @Title, 
                    {BookTableConfiguration.Description} = @Description, 
                    {BookTableConfiguration.PublishedYear} = @PublishedYear, 
                    {BookTableConfiguration.AuthorID} = @AuthorID,
                    {BookTableConfiguration.CategoryID} = @CategoryID
                WHERE {BookTableConfiguration.BookID} = @BookID";
            return await _dbConnection.ExecuteAsync(query, book);
        }

        public async Task<int> DeleteBookAsync(int bookId)
        {
            var query = $"DELETE FROM {BookTableConfiguration.TableName} WHERE {BookTableConfiguration.BookID} = @BookID";
            return await _dbConnection.ExecuteAsync(query, new { BookID = bookId });
        }

        // New method: Get books by CategoryID
        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            var query = $"SELECT * FROM {BookTableConfiguration.TableName} WHERE {BookTableConfiguration.CategoryID} = @CategoryID";
            return await _dbConnection.QueryAsync<Book>(query, new { CategoryID = categoryId });
        }

        // New method: Get books by AuthorID
        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId)
        {
            var query = $"SELECT * FROM {BookTableConfiguration.TableName} WHERE {BookTableConfiguration.AuthorID} = @AuthorID";
            return await _dbConnection.QueryAsync<Book>(query, new { AuthorID = authorId });
        }
    }
}