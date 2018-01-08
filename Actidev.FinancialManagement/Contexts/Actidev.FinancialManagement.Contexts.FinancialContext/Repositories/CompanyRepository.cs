using System;
using System.Collections.Generic;
using System.Linq;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;
using Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces;
using Actidev.FinancialManagement.Data.Factories.Interfaces;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Repositories
{
    internal  class CompanyRepository : ICompanyRepository
    {
        private readonly IContextFactory<Data.Contexts.FinancialContext> _contextFactory;
        private readonly ICompanyFactory _companyFactory;
        private readonly ICompanyEntityFactory _entityFactory;

        public CompanyRepository(
            IContextFactory<Data.Contexts.FinancialContext> contextFactory,
            ICompanyFactory companyFactory,
            ICompanyEntityFactory entityFactory)
        {
            _contextFactory = contextFactory;
            _companyFactory = companyFactory;
            _entityFactory = entityFactory;
        }

        public Company GetById(Guid id)
        {
            using (var context = _contextFactory.Create())
            {
                var dbEntity = context.Companies.FirstOrDefault(e => e.Id == id);
                if (dbEntity == null)
                {
                    return null;
                }

                var company = CreateCompany(dbEntity);
                return company;
            }
        }

        private Company CreateCompany(Data.Entities.Company dbEntity)
        {
            var result = _companyFactory.Create(dbEntity.Id, dbEntity.UserId, dbEntity.Name);
            result.Address = dbEntity.Address;
            result.GeneralManager = dbEntity.GeneralManager;
            result.Inn = dbEntity.Inn;
            result.Kpp = dbEntity.Kpp;
            result.Phone = dbEntity.Phone;
            return result;
        }

        public IEnumerable<Company> GetAll()
        {
            using (var context = _contextFactory.Create())
            {
                return context.Companies.Select(CreateCompany).ToArray();
            }
        }

        public void Save(Company company)
        {
            using (var context = _contextFactory.Create())
            {
                var dbEntity = context.Companies.FirstOrDefault(e => e.Id == company.Id);
                if (dbEntity == null)
                {
                    dbEntity = _entityFactory.Create(company.Id, company.UserId, company.Name);
                    context.Companies.Add(dbEntity);
                }

                dbEntity.Address = company.Address;
                dbEntity.GeneralManager = company.GeneralManager;
                dbEntity.Inn = company.Inn;
                dbEntity.Kpp = company.Kpp;
                dbEntity.Phone = company.Phone;
                dbEntity.Name = company.Name;

                context.SaveChanges();
            }
        }

        public void Delete(Company company)
        {
            using (var context = _contextFactory.Create())
            {
                var entity = context.Companies.FirstOrDefault(e => e.Id == company.Id);
                if (entity == null)
                {
                    return;
                }

                context.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}