using System;

namespace Actidev.FinancialManagement.Api.FinancialContext.Models
{
    public class ArticleModel
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public bool Readonly { get; set; }
    }
}