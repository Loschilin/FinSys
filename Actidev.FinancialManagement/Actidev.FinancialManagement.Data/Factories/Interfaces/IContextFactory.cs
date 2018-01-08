using Microsoft.EntityFrameworkCore;

namespace Actidev.FinancialManagement.Data.Factories.Interfaces
{
    public interface IContextFactory<out TContext>
        where TContext : DbContext
    {
        TContext Create();
    }
}
