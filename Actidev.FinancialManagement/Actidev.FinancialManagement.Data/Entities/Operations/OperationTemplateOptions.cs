using System;
using Actidev.FinancialManagement.Data.Enums;

namespace Actidev.FinancialManagement.Data.Entities.Operations
{
    public class OperationTemplateOptions
    {
        public Guid Id { get; set; }
        public Guid OprationId { get; set; }
        public Operation Operation { get; set; }
        public OperationRepeatTypes Repeat { get; set; }
    }
}