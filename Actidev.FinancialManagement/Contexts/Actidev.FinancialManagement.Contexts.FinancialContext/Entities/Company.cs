using System;

namespace Actidev.FinancialManagement.Contexts.FinancialContext.Entities
{
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
    }
}
