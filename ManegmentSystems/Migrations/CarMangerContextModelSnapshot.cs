﻿// <auto-generated />
using System;
using ManegmentSystems.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManegmentSystems.Migrations
{
    [DbContext(typeof(CarMangerContext))]
    partial class CarMangerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManegmentSystems.Data.Models.AfterBuyExpencess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<int?>("RecordId")
                        .HasColumnName("recordID");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.ToTable("AfterBuyExpencess");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AfterSellExpncess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<int?>("RecordId")
                        .HasColumnName("recordID");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.ToTable("AfterSellExpncess");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AspNetRoles", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AspNetUsers", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AspNetUserTokens", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Buy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnName("Car_ID");

                    b.Property<int>("CustomerId")
                        .HasColumnName("Customer_ID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<bool>("IsSold");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Buy");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.BuyRecords", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuyId")
                        .HasColumnName("Buy_ID");

                    b.Property<int>("OutcomeId")
                        .HasColumnName("Outcome_ID");

                    b.Property<int?>("PartnerId")
                        .HasColumnName("partner_ID");

                    b.HasKey("Id");

                    b.HasIndex("BuyId");

                    b.HasIndex("OutcomeId");

                    b.HasIndex("PartnerId");

                    b.ToTable("BuyRecords");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarId")
                        .HasColumnName("CarID");

                    b.Property<bool>("Insurance");

                    b.Property<int>("ModelId")
                        .HasColumnName("Model_ID");

                    b.Property<string>("MoreDetails")
                        .HasColumnName("moreDetails")
                        .HasColumnType("text");

                    b.Property<string>("Owener");

                    b.Property<bool>("Sold")
                        .HasColumnName("sold");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Cash", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("money");

                    b.Property<bool>("Arrested")
                        .HasColumnName("arrested");

                    b.Property<DateTime>("DateArrested")
                        .HasColumnName("dateArrested")
                        .HasColumnType("date");

                    b.Property<int?>("IncomeId")
                        .HasColumnName("Income_ID");

                    b.Property<int?>("OutcomeId")
                        .HasColumnName("Outcome_ID");

                    b.HasKey("Id");

                    b.HasIndex("IncomeId");

                    b.HasIndex("OutcomeId");

                    b.ToTable("cash");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Check", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("DueDate")
                        .HasColumnName("dueDate")
                        .HasColumnType("date");

                    b.Property<int?>("IncomeId")
                        .HasColumnName("Income_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("OutcomeId")
                        .HasColumnName("Outcome_ID");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnName("photo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IncomeId");

                    b.HasIndex("OutcomeId");

                    b.ToTable("check");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("IdPhoto")
                        .IsRequired()
                        .HasColumnName("ID_Photo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Income");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Manufacture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Manufacture");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ManufactureId")
                        .HasColumnName("Manufacture_ID");

                    b.Property<int?>("ModelId")
                        .HasColumnName("Model_ID");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ManufactureId");

                    b.HasIndex("ModelId");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Outcome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Outcome");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<decimal>("OwenMoeny")
                        .HasColumnName("Owen_moeny")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("partner");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.ProfitAndLoss", b =>
                {
                    b.Property<int>("SellRecordsId")
                        .HasColumnName("SellRecords_ID");

                    b.Property<int>("BuyRecordsId")
                        .HasColumnName("BuyRecords_ID");

                    b.Property<decimal>("Loss")
                        .HasColumnName("loss")
                        .HasColumnType("money");

                    b.Property<decimal>("Profit")
                        .HasColumnName("profit")
                        .HasColumnType("money");

                    b.HasKey("SellRecordsId", "BuyRecordsId");

                    b.HasIndex("BuyRecordsId");

                    b.ToTable("Profit_and_loss");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnName("Car_ID");

                    b.Property<decimal>("Commission")
                        .HasColumnName("commission")
                        .HasColumnType("money");

                    b.Property<int>("CustomerId")
                        .HasColumnName("Customer_ID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.SalePerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("IdPhoto")
                        .IsRequired()
                        .HasColumnName("ID_Photo")
                        .HasColumnType("text");

                    b.Property<string>("Idnumber")
                        .HasColumnName("IDNumber")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("SalePerson");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.SellRecords", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IncomeId")
                        .HasColumnName("Income_ID");

                    b.Property<int?>("PartnerId")
                        .HasColumnName("partner_ID");

                    b.Property<int?>("SaleId")
                        .HasColumnName("Sale_ID");

                    b.HasKey("Id");

                    b.HasIndex("IncomeId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("SaleId")
                        .IsUnique()
                        .HasName("KEY_SellRecords_Sale_ID")
                        .HasFilter("[Sale_ID] IS NOT NULL");

                    b.ToTable("SellRecords");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AfterBuyExpencess", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.BuyRecords", "Record")
                        .WithMany("AfterBuyExpencess")
                        .HasForeignKey("RecordId")
                        .HasConstraintName("FK_AfterBuyExpencess_recordID");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AfterSellExpncess", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.SellRecords", "Record")
                        .WithMany("AfterSellExpncess")
                        .HasForeignKey("RecordId")
                        .HasConstraintName("FK_AfterSellExpncess_recordID");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AspNetRoleClaims", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AspNetUserClaims", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AspNetUserLogins", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AspNetUserRoles", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ManegmentSystems.Data.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.AspNetUserTokens", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Buy", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.Car", "Car")
                        .WithMany("Buy")
                        .HasForeignKey("CarId")
                        .HasConstraintName("Buy_Car");

                    b.HasOne("ManegmentSystems.Data.Models.SalePerson", "Customer")
                        .WithMany("Buy")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("Copy_of_Sale_Customer");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.BuyRecords", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.Buy", "Buy")
                        .WithMany("BuyRecords")
                        .HasForeignKey("BuyId")
                        .HasConstraintName("BuyRecords_Buy");

                    b.HasOne("ManegmentSystems.Data.Models.Outcome", "Outcome")
                        .WithMany("BuyRecords")
                        .HasForeignKey("OutcomeId")
                        .HasConstraintName("BuyRecords_Outcome");

                    b.HasOne("ManegmentSystems.Data.Models.Partner", "Partner")
                        .WithMany("BuyRecords")
                        .HasForeignKey("PartnerId")
                        .HasConstraintName("BuyRecords_partner");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Car", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.Model", "Model")
                        .WithMany("Car")
                        .HasForeignKey("ModelId")
                        .HasConstraintName("Car_Model");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Cash", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.Income", "Income")
                        .WithMany("Cash")
                        .HasForeignKey("IncomeId")
                        .HasConstraintName("cash_Income");

                    b.HasOne("ManegmentSystems.Data.Models.Outcome", "Outcome")
                        .WithMany("Cash")
                        .HasForeignKey("OutcomeId")
                        .HasConstraintName("cash_Outcome");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Check", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.Income", "Income")
                        .WithMany("Check")
                        .HasForeignKey("IncomeId")
                        .HasConstraintName("check_Income");

                    b.HasOne("ManegmentSystems.Data.Models.Outcome", "Outcome")
                        .WithMany("Check")
                        .HasForeignKey("OutcomeId")
                        .HasConstraintName("check_Outcome");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Model", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.Manufacture", "Manufacture")
                        .WithMany("Model")
                        .HasForeignKey("ManufactureId")
                        .HasConstraintName("Model_Manufacture");

                    b.HasOne("ManegmentSystems.Data.Models.Model", "ModelNavigation")
                        .WithMany("InverseModelNavigation")
                        .HasForeignKey("ModelId")
                        .HasConstraintName("Model_Model");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.ProfitAndLoss", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.BuyRecords", "BuyRecords")
                        .WithMany("ProfitAndLoss")
                        .HasForeignKey("BuyRecordsId")
                        .HasConstraintName("Profit_and_loss_BuyRecords");

                    b.HasOne("ManegmentSystems.Data.Models.SellRecords", "SellRecords")
                        .WithMany("ProfitAndLoss")
                        .HasForeignKey("SellRecordsId")
                        .HasConstraintName("Profit_and_loss_SellRecords");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.Sale", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.Car", "Car")
                        .WithMany("Sale")
                        .HasForeignKey("CarId")
                        .HasConstraintName("Sale_Car");

                    b.HasOne("ManegmentSystems.Data.Models.Customer", "Customer")
                        .WithMany("Sale")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("Sale_Customer");
                });

            modelBuilder.Entity("ManegmentSystems.Data.Models.SellRecords", b =>
                {
                    b.HasOne("ManegmentSystems.Data.Models.Income", "Income")
                        .WithMany("SellRecords")
                        .HasForeignKey("IncomeId")
                        .HasConstraintName("Records_Income");

                    b.HasOne("ManegmentSystems.Data.Models.Partner", "Partner")
                        .WithMany("SellRecords")
                        .HasForeignKey("PartnerId")
                        .HasConstraintName("Records_partner");

                    b.HasOne("ManegmentSystems.Data.Models.Sale", "Sale")
                        .WithOne("SellRecords")
                        .HasForeignKey("ManegmentSystems.Data.Models.SellRecords", "SaleId")
                        .HasConstraintName("Records_Sale");
                });
#pragma warning restore 612, 618
        }
    }
}