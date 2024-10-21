using Dapper;
using System.Data;
using BookManagementSys.Domain.Entities;
using BookManagementSys.Data.Interfaces;
using BookManagementSys.Common;

namespace BookManagementSys.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbConnection _dbConnection;

        public AuthorRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            var query = $"SELECT * FROM Authors";
            return await _dbConnection.QueryAsync<Author>(query);
        }

        public async Task<Author> GetAuthorByIdAsync(int authorId)
        {
            var query = $"SELECT * FROM Authors WHERE AuthorID = @AuthorID";
            return await _dbConnection.QueryFirstOrDefaultAsync<Author>(query, new { AuthorID = authorId });
        }

        public async Task<int> CreateAuthorAsync(Author author)
        {
            var query = $@"
                INSERT INTO Authors (Name, Biography) 
                VALUES (@Name, @Biography)";
            return await _dbConnection.ExecuteAsync(query, author);
        }

        public async Task<int> UpdateAuthorAsync(Author author)
        {
            var query = $@"
                UPDATE Authors
                SET Name = @Name, Biography = @Biography
                WHERE AuthorID = @AuthorID";
            return await _dbConnection.ExecuteAsync(query, author);
        }

        public async Task<int> DeleteAuthorAsync(int authorId)
        {
            var query = $"DELETE FROM Authors WHERE AuthorID = @AuthorID";
            return await _dbConnection.ExecuteAsync(query, new { AuthorID = authorId });
        }
    }
}
