using System;
using Actidev.FinancialManagement.Data.Entities;

namespace Actidev.FinancialManagement.Data.Factories.Interfaces
{
    public interface IContractorEntityFactry
    {
        Contractor Create(Guid id, Guid useerId, string name);
    }
}