using System;
using System.Collections.Generic;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces
{
    public interface IContractorRepository
    {
        Contractor GetById(Guid id);
        IEnumerable<Contractor> GetAll();
        void Save(Contractor contractor);
        void Delete(Contractor contractor);
    }
}