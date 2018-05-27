namespace ado4.mcs
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class mcs : DbContext
    {
        public mcs()
            : base("name=mcs")
        {
        }

        public virtual DbSet<AccessTab> AccessTab { get; set; }
        public virtual DbSet<AccessUser> AccessUser { get; set; }
        public virtual DbSet<newEquipment> newEquipment { get; set; }
        public virtual DbSet<TablesManufacturer> TablesManufacturer { get; set; }
        public virtual DbSet<TablesModel> TablesModel { get; set; }
        public virtual DbSet<TablesSNPrefix> TablesSNPrefix { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TablesManufacturer>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesManufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TablesModel>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TablesSNPrefix>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesSNPrefix)
                .WillCascadeOnDelete(false);
        }
    }
}
