using System;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Factories
{
    internal class CompanyFactory : ICompanyFactory
    {
        public Company Create(Guid id, Guid userId, string name)
        {
            return new Company
            {
                Id = id,
                UserId = userId,
                Name = name
            };
        }
    }
}