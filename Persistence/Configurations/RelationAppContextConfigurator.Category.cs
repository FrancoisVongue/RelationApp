using Microsoft.EntityFrameworkCore;
using RelationApp.Domain.Models;

namespace Persistence.Configurations
{
    internal partial class RelationAppContextConfigurator
    {
        public static void ConfigureCategory(ModelBuilder builder)
        {
            builder.Entity<Category>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblCategory");

                entity.Property(e => e.Code1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code6)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp1).HasColumnType("datetime");

                entity.Property(e => e.Timestamp2).HasColumnType("datetime");

                entity.Property(e => e.Timestamp3).HasColumnType("datetime");

                entity.Property(e => e.Timestamp4).HasColumnType("datetime");
            });
        }
    }
}
