using Microsoft.EntityFrameworkCore;
using RelationApp.Domain.Models;

namespace Persistence.Configurations
{
    public partial class RelationAppContextConfigurator
    {
        public static void CreateRelationCategory(ModelBuilder builder)
        {
            builder.Entity<RelationCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblRelationCategory");
            });
        }
    }
}
