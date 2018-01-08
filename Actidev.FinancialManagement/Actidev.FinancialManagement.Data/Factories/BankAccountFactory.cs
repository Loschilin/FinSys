using System;
using Actidev.FinancialManagement.Data.Entities;
using Actidev.FinancialManagement.Data.Factories.Interfaces;

namespace Actidev.FinancialManagement.Data.Factories
{
    internal class BankAccountFactory : IBankAccountEntityFactory
    {
        public BankAccount Create(Guid id, Guid companyId)
        {
            var result = new BankAccount
            {
                Id = id,
                CompanyId = companyId
            };

            return result;
        }
    }
}