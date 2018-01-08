using System;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string Name { get; set; }
        public bool Readonly { get; set; }
    }
}
