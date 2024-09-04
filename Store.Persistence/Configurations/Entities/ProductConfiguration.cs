using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Configurations.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder
                  .HasOne(p => p.Brand)
                  .WithMany()
                  .HasForeignKey(p => p.BrandId)
                  .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new Product() { Id = 1, CreateTime = DateTime.Now, Title = "HP i5", CategoryId = 2, BrandId = 5, Description = "Processor: Intel Core i5-1235U, 10 x 1.30 GHz with Turbo Boost up to 10 x 4.40 GHz\r\nDisplay: 39 cm (15.6 inches), anti-glare, 1920 x 1080 pixels Full HD IPS\r\nMemory: 16GB DDR4 RAM Hard Drive: 1000GB SSD\r\nOperating system: Windows 11\r\nFeatures: Full HD display, Intel UHD graphics, HDMI, card reader, no drive, USB Type-C" },
                new Product() { Id = 2, CreateTime = DateTime.Now, Title = "s24", CategoryId = 1, BrandId = 1, Description = "For worry-free use: free warranty extension to 3 years - valid for customers who are resident in Germany\r\nEverything from your smartphone, all with AI: With the Galaxy S24 Ultra, you can easily edit photos, interpret calls in real time, and turn your notes into a clear summary¹ ² ³ ⁴.\r\nHigh resistance thanks to titanium: robustness, scratch resistance, water and dust protection thanks to Corning Gorilla Armor, the Galaxy S24 Ultra is ready for adventure, write, type and navigate with the integrated S Pen on the flat display\r\n200MP details that compete with reality: High resolution and AI processing, detects objects and reduces noise, zoom in the action, even at night - thanks to 1.6 times larger pixels and tele-OIS with larger angle6 8 / 9\r\nMobile gameplay: Fast computing power and almost twice the cooling system of the S23 Ultra – for a smooth graphics experience, high capacity battery and high energy efficiency for long gaming sessions6 ¹⁰ ¹¹ ¹ ¹²\r\nA bright adaptive Dynamic AMOLED display: 2,600 nits peak brightness, Redesigned Vision Booster improves contrast and colour representation for an impressive experience, reduced reflections and improved optical clarity thanks to Corning Gorilla Armor" }
                );
        }
    }
}
