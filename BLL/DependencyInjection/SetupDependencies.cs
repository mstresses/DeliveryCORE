using BLL.Services;
using BLL.Services.CategoriaDeProdutoService;
using BLL.Services.FornecedorService;
using DAO.Repositories.CategoriaDeProdutoRepository;
using DAO.Repositories.FornecedorRepository;
using DTO.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.DependencyInjection
{
    public static class SetupDependencies
    {
        public static void SetupServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();
        }

        public static void SetupRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<ICategoriaDeProdutoRepository, CategoriaDeProdutoRepository>();
        }
    }
}