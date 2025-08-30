using Microsoft.EntityFrameworkCore;
using AdeventureWorksApi.Models;

namespace AdeventureWorksApi.Data
{
    public class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Customer entity
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "SalesLT");
                
                entity.HasKey(e => e.CustomerID);
                
                entity.Property(e => e.CustomerID)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameStyle)
                    .HasColumnName("NameStyle")
                    .HasDefaultValue(false);

                entity.Property(e => e.Title)
                    .HasColumnName("Title")
                    .HasMaxLength(8);

                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.MiddleName)
                    .HasColumnName("MiddleName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Suffix)
                    .HasColumnName("Suffix")
                    .HasMaxLength(10);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("CompanyName")
                    .HasMaxLength(128);

                entity.Property(e => e.SalesPerson)
                    .HasColumnName("SalesPerson")
                    .HasMaxLength(256);

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("EmailAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("Phone")
                    .HasMaxLength(25);

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("PasswordHash")
                    .HasMaxLength(128)
                    .IsRequired();

                entity.Property(e => e.PasswordSalt)
                    .HasColumnName("PasswordSalt")
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("NEWID()")
                    .IsRequired();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasDefaultValueSql("GETDATE()")
                    .IsRequired();

                // Unique constraint on rowguid
                entity.HasIndex(e => e.RowGuid)
                    .IsUnique()
                    .HasDatabaseName("AK_Customer_rowguid");
            });
        }
    }
}