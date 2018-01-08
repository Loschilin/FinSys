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
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _repository;
        private readonly IProjectFactory _factory;

        public ProjectController(
            IProjectRepository repository,
            IProjectFactory factory
            )
        {
            _repository = repository;
            _factory = factory;
        }

        [Route("{id}"), HttpGet]
        public ProjectModel GetById(Guid id)
        {
            var project = _repository.GetById(id);
            var model = project?.GetModel();
            return model;
        }

        [Route(""), HttpGet]
        public IEnumerable<ProjectModel> GetProjects()
        {
            var projects = _repository.GetAll()
                .Select(e => e.GetModel()).ToArray();
            return projects;
        }

        [Route(""), HttpPost]
        public Guid Create([FromBody]ProjectModel model)
        {
            model.Id = Guid.NewGuid();
            var project = _factory.Create(model.Id, Const.UserId);
            project.CopyModelFields(model);
            _repository.Save(project);
            return model.Id;
        }

        [Route("{id}"), HttpPut]
        public Guid Update(Guid id, [FromBody]ProjectModel model)
        {
            model.Id = id;
            var project = _repository.GetById(id);
            if (project == null)
            {
                return Guid.Empty;
            }
            project.CopyModelFields(model);
            _repository.Save(project);
            return project.Id;
        }

        [Route("{id}"), HttpDelete]
        public void Delete(Guid id)
        {
            var project = _repository.GetById(id);
            if (project == null)
            {
                return;
            }

            _repository.Delete(project);
        }
    }
}