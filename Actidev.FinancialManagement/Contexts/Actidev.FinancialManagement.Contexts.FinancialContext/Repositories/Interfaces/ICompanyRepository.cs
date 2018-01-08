using System;
using System.Collections.Generic;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Company GetById(Guid id);
        IEnumerable<Company> GetAll();
        void Save(Company company);
        void Delete(Company company);
    }
}
