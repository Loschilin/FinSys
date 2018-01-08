using System;
using System.Collections.Generic;
using Actidev.FinancialManagement.Data.Entities.Operations;

namespace Actidev.FinancialManagement.Data.Entities
{
    /// <summary>
    /// Статья
    /// </summary>
    public class Article
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public Article Parent { get; set; }
        public IEnumerable<Article> Childs { get; set; }
        public string Name { get; set; }
        public Guid? UserId { get; set; }

        public IEnumerable<Operation> Operations { get; set; }
        public User User { get; set; }
    }
}