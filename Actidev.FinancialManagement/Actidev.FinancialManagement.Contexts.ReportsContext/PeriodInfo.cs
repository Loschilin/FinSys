using System;

namespace Actidev.FinancialManagement.Contexts.ReportsContext
{
    public class PeriodInfo
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ReportPeriodTypes Type { get; set; }
    }
}