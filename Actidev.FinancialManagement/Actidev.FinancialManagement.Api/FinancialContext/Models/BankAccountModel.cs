using System;

namespace Actidev.FinancialManagement.Api.FinancialContext.Models
{
    public class BankAccountModel
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string BankName { get; set; }
        public decimal InitialBalance { get; set; }
        public DateTime InitialBalanceDate { get; set; }
        public string Bik { get; set; }
        public string Account { get; set; }
    }
}