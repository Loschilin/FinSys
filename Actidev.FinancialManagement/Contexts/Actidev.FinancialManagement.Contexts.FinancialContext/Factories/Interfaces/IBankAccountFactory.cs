using System;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces
{
    public interface IBankAccountFactory
    {
        BankAccount Create(Guid id, Guid companyId);
    }
}
