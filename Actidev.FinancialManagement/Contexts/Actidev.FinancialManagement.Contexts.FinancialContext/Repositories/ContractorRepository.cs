using System;
using System.Collections.Generic;
using System.Linq;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;
using Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces;
using Actidev.FinancialManagement.Data.Factories.Interfaces;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Repositories
{
    internal class ContractorRepository : IContractorRepository
    {
        private readonly IContextFactory<Data.Contexts.FinancialContext> _contextFactory;
        private readonly IContractorFactory _contractorFactory;
        private readonly IContractorEntityFactry _entityFactry;

        public ContractorRepository(
            IContextFactory<Data.Contexts.FinancialContext> contextFactory,
            IContractorFactory contractorFactory,
            IContractorEntityFactry entityFactry)
        {
            _contextFactory = contextFactory;
            _contractorFactory = contractorFactory;
            _entityFactry = entityFactry;
        }

        public Contractor GetById(Guid id)
        {
            using (var context = _contextFactory.Create())
            {
                var entity = context.Contractors.FirstOrDefault(e => e.Id == id);

                if (entity == null)
                {
                    return null;
                }

                var result = CreateContractor(entity);
                return result;
            }
        }

        private Contractor CreateContractor(Data.Entities.Contractor entity)
        {
            var result = _contractorFactory.Create(entity.Id, entity.UserId);
            result.Account = entity.Account;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Comment = entity.Comment;
            result.Description = entity.Description;
            result.Email = entity.Email;
            result.FullName = entity.FullName;
            result.Index = entity.Index;
            result.Inn = entity.Inn;
            result.Kpp = entity.Kpp;
            result.Phone = entity.Phone;
            result.SiteUrl = entity.SiteUrl;
            result.Name = entity.Name;
            return result;
        }

        public IEnumerable<Contractor> GetAll()
        {
            using (var context = _contextFactory.Create())
            {
                return context.Contractors.Select(CreateContractor).ToArray();
            }
        }

        public void Save(Contractor contractor)
        {
            using (var context = _contextFactory.Create())
            {
                var entity = context.Contractors.FirstOrDefault(e => e.Id == contractor.Id);

                if (entity == null)
                {
                    entity = _entityFactry.Create(
                        contractor.Id, 
                        contractor.UserId, 
                        contractor.Name);

                    context.Contractors.Add(entity);
                }

                entity.Account = contractor.Account;
                entity.Address = contractor.Address;
                entity.City = contractor.City;
                entity.Comment = contractor.Comment;
                entity.Description = contractor.Description;
                entity.Email = contractor.Email;
                entity.FullName = contractor.FullName;
                entity.Index = contractor.Index;
                entity.Inn = contractor.Inn;
                entity.Kpp = contractor.Kpp;
                entity.Phone = contractor.Phone;
                entity.SiteUrl = contractor.SiteUrl;
                entity.Name = contractor.Name;

                context.SaveChanges();
            }
        }

        public void Delete(Contractor contractor)
        {
            using (var context = _contextFactory.Create())
            {
                var entity = context.Contractors.FirstOrDefault(e => e.Id == contractor.Id);
                context.Contractors.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}