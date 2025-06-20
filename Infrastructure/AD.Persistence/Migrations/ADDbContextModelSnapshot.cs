﻿// <auto-generated />
using AD.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AD.Persistence.Migrations
{
    [DbContext(typeof(ADDbContext))]
    partial class ADDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.17");

            modelBuilder.Entity("AD.Domain.Entities.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT")
                        .HasColumnName("EMAIL");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT")
                        .HasColumnName("PASSWORD_HASH")
                        .IsFixedLength();

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("ROLE");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT")
                        .HasColumnName("SALT")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("ACCOUNTS", (string)null);
                });

            modelBuilder.Entity("AD.Domain.Entities.Payment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("ID");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT")
                        .HasColumnName("AMOUNT");

                    b.Property<string>("DateTime")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DATE_TIME");

                    b.Property<string>("RateId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserProfileId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RateId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("PAYMENTS", (string)null);
                });

            modelBuilder.Entity("AD.Domain.Entities.Rate", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("ID");

                    b.Property<decimal>("CurrentRate")
                        .HasColumnType("TEXT")
                        .HasColumnName("CURRENT_RATE");

                    b.Property<string>("DateSet")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DATE_SET");

                    b.HasKey("Id");

                    b.ToTable("RATES", (string)null);
                });

            modelBuilder.Entity("AD.Domain.Entities.UserProfile", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("ID");

                    b.Property<decimal>("Balance")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("BALANCE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("USER_PROFILES", (string)null);
                });

            modelBuilder.Entity("AD.Domain.Entities.Account", b =>
                {
                    b.HasOne("AD.Domain.Entities.UserProfile", "UserProfile")
                        .WithOne("Account")
                        .HasForeignKey("AD.Domain.Entities.Account", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("AD.Domain.Entities.Payment", b =>
                {
                    b.HasOne("AD.Domain.Entities.Rate", "Rate")
                        .WithMany("Payments")
                        .HasForeignKey("RateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AD.Domain.Entities.UserProfile", "UserProfile")
                        .WithMany("Payments")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rate");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("AD.Domain.Entities.Rate", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("AD.Domain.Entities.UserProfile", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
