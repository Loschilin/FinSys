using System;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces
{
    public interface ICompanyFactory
    {
        Company Create(Guid id, Guid userId, string name);
    }
}