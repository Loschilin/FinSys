using System;
using System.Collections.Generic;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces
{
    public interface IBankAccountRepository
    {
        BankAccount GetById(Guid id);
        IEnumerable<BankAccount> GetCompanyAccounts(Guid companydId);
        void Save(BankAccount account);
        void Delete(BankAccount account);
    }
}