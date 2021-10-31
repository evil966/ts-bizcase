using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TsBizcase.Core.Entities;

namespace TsBizcase.Infrastructure.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .HasMany(p => p.Tenders)
                .WithOne(p => p.Creator)
                .HasForeignKey(p => p.CreatorId);

            builder.HasIndex(idx => new { idx.Email }, "IX_AppUser_Email").IsUnique();
            
        }
    }
}
