namespace Actidev.FinancialManagement.Contexts.ReportsContext
{
    public interface IReportBuilder<out TReport, in TReportRequest>
        where TReportRequest: IReportRequest
        where TReport : class 
    {
        TReport BuildReport(TReportRequest request);
    }
}