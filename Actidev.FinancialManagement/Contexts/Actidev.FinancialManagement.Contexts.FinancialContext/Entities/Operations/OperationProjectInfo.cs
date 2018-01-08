using System;
using Actidev.FinancialManagement.Data.Enums;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Entities.Operations
{
    public class OperationProjectInfo
    {
        public Guid ProjectId { get; set; }
        public decimal Amount { get; set; }
        public OperationToProjectLinkType ProjectLinkType { get; set; }
    }
}