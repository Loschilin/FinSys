using System;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces
{
    public interface IContractorFactory
    {
        Contractor Create(Guid id, Guid userId);
    }
}