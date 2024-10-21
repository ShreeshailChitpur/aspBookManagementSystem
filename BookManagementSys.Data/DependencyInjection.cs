using BookManagementSys.Data.Repositories;
using BookManagementSys.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagementSys.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
