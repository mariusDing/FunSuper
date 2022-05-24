using FunSuper.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunSuper.Server.Infrastructure.Super.EntityConfig
{
    public class DisbursementConfig : IEntityTypeConfiguration<Disbursement>
    {
        public void Configure(EntityTypeBuilder<Disbursement> builder)
        {
            builder.HasOne(b => b.Employee).WithMany(b => b.Disbursements);
        }
    }
}
