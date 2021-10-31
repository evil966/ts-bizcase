﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TsBizcase.Infrastructure.Data;

namespace TsBizcase.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211029152707_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TsBizcase.Core.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_AppUser_Email")
                        .IsUnique();

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "anita.herrera@houseoffoo.com",
                            HashedPassword = "AQAAAAEAACcQAAAAEG8W4Xu0BxhbTMb7qOpixB47PGMKTqS66OzGQrihsvXFLXTYS4I0KDJPR/TIEIvx1w==",
                            Name = "Anita Herrera"
                        },
                        new
                        {
                            Id = 2,
                            Email = "brooklyn.hamilton@hamiltonbrook.com",
                            HashedPassword = "AQAAAAEAACcQAAAAELWpKaj6KMCYfN23Y0yY+g5fDxu07aeAf67fqu2frjkDF/rs4GNTl3JT5sD7ouDRzA==",
                            Name = "Brooklyn Hamilton"
                        },
                        new
                        {
                            Id = 3,
                            Email = "liam.davidson@lidavman.com",
                            HashedPassword = "AQAAAAEAACcQAAAAEKvsxNN3F2vWp0NrsjGyqEyJREvoydZA+U4mR5WwtNJAn9mD5HgngFov0AsMzFc1/g==",
                            Name = "Liam Davidson"
                        });
                });

            modelBuilder.Entity("TsBizcase.Core.Entities.Tender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Tenders");
                });

            modelBuilder.Entity("TsBizcase.Core.Entities.Tender", b =>
                {
                    b.HasOne("TsBizcase.Core.Entities.AppUser", "Creator")
                        .WithMany("Tenders")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("TsBizcase.Core.Entities.AppUser", b =>
                {
                    b.Navigation("Tenders");
                });
#pragma warning restore 612, 618
        }
    }
}
