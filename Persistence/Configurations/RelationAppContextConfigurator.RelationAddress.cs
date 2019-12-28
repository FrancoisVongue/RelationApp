using Microsoft.EntityFrameworkCore;
using RelationApp.Domain.Models;

namespace Persistence.Configurations
{
    internal partial class RelationAppContextConfigurator
    {
        public static void ConfigureRelationAddress(ModelBuilder builder)
        {
            builder.Entity<RelationAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblRelationAddress");

                entity.Property(e => e.Building)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberSuffix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
