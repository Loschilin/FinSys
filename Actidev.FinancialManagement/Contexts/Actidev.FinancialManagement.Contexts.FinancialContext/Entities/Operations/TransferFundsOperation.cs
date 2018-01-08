using System;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Entities.Operations
{
    public class TransferFundsOperation : Operation
    {
        public Guid SourceBankAccountId { get; set; }
        public Guid DestinationBankAccountId { get; set; }
    }
}