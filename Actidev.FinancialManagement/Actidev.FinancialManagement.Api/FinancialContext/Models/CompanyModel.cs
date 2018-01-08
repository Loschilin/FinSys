using System;

namespace Actidev.FinancialManagement.Api.FinancialContext.Models
{
    public class CompanyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string GeneralManager { get; set; }
    }
}