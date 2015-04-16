namespace KSDGControllerApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using KSDGControllerApp.Models;

    public partial class GuestMessageDbContext : DbContext
    {
        public GuestMessageDbContext() : base("name=GuestMessageDb")
        {
        }

        public virtual DbSet<GuestMessage> GuestMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var gmsgTable = modelBuilder.Entity<GuestMessage>();

            gmsgTable.Property(m => m.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            gmsgTable.Property(m => m.DatePosted)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
}
