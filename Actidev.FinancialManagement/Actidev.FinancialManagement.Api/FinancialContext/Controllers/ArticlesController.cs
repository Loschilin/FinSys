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
    [Route("api/articles")]
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository _repository;
        private readonly IArticleFactory _factory;

        public ArticlesController(
            IArticleRepository repository,
            IArticleFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        [Route("{id}"), HttpGet]
        public ArticleModel GetById(Guid id)
        {
            var article = _repository.GetById(id);
            return article?.GetModel();
        }

        [Route(""), HttpGet]
        public IEnumerable<ArticleModel> GetArticles()
        {
            return _repository
                .GetArticles(Const.UserId)
                .Select(e => e.GetModel());
        }

        [Route(""), HttpPost]
        public Guid Create([FromBody]ArticleModel model)
        {
            model.Id = Guid.NewGuid();

            var article = _factory.Create(
                model.Id, 
                Const.UserId, 
                model.ParentId, 
                model.Name, 
                false);
            article.CopyModelFields(model);
            _repository.Save(article);
            return model.Id;
        }

        [Route("{id}"), HttpPut]
        public Guid Update(Guid id, [FromBody]ArticleModel model)
        {
            model.Id = id;
            var article = _repository.GetById(id);
            if (article == null)
            {
                return Guid.Empty;
            }

            article.CopyModelFields(model);
            _repository.Save(article);
            return article.Id;
        }

        [Route("{id}"), HttpDelete]
        public void Delete(Guid id)
        {
            var article = _repository.GetById(id);
            _repository.Delete(article);
        }
    }
}