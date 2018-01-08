using System;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Factories
{
    internal class ProjectFactory: IProjectFactory
    {
        public Project Create(Guid id, Guid userId)
        {
            return new Project
            {
                Id = id,
                UserId = userId
            };
        }
    }
}