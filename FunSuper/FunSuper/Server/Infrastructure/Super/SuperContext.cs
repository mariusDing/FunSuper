using FunSuper.Server.Entities;
using FunSuper.Server.Infrastructure.Super.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace FunSuper.Server.Infrastructure.Super
{
    public class SuperContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "super";

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payslip> Payslips { get; set; }
        public DbSet<Disbursement> Disbursements { get; set; }
        public DbSet<PayCode> PayCodes { get; set; }

        public SuperContext(DbContextOptions<SuperContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new PayslipConfig());
            modelBuilder.ApplyConfiguration(new DisbursementConfig());
            modelBuilder.ApplyConfiguration(new PayCodeConfig());
        }
    }
}
