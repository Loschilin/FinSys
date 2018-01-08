using System;
using Actidev.FinancialManagement.Data.Enums;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Entities.Operations
{
    public class PaymentOperation : Operation
    {
        public RepeatOptions RepeatOptions { get; set; }
        public AccrualOperationType AccrualType { get; set; }
        public DateTime? AccrualDate { get; set; }
        public Guid BankAccountId { get; set; }
    }
}