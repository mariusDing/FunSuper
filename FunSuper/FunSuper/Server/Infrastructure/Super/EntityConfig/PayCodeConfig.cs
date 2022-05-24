using FunSuper.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunSuper.Server.Infrastructure.Super.EntityConfig
{
    public class PayCodeConfig : IEntityTypeConfiguration<PayCode>
    {
        public void Configure(EntityTypeBuilder<PayCode> builder)
        {
            builder.HasMany(b => b.Payslips).WithOne(b => b.PayCode);
        }
    }
}
