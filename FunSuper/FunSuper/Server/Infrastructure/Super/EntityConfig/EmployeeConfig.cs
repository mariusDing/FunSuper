using FunSuper.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunSuper.Server.Infrastructure.Super.EntityConfig
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasMany(b => b.Disbursements).WithOne(b => b.Employee);
            builder.HasMany(b => b.Payslips).WithOne(b => b.Employee);
        }
    }
}
