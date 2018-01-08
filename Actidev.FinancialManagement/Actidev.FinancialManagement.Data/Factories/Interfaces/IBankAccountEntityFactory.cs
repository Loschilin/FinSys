using System;
using Actidev.FinancialManagement.Data.Entities;

namespace Actidev.FinancialManagement.Data.Factories.Interfaces
{
    public interface IBankAccountEntityFactory
    {
        BankAccount Create(Guid id, Guid companyId);
    }
}