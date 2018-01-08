using System;
using Actidev.FinancialManagement.Contexts.FinancialContext.Entities;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Factories.Interfaces
{
    public interface IArticleFactory
    {
        Article Create(Guid id, Guid? userId, string name, bool isReadonly);
        Article Create(Guid id, Guid? userId, Guid? parentId, string name, bool isReadonly);
    }
}
