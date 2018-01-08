using System;
using Actidev.FinancialManagement.Api.FinancialContext.Models;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;

namespace Actidev.FinancialManagement.Api.FinancialContext.Extentions
{
    public static class EntitiesExtentions
    {
        public static ArticleModel GetModel(this Article article)
        {
            var model = new ArticleModel
            {
                Id = article.Id,
                Name = article.Name,
                Readonly = article.Readonly
            };

            if (article is ChildArticle child)
            {
                model.ParentId = child.ArticleId;
            }

            return model;
        }

        public static void CopyModelFields(this Article article, ArticleModel model)
        {
            article.Id = model.Id;
            article.Name = model.Name;
        }

        public static ProjectModel GetModel(this Project project)
        {
            return new ProjectModel
            {
                Id = project.Id,
                Description = project.Description,
                Name = project.Name
            };
        }

        public static void CopyModelFields(this Project project, ProjectModel model)
        {
            project.Id = model.Id;
            project.Description = model.Description;
            project.Name = model.Name;
        }

        public static ContractorModel GetModel(this Contractor contractor)
        {
            var model = new ContractorModel
            {
                Account = contractor.Account,
                Address = contractor.Address,
                City = contractor.City,
                Comment = contractor.Comment,
                Description = contractor.Description,
                Email = contractor.Email,
                FullName = contractor.FullName,
                Name = contractor.Name,
                Id = contractor.Id,
                Index = contractor.Index,
                Inn = contractor.Inn,
                Kpp = contractor.Kpp,
                Phone = contractor.Phone,
                SiteUrl = contractor.SiteUrl
            };
            return model;
        }

        public static void CopyModelFields(this Contractor contractor, ContractorModel model)
        {
            contractor.Account = model.Account;
            contractor.Address = model.Address;
            contractor.City = model.City;
            contractor.Comment = model.Comment;
            contractor.Description = model.Description;
            contractor.Email = model.Email;
            contractor.FullName = model.FullName;
            contractor.Name = model.Name;
            contractor.Id = model.Id;
            contractor.Index = model.Index;
            contractor.Inn = model.Inn;
            contractor.Kpp = model.Kpp;
            contractor.Phone = model.Phone;
            contractor.SiteUrl = model.SiteUrl;
        }

        public static CompanyModel GetModel(this Company company)
        {
            var result = new CompanyModel
            {
                Address = company.Address,
                GeneralManager = company.GeneralManager,
                Id = company.Id,
                Inn = company.Inn,
                Kpp = company.Kpp,
                Name = company.Name,
                Phone = company.Phone
            };
            return result;
        }

        public static void CopyModelFields(this Company company, CompanyModel model)
        {
            company.Id = model.Id;
            company.Address = model.Address;
            company.GeneralManager = model.GeneralManager;
            company.Inn = model.Inn;
            company.Kpp = model.Kpp;
            company.Name = model.Name;
            company.Phone = model.Phone;
        }

        public static BankAccountModel GetModel(this BankAccount bankAccount)
        {
            var model = new BankAccountModel
            {
                Id = bankAccount.Id,
                CompanyName = bankAccount.CompanyName,
                BankName = bankAccount.BankName,
                InitialBalance = bankAccount.InitialBalance,
                InitialBalanceDate = bankAccount.InitialBalanceDate,
                Bik = bankAccount.Bik,
                Account = bankAccount.Account
            };

            return model;
        }

        public static void CopyModelFields(this BankAccount bankAccount, BankAccountModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            bankAccount.Id = model.Id;
            bankAccount.Account = model.Account;
            bankAccount.BankName = model.BankName;
            bankAccount.Bik = model.Bik;
            bankAccount.CompanyName = model.CompanyName;
            bankAccount.InitialBalance = model.InitialBalance;
            bankAccount.InitialBalanceDate = model.InitialBalanceDate;
        }
    }
}