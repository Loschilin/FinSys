using System;
using System.Collections.Generic;
using System.Linq;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;
using Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces;
using Actidev.FinancialManagement.Contexts.FinancialContext.Repositories.Interfaces;
using Actidev.FinancialManagement.Data.Factories.Interfaces;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Repositories
{
    internal class ProjectRepository : IProjectRepository
    {
        private readonly IContextFactory<Data.Contexts.FinancialContext> _contextFactory;
        private readonly IProjectFactory _projectFactory;
        private readonly IProjectEntityFactory _entityFactory;

        public ProjectRepository(
            IContextFactory<Data.Contexts.FinancialContext> contextFactory,
            IProjectFactory projectFactory,
            IProjectEntityFactory entityFactory
        )
        {
            _contextFactory = contextFactory;
            _projectFactory = projectFactory;
            _entityFactory = entityFactory;
        }

        public Project GetById(Guid id)
        {
            using (var context = _contextFactory.Create())
            {
                var entity = context.Projects.FirstOrDefault(e => e.Id == id);

                if (entity == null)
                {
                    return null;
                }

                var project = CreateProject(entity);
                return project;
            }
        }

        private Project CreateProject(Data.Entities.Project entity)
        {
            var project = _projectFactory.Create(entity.Id, entity.UserId);
            project.Name = entity.Name;
            project.Description = entity.Description;
            return project;
        }

        public IEnumerable<Project> GetAll()
        {
            using (var context = _contextFactory.Create())
            {
                return context.Projects.Select(CreateProject).ToArray();
            }
        }

        public void Save(Project project)
        {
            using (var context = _contextFactory.Create())
            {
                var entity = context.Projects.FirstOrDefault(e => e.Id == project.Id);

                if (entity == null)
                {
                    entity = _entityFactory.Create(
                        project.Id, 
                        project.UserId, 
                        project.Name);

                    context.Projects.Add(entity);
                }

                entity.Name = project.Name;
                entity.Description = project.Description;

                context.SaveChanges();
            }
        }

        public void Delete(Project project)
        {
            using (var context = _contextFactory.Create())
            {
                var entity = context.Projects.FirstOrDefault(e => e.Id == project.Id);

                if (entity == null)
                {
                    return;
                }

                context.Projects.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}