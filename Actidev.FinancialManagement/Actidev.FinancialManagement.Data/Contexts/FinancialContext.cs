using Actidev.FinancialManagement.Data.Entities;
using Actidev.FinancialManagement.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;

namespace Actidev.FinancialManagement.Data.Contexts
{
    public class FinancialContext : DbContext
    {
        public FinancialContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationTemplateOptions> OperationTemplateOptions { get; set; }
        public DbSet<OperationToBankAccountLink> OperationToBankAccountLinks { get; set; }
        public DbSet<OperationToProjectLink> OperationToProjectLinks { get; set; }
        public DbSet<FileInfo> FilesInfo { get; set; }
    }
}
