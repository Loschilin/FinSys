using System;
using System.Collections.Generic;

namespace Actidev.FinancialManagement.Data.Entities
{
    /// <summary>
    /// Справочинки. Компания
    /// </summary>
    public class Company
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string GeneralManager { get; set; }

        public IEnumerable<BankAccount> BankAccounts { get; set; }
        public User User { get; set; }
    }
}