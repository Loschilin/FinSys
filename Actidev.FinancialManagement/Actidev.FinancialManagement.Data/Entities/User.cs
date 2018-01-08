using System;
using System.Collections.Generic;
using Actidev.FinancialManagement.Data.Entities.Operations;

namespace Actidev.FinancialManagement.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public IEnumerable<Operation> Operations { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Contractor> Contractors { get; set; }
        public IEnumerable<Project> Projects { get; set; }

    }
}