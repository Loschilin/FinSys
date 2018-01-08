using System;
using System.Collections.Generic;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Project GetById(Guid id);
        IEnumerable<Project> GetAll();
        void Save(Project project);
        void Delete(Project project);
    }
}