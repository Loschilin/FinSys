using System;
using Actidev.FinancialManagement.Data.Enums;

namespace Actidev.FinancialManagement.Data.Entities.Operations
{
    public class OperationToBankAccountLink
    {
        public Guid Id { get; set; }
        public Guid OperationId { get; set; }
        public Operation Operation { get; set; }
        public Guid BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
        public OperationToBankAccountLinkTypes BankAccountLinkType { get; set; }
    }
}