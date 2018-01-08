using System;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Factories
{
    internal class ArticleFactory : IArticleFactory
    {
        public Article Create(Guid id, Guid? userId, string name, bool isReadonly)
        {
            var atticle = new Article
            {
                Id = id,
                Name = name,
                Readonly = isReadonly,
                UserId = userId
            };

            return atticle;
        }

        public Article Create(Guid id, Guid? userId,  Guid? parentId, string name, bool isReadonly)
        {
            Article article;

            if (!parentId.HasValue)
            {
                article = Create(id, userId, name, isReadonly);
            }
            else
            {
                article = new ChildArticle
                {
                    Id = id,
                    UserId = userId,
                    ArticleId = parentId.Value,
                    Name = name,
                    Readonly = isReadonly
                };
            }

            return article;
        }
    }
}
