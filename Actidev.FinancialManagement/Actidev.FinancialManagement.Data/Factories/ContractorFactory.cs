using System;
using Actidev.FinancialManagement.Data.Entities;
using Actidev.FinancialManagement.Data.Factories.Interfaces;

namespace Actidev.FinancialManagement.Data.Factories
{
    internal class ContractorFactory: IContractorEntityFactry
    {
        public Contractor Create(Guid id, Guid userId, string name)
        {
            var result = new Contractor
            {
                Id = id,
                UserId = userId,
                Name = name
            };

            return result;
        }
    }
}