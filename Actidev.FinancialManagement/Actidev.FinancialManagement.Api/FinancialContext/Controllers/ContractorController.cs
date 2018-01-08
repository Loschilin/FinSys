using System;
using System.Collections.Generic;
using System.Linq;
using Actidev.FinancialManagement.Api.FinancialContext.Extentions;
using Actidev.FinancialManagement.Api.FinancialContext.Models;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;
using Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Actidev.FinancialManagement.Api.FinancialContext.Controllers
{
    [Produces("application/json")]
    [Route("api/contractors")]
    public class ContractorController : Controller
    {
        private readonly IContractorRepository _repository;
        private readonly IContractorFactory _factory;

        public ContractorController(
                IContractorRepository repository,
                IContractorFactory factory
            )
        {
            _repository = repository;
            _factory = factory;
        }

        [Route("{id}"), HttpGet]
        public ContractorModel GetById(Guid id)
        {
            var contractor = _repository.GetById(id);
            return contractor?.GetModel();
        }

        [Route(""), HttpGet]
        public IEnumerable<ContractorModel> GetContractors()
        {
            return _repository.GetAll().Select(e => e.GetModel());
        }

        [Route(""), HttpPost]
        public Guid Create([FromBody]ContractorModel model)
        {
            model.Id = Guid.NewGuid();
            var contractor = _factory.Create(model.Id, Const.UserId);
            contractor.CopyModelFields(model);
            _repository.Save(contractor);
            return model.Id;
        }

        [Route("{id}"), HttpPut]
        public Guid Update(Guid id, [FromBody]ContractorModel model)
        {
            model.Id = id;
            var contractor = _repository.GetById(id);

            if (contractor == null)
            {
                return Guid.Empty;
            }

            contractor.CopyModelFields(model);
            _repository.Save(contractor);
            return contractor.Id;
        }

        [Route("{id}"), HttpDelete]
        public void Delete(Guid id)
        {
            var contractor = _repository.GetById(id);
            if (contractor == null)
            {
                return;
            }

            _repository.Delete(contractor);
        }
    }
}