using System;
using System.Collections.Generic;
using Actidev.FinancialManagement.Data.Entities.Operations;

namespace Actidev.FinancialManagement.Data.Entities
{
    /// <summary>
    /// Справочники. Проект
    /// </summary>
    public class Project
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<OperationToProjectLink> OperationToProjectLinks { get; set; }
        public User User { get; set; }
    }
}