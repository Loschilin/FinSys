using System;
using System.Collections.Generic;
using Actidev.FinancialManagement.Data.Entities.Operations;

namespace Actidev.FinancialManagement.Data.Entities
{
    /// <summary>
    /// Справочник контрагент
    /// </summary>
    public class Contractor
    {
        //common info

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
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

        public IEnumerable<Operation> Operations { get; set; }
        public User User { get; set; }
    }
    

}
