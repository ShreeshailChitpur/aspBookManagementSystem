using Dapper;
using System.Data;
using BookManagementSys.Domain.Entities;
using BookManagementSys.Data.Interfaces;
using BookManagementSys.Common;

namespace BookManagementSys.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public CategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var query = $"SELECT * FROM Categories";
            return await _dbConnection.QueryAsync<Category>(query);
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var query = $"SELECT * FROM Categories WHERE CategoryID = @CategoryID";
            return await _dbConnection.QueryFirstOrDefaultAsync<Category>(query, new { CategoryID = categoryId });
        }

        public async Task<int> CreateCategoryAsync(Category category)
        {
            var query = $@"
                INSERT INTO Categories (CategoryName) 
                VALUES (@CategoryName)";
            return await _dbConnection.ExecuteAsync(query, category);
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            var query = $@"
                UPDATE Categories
                SET CategoryName = @CategoryName
                WHERE CategoryID = @CategoryID";
            return await _dbConnection.ExecuteAsync(query, category);
        }

        public async Task<int> DeleteCategoryAsync(int categoryId)
        {
            var query = $"DELETE FROM Categories WHERE CategoryID = @CategoryID";
            return await _dbConnection.ExecuteAsync(query, new { CategoryID = categoryId });
        }
    }
}
