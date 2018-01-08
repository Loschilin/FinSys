using System;

namespace Actidev.FinancialManagement.Contexts.ReportsContext
{
    public interface IReportRequest
    {
        Guid UserId { get; }
        PeriodInfo PeriodInfo { get; }
        ReportFormat Format { get; }
    }
}
