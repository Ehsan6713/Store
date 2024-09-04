using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Configurations.Entities
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand() { Id = 1, CreateTime = DateTime.Now, Name = "Samsung" },
                new Brand() { Id = 2, CreateTime = DateTime.Now, Name = "Lg" },
                new Brand() { Id = 3, CreateTime = DateTime.Now, Name = "IPhone" },
                new Brand() { Id = 4, CreateTime = DateTime.Now, Name = "Lenovo" },
                new Brand() { Id = 5, CreateTime = DateTime.Now, Name = "HP" }
                );
        }
    }
}
