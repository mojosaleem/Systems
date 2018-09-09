using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManegmentSystems.Data.Models
{
    public partial class CarMangerContext : DbContext
    {
        public CarMangerContext()
        {
        }

        public CarMangerContext(DbContextOptions<CarMangerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AfterBuyExpencess> AfterBuyExpencess { get; set; }
        public virtual DbSet<AfterSellExpncess> AfterSellExpncess { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Buy> Buy { get; set; }
        public virtual DbSet<BuyRecords> BuyRecords { get; set; }
        public virtual DbSet<CapitalShare> CapitalShare { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Cash> Cash { get; set; }
        public virtual DbSet<Check> Check { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Manufacture> Manufacture { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Outcome> Outcome { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<ProfitAndLoss> ProfitAndLoss { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SalePerson> SalePerson { get; set; }
        public virtual DbSet<SellRecords> SellRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=CarManger;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AfterBuyExpencess>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.RecordId).HasColumnName("recordID");

                entity.HasOne(d => d.Record)
                    .WithMany(p => p.AfterBuyExpencess)
                    .HasForeignKey(d => d.RecordId)
                    .HasConstraintName("FK_AfterBuyExpencess_recordID");
            });

            modelBuilder.Entity<AfterSellExpncess>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.RecordId).HasColumnName("recordID");

                entity.HasOne(d => d.Record)
                    .WithMany(p => p.AfterSellExpncess)
                    .HasForeignKey(d => d.RecordId)
                    .HasConstraintName("FK_AfterSellExpncess_recordID");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Buy>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarId).HasColumnName("Car_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Buy)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Buy_Car");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buy)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Copy_of_Sale_Customer");
            });

            modelBuilder.Entity<BuyRecords>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BuyId).HasColumnName("Buy_ID");

                entity.Property(e => e.OutcomeId).HasColumnName("Outcome_ID");

                entity.Property(e => e.PartnerId).HasColumnName("partner_ID");

                entity.HasOne(d => d.Buy)
                    .WithMany(p => p.BuyRecords)
                    .HasForeignKey(d => d.BuyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BuyRecords_Buy");

                entity.HasOne(d => d.Outcome)
                    .WithMany(p => p.BuyRecords)
                    .HasForeignKey(d => d.OutcomeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BuyRecords_Outcome");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.BuyRecords)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("BuyRecords_partner");
            });

            modelBuilder.Entity<CapitalShare>(entity =>
            {
                entity.HasIndex(e => e.AspNetUsersId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.DateAdd).HasColumnName("dateADD");

                entity.HasOne(d => d.AspNetUsers)
                    .WithMany(p => p.CapitalShare)
                    .HasForeignKey(d => d.AspNetUsersId)
                    .HasConstraintName("FK_CapitalShare_AspNetUsersId");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.ModelId).HasColumnName("Model_ID");

                entity.Property(e => e.MoreDetails)
                    .HasColumnName("moreDetails")
                    .HasColumnType("text");

                entity.Property(e => e.Sold).HasColumnName("sold");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Car_Model");
            });

            modelBuilder.Entity<Cash>(entity =>
            {
                entity.ToTable("cash");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Arrested).HasColumnName("arrested");

                entity.Property(e => e.DateArrested)
                    .HasColumnName("dateArrested")
                    .HasColumnType("date");

                entity.Property(e => e.IncomeId).HasColumnName("Income_ID");

                entity.Property(e => e.OutcomeId).HasColumnName("Outcome_ID");

                entity.HasOne(d => d.Income)
                    .WithMany(p => p.Cash)
                    .HasForeignKey(d => d.IncomeId)
                    .HasConstraintName("cash_Income");

                entity.HasOne(d => d.Outcome)
                    .WithMany(p => p.Cash)
                    .HasForeignKey(d => d.OutcomeId)
                    .HasConstraintName("cash_Outcome");
            });

            modelBuilder.Entity<Check>(entity =>
            {
                entity.ToTable("check");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.DueDate)
                    .HasColumnName("dueDate")
                    .HasColumnType("date");

                entity.Property(e => e.IncomeId).HasColumnName("Income_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OutcomeId).HasColumnName("Outcome_ID");

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasColumnType("text");

                entity.HasOne(d => d.Income)
                    .WithMany(p => p.Check)
                    .HasForeignKey(d => d.IncomeId)
                    .HasConstraintName("check_Income");

                entity.HasOne(d => d.Outcome)
                    .WithMany(p => p.Check)
                    .HasForeignKey(d => d.OutcomeId)
                    .HasConstraintName("check_Outcome");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdPhoto)
                    .IsRequired()
                    .HasColumnName("ID_Photo");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Manufacture>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ManufactureId).HasColumnName("Manufacture_ID");

                entity.Property(e => e.ModelId).HasColumnName("Model_ID");

                entity.HasOne(d => d.Manufacture)
                    .WithMany(p => p.Model)
                    .HasForeignKey(d => d.ManufactureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Model_Manufacture");

                entity.HasOne(d => d.ModelNavigation)
                    .WithMany(p => p.InverseModelNavigation)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("Model_Model");
            });

            modelBuilder.Entity<Outcome>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.ToTable("partner");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.OwenMoeny)
                    .HasColumnName("Owen_moeny")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<ProfitAndLoss>(entity =>
            {
                entity.HasKey(e => new { e.SellRecordsId, e.BuyRecordsId });

                entity.ToTable("Profit_and_loss");

                entity.Property(e => e.SellRecordsId).HasColumnName("SellRecords_ID");

                entity.Property(e => e.BuyRecordsId).HasColumnName("BuyRecords_ID");

                entity.Property(e => e.Loss)
                    .HasColumnName("loss")
                    .HasColumnType("money");

                entity.Property(e => e.Profit)
                    .HasColumnName("profit")
                    .HasColumnType("money");

                entity.HasOne(d => d.BuyRecords)
                    .WithMany(p => p.ProfitAndLoss)
                    .HasForeignKey(d => d.BuyRecordsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Profit_and_loss_BuyRecords");

                entity.HasOne(d => d.SellRecords)
                    .WithMany(p => p.ProfitAndLoss)
                    .HasForeignKey(d => d.SellRecordsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Profit_and_loss_SellRecords");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarId).HasColumnName("Car_ID");

                entity.Property(e => e.Commission)
                    .HasColumnName("commission")
                    .HasColumnType("money");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sale_Car");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sale_Customer");
            });

            modelBuilder.Entity<SalePerson>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdPhoto)
                    .IsRequired()
                    .HasColumnName("ID_Photo")
                    .HasColumnType("text");

                entity.Property(e => e.Idnumber)
                    .HasColumnName("IDNumber")
                    .HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<SellRecords>(entity =>
            {
                entity.HasIndex(e => e.SaleId)
                    .HasName("KEY_SellRecords_Sale_ID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IncomeId).HasColumnName("Income_ID");

                entity.Property(e => e.PartnerId).HasColumnName("partner_ID");

                entity.Property(e => e.SaleId).HasColumnName("Sale_ID");

                entity.HasOne(d => d.Income)
                    .WithMany(p => p.SellRecords)
                    .HasForeignKey(d => d.IncomeId)
                    .HasConstraintName("Records_Income");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.SellRecords)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("Records_partner");

                entity.HasOne(d => d.Sale)
                    .WithOne(p => p.SellRecords)
                    .HasForeignKey<SellRecords>(d => d.SaleId)
                    .HasConstraintName("Records_Sale");
            });
        }
    }
}
