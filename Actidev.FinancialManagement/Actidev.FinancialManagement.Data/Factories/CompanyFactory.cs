using System;
using Actidev.FinancialManagement.Data.Entities;
using Actidev.FinancialManagement.Data.Factories.Interfaces;

namespace Actidev.FinancialManagement.Data.Factories
{
    internal class CompanyFactory : ICompanyEntityFactory
    {
        public Company Create(Guid id, Guid userId, string name)
        {
            var result = new Company
            {
                Id = id,
                UserId = userId,
                Name = name
            };

            return result;
        }
    }
}