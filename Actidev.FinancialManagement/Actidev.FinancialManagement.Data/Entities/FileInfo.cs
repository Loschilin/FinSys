using System;
using System.Collections.Generic;
using Actidev.FinancialManagement.Data.Entities.Operations;

namespace Actidev.FinancialManagement.Data.Entities
{
    public class FileInfo
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public IEnumerable<Operation> Operations { get; set; }
    }
}