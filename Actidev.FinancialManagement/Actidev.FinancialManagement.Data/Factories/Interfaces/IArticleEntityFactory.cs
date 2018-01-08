using System;
using Actidev.FinancialManagement.Data.Entities;

namespace Actidev.FinancialManagement.Data.Factories.Interfaces
{
    public interface IArticleEntityFactory
    {
        Article Create(Guid id, Guid? userId, string name);
    }
}