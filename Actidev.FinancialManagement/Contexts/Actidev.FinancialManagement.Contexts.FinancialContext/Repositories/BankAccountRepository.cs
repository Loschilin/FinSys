using System;
using System.Collections.Generic;
using System.Linq;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;
using Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces;
using Actidev.FinancialManagement.Data.Factories.Interfaces;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Repositories
{
    internal class BankAccountRepository : IBankAccountRepository
    {
        private readonly IBankAccountFactory _factory;
        private readonly IContextFactory<Data.Contexts.FinancialContext> _dbContextFactory;
        private readonly IBankAccountEntityFactory _entityFactory;

        public BankAccountRepository(IBankAccountFactory factory,
            IContextFactory<Data.Contexts.FinancialContext> dbContextFactory,
            IBankAccountEntityFactory entityFactory)
        {
            _factory = factory;
            _dbContextFactory = dbContextFactory;
            _entityFactory = entityFactory;
        }

        public BankAccount GetById(Guid id)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbAccount = context.BankAccounts.FirstOrDefault(e => e.Id == id);

                return dbAccount == null 
                    ? null 
                    : CreateBankAccount(dbAccount);
            }
        }

        private BankAccount CreateBankAccount(Data.Entities.BankAccount dbAccount)
        {
            var account = _factory.Create(dbAccount.Id, dbAccount.CompanyId);
            account.Account = dbAccount.Account;
            account.BankName = dbAccount.BankName;
            account.Bik = dbAccount.Bik;
            account.CompanyName = dbAccount.CompanyName;
            account.InitialBalance = dbAccount.InitialBalance;
            account.InitialBalanceDate = dbAccount.InitialBalanceDate;
            
            return account;
        }

        public IEnumerable<BankAccount> GetCompanyAccounts(Guid companydId)
        {
            using (var context = _dbContextFactory.Create())
            {
                return context.BankAccounts.Where(e => e.CompanyId == companydId).AsEnumerable()
                    .Select(CreateBankAccount).ToArray();
            }
        }

        public void Save(BankAccount account)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbAccount = context.BankAccounts
                    .FirstOrDefault(e=>e.Id == account.Id && e.CompanyId == account.CompanyId);

                if (dbAccount == null)
                {
                    dbAccount = _entityFactory.Create(account.Id, account.CompanyId);
                    context.BankAccounts.Add(dbAccount);
                }

                dbAccount.Account = account.Account;
                dbAccount.BankName = account.BankName;
                dbAccount.Bik = account.Bik;
                dbAccount.CompanyName = account.CompanyName;
                dbAccount.InitialBalance = account.InitialBalance;
                dbAccount.InitialBalanceDate = account.InitialBalanceDate;

                context.SaveChanges();
            }
        }

        public void Delete(BankAccount account)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbAccount = context.BankAccounts
                    .FirstOrDefault(e=> e.Id == account.Id && e.CompanyId == account.CompanyId);

                if (dbAccount == null)
                {
                    return;
                }

                context.BankAccounts.Remove(dbAccount);
                context.SaveChanges();
            }
        }
    }
}
