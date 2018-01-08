using System;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Entities
{
    public class BankAccount
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string BankName { get; set; }
        public decimal InitialBalance { get; set; }
        public DateTime InitialBalanceDate { get; set; }
        public string Bik { get; set; }
        public string Account { get; set; }
    }
}