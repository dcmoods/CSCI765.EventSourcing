using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Appointment.Infrastructure.EventStore.SqlServer.Data
{
    public partial class CQRSEventStore : DbContext
    {
        public CQRSEventStore()
        {
        }

        public CQRSEventStore(DbContextOptions<CQRSEventStore> options)
            : base(options)
        {
        }

        public virtual DbSet<LoggedEvent> LoggedEvent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\mmoody\\source\\repos\\CSCI765.EventSourcing\\SqlStore\\escqrssql.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoggedEvent>(entity =>
            {
                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });
        }
    }
}
