using System;
using System.Collections.Generic;
using Actidev.FinancialManagement.Data.Enums;

namespace Actidev.FinancialManagement.Data.Entities.Operations
{
    public class Operation
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }

        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

        public DateTime Date { get; set; }
        public AccrualOperationType? AccrualOperationType { get; set; }
        public DateTime? AccrualDate { get; set; }
        public OperationTypes Type { get; set; }

        public Guid ContractorId { get; set; }
        public Contractor Contractor { get; set; }

        public string Comment { get; set; }

        public Guid? FileInfoId { get; set; }
        public FileInfo FileInfo { get; set; }

        public OperationTemplateOptions OperationTemplateOptions { get; set; }
        public IEnumerable<OperationToBankAccountLink> OperationToBankAccountLinks { get; set; }
        public IEnumerable<OperationToProjectLink> OperationToProjectLinks { get; set; }
    }
}
