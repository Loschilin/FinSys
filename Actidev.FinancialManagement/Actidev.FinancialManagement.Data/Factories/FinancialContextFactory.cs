using Actidev.FinancialManagement.Data.Contexts;
using Actidev.FinancialManagement.Data.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Actidev.FinancialManagement.Data.Factories
{
    internal class FinancialContextFactory: IContextFactory<FinancialContext>
    {
        private readonly DbContextOptions<FinancialContext> _dbContextOptions;

        public FinancialContextFactory(DbContextOptions<FinancialContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public FinancialContext Create()
        {
            return new FinancialContext(_dbContextOptions);
        }
        
    }
}