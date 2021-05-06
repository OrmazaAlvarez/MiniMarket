using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMarketBackEnd.Models;
using System.Collections.Generic;

namespace MiniMarketBackEnd.Persistence.Configuration
{
    public class SupplierConfiguration
    {
        public SupplierConfiguration(EntityTypeBuilder<Supplier> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.SupplierId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Address).IsRequired().HasMaxLength(500);
            entityBuilder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.MailAddress).IsRequired().HasMaxLength(50);
            var suppliers = new List<Supplier>();
                suppliers.Add(new Supplier
                {
                    SupplierId = 1,
                    Name = "Lenin Ormaza",
                    Address = "El Empalme - Guayas - Ecuador",
                    PhoneNumber = "+593987461352",
                    MailAddress = "lenin.ormaza@gmail.com"
                });
            entityBuilder.HasData(suppliers);
        }
    }
}
