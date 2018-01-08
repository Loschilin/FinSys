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
    [Route("api/companies/{companyId}/bank-accounts")]
    public class BankAccountController : Controller
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IBankAccountFactory _factory;

        public BankAccountController(
            IBankAccountRepository bankAccountRepository,
            IBankAccountFactory factory
            )
        {
            _bankAccountRepository = bankAccountRepository;
            _factory = factory;
        }

        [Route("{id}"), HttpGet]
        public BankAccountModel GetById(Guid id)
        {
            var bankAccount = _bankAccountRepository.GetById(id);
            var model = bankAccount?.GetModel();
            return model;
        }

        [Route(""), HttpPost]
        public Guid Create(Guid companyId, [FromBody]BankAccountModel model)
        {
            model.Id = Guid.NewGuid();
            var bankAccount = _factory.Create(model.Id, companyId);
            bankAccount.CopyModelFields(model);
            _bankAccountRepository.Save(bankAccount);
            return bankAccount.Id;
        }

        [Route("{id}"), HttpPut]
        public Guid Update(Guid id, [FromBody]BankAccountModel model)
        {
            model.Id = id;
            var bankAccount = _bankAccountRepository.GetById(id);

            if (bankAccount == null)
            {
                return Guid.Empty;
            }

            bankAccount.CopyModelFields(model);
            _bankAccountRepository.Save(bankAccount);
            return bankAccount.Id;
        }

        [Route(""), HttpGet]
        public IEnumerable<BankAccountModel> GetCollection(Guid companyId)
        {
            return _bankAccountRepository.GetCompanyAccounts(companyId)
                .Select(e => e.GetModel());
        }

        [Route("{id}"), HttpDelete]
        public void Delete(Guid id)
        {
            var entity = _bankAccountRepository.GetById(id);
            if (entity == null)
            {
                return;
            }
            _bankAccountRepository.Delete(entity);
        }
    }
}