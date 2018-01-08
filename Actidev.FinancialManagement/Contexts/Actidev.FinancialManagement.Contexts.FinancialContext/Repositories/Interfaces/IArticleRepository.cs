using System;
using System.Collections.Generic;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        Article GetById(Guid id);
        IEnumerable<Article> GetArticles(Guid userId);
        void Save(Article article);
        void Delete(Article article);
    }
}
