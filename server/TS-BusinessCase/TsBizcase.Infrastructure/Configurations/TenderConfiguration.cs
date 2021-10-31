using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TsBizcase.Core.Entities;

namespace TsBizcase.Infrastructure.Configurations
{
    public class TenderConfiguration : IEntityTypeConfiguration<Tender>
    {
        public void Configure(EntityTypeBuilder<Tender> builder)
        {
            builder
                .HasOne(p => p.Creator)
                .WithMany(p => p.Tenders)
                .HasForeignKey(p => p.CreatorId);
        }
    }
}
