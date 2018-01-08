using System;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Factories
{
    internal class BankAccountFactory : IBankAccountFactory
    {
        public BankAccount Create(Guid id, Guid companyId)
        {
            return new BankAccount
            {
                Id = id,
                CompanyId = companyId
            };
        }
    }
}
