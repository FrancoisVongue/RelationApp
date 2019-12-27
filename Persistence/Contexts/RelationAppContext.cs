using Microsoft.EntityFrameworkCore;
using Persistence.ContextConfigurators;
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
            RelationAppConfigurator.ConfigureAddressType(modelBuilder);
            
            RelationAppConfigurator.ConfigureCategory(modelBuilder);
            
            RelationAppConfigurator.ConfigureCountry(modelBuilder);
            
            RelationAppConfigurator.ConfigureRelation(modelBuilder);
            
            RelationAppConfigurator.ConfigureRelationAddress(modelBuilder);
            
            RelationAppConfigurator.CreateRelationCategory(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
