using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;
using RelationApp.Domain.Models;

namespace RelationApp.Persistence.Contexts
{
    public partial class RelationAppContext : DbContext
    {
        public RelationAppContext()
        {
        }

        public RelationAppContext(DbContextOptions<RelationAppContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<AddressType> AddressType { get; set; }
        
        public virtual DbSet<Category> Category { get; set; }
        
        public virtual DbSet<Country> Country { get; set; }
        
        public virtual DbSet<Relation> Relations { get; set; }
        
        public virtual DbSet<RelationAddress> RelationAddress { get; set; }
        
        public virtual DbSet<RelationCategory> RelationCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RelationAppContextConfigurator.ConfigureAddressType(modelBuilder);
            
            RelationAppContextConfigurator.ConfigureCategory(modelBuilder);
            
            RelationAppContextConfigurator.ConfigureCountry(modelBuilder);
            
            RelationAppContextConfigurator.ConfigureRelation(modelBuilder);
            
            RelationAppContextConfigurator.ConfigureRelationAddress(modelBuilder);
            
            RelationAppContextConfigurator.CreateRelationCategory(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
