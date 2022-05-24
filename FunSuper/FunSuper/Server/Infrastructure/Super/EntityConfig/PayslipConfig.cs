using FunSuper.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunSuper.Server.Infrastructure.Super.EntityConfig
{
    public class PayslipConfig : IEntityTypeConfiguration<Payslip>
    {
        public void Configure(EntityTypeBuilder<Payslip> builder)
        {
            builder.HasOne(b => b.Employee).WithMany(b => b.Payslips);
            builder.HasOne(b => b.PayCode).WithMany(b => b.Payslips);
        }
    }
}
