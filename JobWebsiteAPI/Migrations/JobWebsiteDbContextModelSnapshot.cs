﻿// <auto-generated />
using JobWebsiteAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobWebsiteAPI.Migrations
{
    [DbContext(typeof(JobWebsiteDbContext))]
    partial class JobWebsiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ContractTypeJobOffer", b =>
                {
                    b.Property<int>("ContractTypesId")
                        .HasColumnType("int");

                    b.Property<int>("JobOffersId")
                        .HasColumnType("int");

                    b.HasKey("ContractTypesId", "JobOffersId");

                    b.HasIndex("JobOffersId");

                    b.ToTable("ContractTypeJobOffer", (string)null);
                });

            modelBuilder.Entity("JobOfferPersonalAccount", b =>
                {
                    b.Property<int>("AccountsThatApliedId")
                        .HasColumnType("int");

                    b.Property<int>("AppliedJobOffersId")
                        .HasColumnType("int");

                    b.HasKey("AccountsThatApliedId", "AppliedJobOffersId");

                    b.HasIndex("AppliedJobOffersId");

                    b.ToTable("JobOfferPersonalAccount", (string)null);
                });

            modelBuilder.Entity("JobOfferTag", b =>
                {
                    b.Property<int>("JobOffersId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("JobOffersId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("JobOfferTag", (string)null);
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Accounts", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Account");
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes", (string)null);
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApartmentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.ContractType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContractTypes", (string)null);
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.JobOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GrossSalary")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("HoursPerMonth")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("JobOffers", (string)null);
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags", (string)null);
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.CompanyAccount", b =>
                {
                    b.HasBaseType("JobWebsiteAPI.Entities.Account");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("CompanyAccount");
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.PersonalAccount", b =>
                {
                    b.HasBaseType("JobWebsiteAPI.Entities.Account");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PersonalAccount");
                });

            modelBuilder.Entity("ContractTypeJobOffer", b =>
                {
                    b.HasOne("JobWebsiteAPI.Entities.ContractType", null)
                        .WithMany()
                        .HasForeignKey("ContractTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobWebsiteAPI.Entities.JobOffer", null)
                        .WithMany()
                        .HasForeignKey("JobOffersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobOfferPersonalAccount", b =>
                {
                    b.HasOne("JobWebsiteAPI.Entities.PersonalAccount", null)
                        .WithMany()
                        .HasForeignKey("AccountsThatApliedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobWebsiteAPI.Entities.JobOffer", null)
                        .WithMany()
                        .HasForeignKey("AppliedJobOffersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobOfferTag", b =>
                {
                    b.HasOne("JobWebsiteAPI.Entities.JobOffer", null)
                        .WithMany()
                        .HasForeignKey("JobOffersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobWebsiteAPI.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.Account", b =>
                {
                    b.HasOne("JobWebsiteAPI.Entities.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobWebsiteAPI.Entities.Address", "Address")
                        .WithOne("Account")
                        .HasForeignKey("JobWebsiteAPI.Entities.Account", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.JobOffer", b =>
                {
                    b.HasOne("JobWebsiteAPI.Entities.CompanyAccount", "Creator")
                        .WithMany("CreatedJobOffers")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.AccountType", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.Address", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });

            modelBuilder.Entity("JobWebsiteAPI.Entities.CompanyAccount", b =>
                {
                    b.Navigation("CreatedJobOffers");
                });
#pragma warning restore 612, 618
        }
    }
}
