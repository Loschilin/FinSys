using Microsoft.Extensions.DependencyInjection;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;
using Actidev.FinancialManagement.Contexts.FinancialContext.Repositories;
using Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Configuration
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddFinancialContext(this IServiceCollection services)
        {
            return services
                .AddRepositories()
                .AddFactories();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddSingleton<IBankAccountRepository, BankAccountRepository>()
                .AddSingleton<ICompanyRepository, CompanyRepository>()
                .AddSingleton<IContractorRepository, ContractorRepository>()
                .AddSingleton<IProjectRepository, ProjectRepository>()
                .AddSingleton<IArticleRepository, ArticleRepository>();
            return services;
        }

        private static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services
                .AddSingleton<IBankAccountFactory, BankAccountFactory>()
                .AddSingleton<ICompanyFactory, CompanyFactory>()
                .AddSingleton<IContractorFactory, ContractorFactory>()
                .AddSingleton<IProjectFactory, ProjectFactory>()
                .AddSingleton<IArticleFactory, ArticleFactory>();

            return services;
        }
    }
}
