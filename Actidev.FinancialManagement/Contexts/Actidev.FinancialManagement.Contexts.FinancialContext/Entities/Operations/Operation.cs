using System;
using System.Collections.Generic;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Entities.Operations
{
    public abstract class Operation
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public Guid ArticleId { get; set; }
        public DateTime Date { get; set; }
        public Guid ContractorId { get; set; }
        public IEnumerable<OperationProjectInfo> Projects { get; set; }
        public string Comment { get; set; }
        public Guid FileInfoId { get; set; } 
    }
}
