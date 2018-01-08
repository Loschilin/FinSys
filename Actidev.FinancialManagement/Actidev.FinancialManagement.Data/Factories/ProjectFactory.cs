using System;
using Actidev.FinancialManagement.Data.Entities;
using Actidev.FinancialManagement.Data.Factories.Interfaces;

namespace Actidev.FinancialManagement.Data.Factories
{
    internal class ProjectFactory : IProjectEntityFactory
    {
        public Project Create(Guid id, Guid userId, string name)
        {
            var result = new Project
            {
                Id = id,
                UserId = userId,
                Name = name
            };

            return result;
        }
    }
}