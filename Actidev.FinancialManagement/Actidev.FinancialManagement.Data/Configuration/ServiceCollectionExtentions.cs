using System;
using Actidev.FinancialManagement.Data.Contexts;
using Actidev.FinancialManagement.Data.Factories;
using Actidev.FinancialManagement.Data.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Actidev.FinancialManagement.Data.Configuration
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddFinancialData(this IServiceCollection services,
            Action<FinancialManagmentDataOptions> configure)
        {
            var options = new FinancialManagmentDataOptions();
            configure(options);
            
            var contextOptions = new DbContextOptionsBuilder<FinancialContext>();
            contextOptions.UseSqlServer(options.ConnectionString);

            services.AddDbContext<FinancialContext>();

            return services
                .AddSingleton(contextOptions.Options)
                .AddSingleton(options)
                .AddFactories();
        }

        private static IServiceCollection AddFactories(this IServiceCollection services)
        {
            return services
                .AddSingleton<IArticleEntityFactory, ArticleFactory>()
                .AddSingleton<IBankAccountEntityFactory, BankAccountFactory>()
                .AddSingleton<ICompanyEntityFactory, CompanyFactory>()
                .AddSingleton<IContractorEntityFactry, ContractorFactory>()
                .AddSingleton<IProjectEntityFactory, ProjectFactory>()
                .AddSingleton<IContextFactory<FinancialContext>, FinancialContextFactory>();
        }
    }
}
