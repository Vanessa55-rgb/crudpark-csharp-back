using Microsoft.EntityFrameworkCore;
using CrudPark.Models;

namespace CrudPark.Data
{
    public class  CrudParkContext: DbContext
    {
        public CrudParkContext(DbContextOptions<CrudParkContext> options)
            : base(options)
        {
        }

        // tables
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        //  Configs
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table Operators
            modelBuilder.Entity<Operator>()
                .ToTable("operators")
                .HasKey(o => o.ID);

            modelBuilder.Entity<Operator>()
                .Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Operator>()
                .Property(o => o.Email)
                .HasMaxLength(100);

            // Table Allowances
            modelBuilder.Entity<Allowance>()
                .ToTable("allowances")
                .HasKey(a => a.ID);

            modelBuilder.Entity<Allowance>()
                .Property(a => a.Plate)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Allowance>()
                .Property(a => a.DateStart)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Allowance>()
                .Property(a => a.DateEnd)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Table Tickets
            modelBuilder.Entity<Ticket>()
                .ToTable("tickets")
                .HasKey(t => t.Id);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Folio)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Plate)
                .IsRequired()
                .HasMaxLength(10);
            //optional relation operator
            modelBuilder.Entity<Ticket>()
                .HasOne<Operator>()
                .WithMany()
                .HasForeignKey(t => t.OperatorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
