using System;

namespace Actidev.FinancialManagement.Api.FinancialContext.Models
{
    public class ContractorModel
    {
        //common info

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }

        //bank accounts info

        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string Account { get; set; }
        public string City { get; set; }

        //contacts
        public string Index { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string SiteUrl { get; set; }

        //tech
        public string Comment { get; set; }
    }
}