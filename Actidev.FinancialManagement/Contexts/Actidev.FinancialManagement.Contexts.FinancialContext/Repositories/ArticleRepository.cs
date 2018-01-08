using System;
using System.Collections.Generic;
using System.Linq;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;
using Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces;
using Actidev.FinancialManagement.Data.Factories.Interfaces;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Repositories
{
    internal class ArticleRepository : IArticleRepository
    {
        private readonly IArticleFactory _articleFactory;
        private readonly IArticleEntityFactory _entityFactory;
        private readonly IContextFactory<Data.Contexts.FinancialContext> _contextFactory;

        public ArticleRepository(
            IArticleFactory articleFactory,
            IArticleEntityFactory entityFactory,
            IContextFactory<Data.Contexts.FinancialContext> contextFactory
            )
        {
            _articleFactory = articleFactory;
            _entityFactory = entityFactory;
            _contextFactory = contextFactory;
        }

        public Article GetById(Guid id)
        {
            using (var context = _contextFactory.Create())
            {
                var entity = context.Articles.FirstOrDefault(e => e.Id == id);
                return CreateArticle(entity);
            }
        }

        private Article CreateArticle(Data.Entities.Article entity)
        {
            var article = _articleFactory.Create(entity.Id,
                entity.UserId,
                entity.ParentId,
                entity.Name,
                !entity.UserId.HasValue);
            return article;
        }

        public IEnumerable<Article> GetArticles(Guid userId)
        {
            using (var context = _contextFactory.Create())
            {
                return context.Articles
                    .Where(e => e.UserId == userId || !e.UserId.HasValue)
                    .AsEnumerable()
                    .Select(CreateArticle)
                    .ToArray();
            }
        }

        public void Save(Article article)
        {
            using (var context = _contextFactory.Create())
            {
                var entity = context.Articles.FirstOrDefault(e => e.Id == article.Id);

                if (entity == null)
                {
                    entity = CreateEntityFromSource(article);
                    context.Articles.Add(entity);
                }
                else
                {
                    CopyArticleFields(article, entity);
                }
                
                context.SaveChanges();
            }
        }

        private static void CopyArticleFields(
            Article source, 
            Data.Entities.Article destination)
        {
            destination.Name = source.Name;
        }

        private Data.Entities.Article CreateEntityFromSource(Article article)
        {
            var entity = _entityFactory.Create(article.Id, article.UserId, article.Name);

            if (article is ChildArticle child)
            {
                entity.ParentId = child.ArticleId;
            }

            CopyArticleFields(article, entity);
            return entity;
        }


        public void Delete(Article article)
        {
            using (var context = _contextFactory.Create())
            {
                var entity = context.Articles.FirstOrDefault(e => e.Id == article.Id);

                if (entity == null)
                {
                    return;
                }

                context.Articles.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
