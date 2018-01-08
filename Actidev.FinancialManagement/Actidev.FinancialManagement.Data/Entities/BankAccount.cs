using System;
using System.Collections.Generic;
using Actidev.FinancialManagement.Data.Entities.Operations;

namespace Actidev.FinancialManagement.Data.Entities
{
    /// <summary>
    /// Банковские счта компаний
    /// </summary>
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

        public IEnumerable<OperationToBankAccountLink> OperationToBankAccountLinks { get; set; }
        public Company Company { get; set; }
    }
}