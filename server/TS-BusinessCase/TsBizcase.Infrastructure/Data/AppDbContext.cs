using Microsoft.EntityFrameworkCore;
using TsBizcase.Core.Entities;
using TsBizcase.Infrastructure.Configurations;

namespace TsBizcase.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Tender> Tenders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new TenderConfiguration());

            SeedAppUsers(builder);
        }

        #region Seed
        private static void SeedAppUsers(ModelBuilder builder)
        {
            builder
                .Entity<AppUser>()
                .HasData
                (
                    new AppUser
                    {
                        Id = 1,
                        Name = "Anita Herrera",
                        Email = "anita.herrera@houseoffoo.com",
                        HashedPassword = "AQAAAAEAACcQAAAAEG8W4Xu0BxhbTMb7qOpixB47PGMKTqS66OzGQrihsvXFLXTYS4I0KDJPR/TIEIvx1w=="
                        /* Password=@Passw0rd01 */
                    },
                    new AppUser
                    {
                        Id = 2,
                        Name = "Brooklyn Hamilton",
                        Email = "brooklyn.hamilton@hamiltonbrook.com",
                        HashedPassword = "AQAAAAEAACcQAAAAELWpKaj6KMCYfN23Y0yY+g5fDxu07aeAf67fqu2frjkDF/rs4GNTl3JT5sD7ouDRzA=="
                        /* Password=@Passw0rd02 */
                    },
                    new AppUser
                    {
                        Id = 3,
                        Name = "Liam Davidson",
                        Email = "liam.davidson@lidavman.com",
                        HashedPassword = "AQAAAAEAACcQAAAAEKvsxNN3F2vWp0NrsjGyqEyJREvoydZA+U4mR5WwtNJAn9mD5HgngFov0AsMzFc1/g=="
                        /* Password=@Passw0rd03 */
                    }
                );
        }
        #endregion
    }
}
