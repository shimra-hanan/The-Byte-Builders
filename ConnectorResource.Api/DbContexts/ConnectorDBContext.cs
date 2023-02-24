using ConnectorResource.Api.Entities;
using ConnectorResource.Api.Enums;
using ConnectorResource.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectorResource.Api.DbContextw
{
    public class ConnectorDBContext: DbContext
    {
        public ConnectorDBContext(DbContextOptions<ConnectorDBContext> options) : base(options) { }

        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pharmacy>().HasQueryFilter(r => r.RecordState == RecordState.Active);
            builder.Entity<Medicine>().HasQueryFilter(r => r.RecordState == RecordState.Active);
            builder.Entity<Locations>().HasQueryFilter(r => r.RecordState == RecordState.Active);
            builder.Entity<Inventory>().HasQueryFilter(r => r.RecordState == RecordState.Active);
        }
    }
}
