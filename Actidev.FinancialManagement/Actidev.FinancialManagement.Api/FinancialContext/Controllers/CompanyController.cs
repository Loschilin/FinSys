using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Actidev.FinancialManagement.Api.FinancialContext.Extentions;
using Actidev.FinancialManagement.Api.FinancialContext.Models;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;
using Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Actidev.FinancialManagement.Api.FinancialContext.Controllers
{
    [Produces("application/json")]
    [Route("api/companies")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _repository;
        private readonly ICompanyFactory _factory;

        public CompanyController(
            ICompanyRepository repository,
            ICompanyFactory factory
            )
        {
            _repository = repository;
            _factory = factory;
        }

        [Route("{id}"), HttpGet]
        public CompanyModel GetById(Guid id)
        {
            var entity = _repository.GetById(id);

            var model = entity?.GetModel();
            return model;
        }

        [Route(""), HttpGet]
        public IEnumerable<CompanyModel> GetCompanies()
        {
            return _repository.GetAll().Select(e => e.GetModel());
        }

        [Route(""), HttpPost]
        public Guid Create([FromBody]CompanyModel model)
        {
            model.Id = Guid.NewGuid();
            var company = _factory.Create(model.Id, Const.UserId, model.Name);
            company.CopyModelFields(model);
            _repository.Save(company);
            return model.Id;
        }

        [Route("{id}"), HttpPut]
        public Guid Update(Guid id, [FromBody]CompanyModel model)
        {
            model.Id = id;
            var company = _repository.GetById(id);
            if (company == null)
            {
                return Guid.Empty;
            }

            company.CopyModelFields(model);
            _repository.Save(company);
            return company.Id;
        }

        [Route("{id}"), HttpDelete]
        public void Delete(Guid id)
        {
            var company = _repository.GetById(id);

            if (company == null)
            {
                return;
            }

            _repository.Delete(company);
        }
    }
}