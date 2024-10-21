using BookManagementSys.Service.Interfaces;
using BookManagementSys.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagementSys.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<ICategoryService, CategoryService>();

            return services;
        }
    }
}