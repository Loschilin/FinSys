using System;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Factories
{
    internal class ContractorFactory : IContractorFactory
    {
        public Contractor Create(Guid id, Guid userId)
        {
            return new Contractor
            {
                Id = id,
                UserId = userId
            };
        }
    }
}