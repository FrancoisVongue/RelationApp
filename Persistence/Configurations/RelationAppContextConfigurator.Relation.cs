using Microsoft.EntityFrameworkCore;
using RelationApp.Domain.Models;

namespace Persistence.Configurations
{
    public partial class RelationAppContextConfigurator
    {
        public static void ConfigureRelation(ModelBuilder builder)
        {
            builder.Entity<Relation>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("tblRelation");

                entity.Property(e => e.ArrivalBetween).HasColumnType("datetime");

                entity.Property(e => e.ArrivalBetweenAnd).HasColumnType("datetime");

                entity.Property(e => e.ArrivalName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccount)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BankBic)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CarrierCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChamberOfCommerce)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DebtorNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultPostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultStreet)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureBetween).HasColumnType("datetime");

                entity.Property(e => e.DepartureBetweenAnd).HasColumnType("datetime");

                entity.Property(e => e.DepartureName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DigitalFreightDocumentEmailTemplateId).HasColumnName("DigitalFreightDocumentEMailTemplateId");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("EMailAddress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralLedgerAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imaddress)
                    .HasColumnName("IMAddress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceEmailAddress)
                    .HasColumnName("InvoiceEMailAddress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceGroupByTransportOrderColumnName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceTo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
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

                entity.Property(e => e.PriceListName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PriceListNameForCollecting)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.SendDigitalFreightDocumentsByEmail).HasColumnName("SendDigitalFreightDocumentsByEMail");

                entity.Property(e => e.SendFreightStatusUpdateByEmail).HasColumnName("SendFreightStatusUpdateByEMail");

                entity.Property(e => e.SkypeAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SupplyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VatName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VatNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VendorNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
