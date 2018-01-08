using System;
using Actidev.FinancialManagement.Data.Enums;

namespace Actidev.FinancialManagement.Data.Entities.Operations
{
    public class OperationToProjectLink
    {
        public Guid Id { get; set; }
        public Guid OperationId { get; set; }
        public Operation Operation { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public decimal Amount { get; set; }
        public OperationToProjectLinkType ProjectLinkType { get; set; }
    }
}