using System;
using Actidev.FinancialManagement.Data.Entities;
using Actidev.FinancialManagement.Data.Factories.Interfaces;

namespace Actidev.FinancialManagement.Data.Factories
{
    internal class ArticleFactory : IArticleEntityFactory
    {
        public Article Create(Guid id, Guid? userId, string name)
        {
            var result = new Article
            {
                Id = id,
                UserId = userId,
                Name = name
            };

            return result;
        }
    }
}
