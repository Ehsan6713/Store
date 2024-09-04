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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(new Person { Id=1,FirstName = "Javad", LastName = "Sagheb", CreateTime = DateTime.Now, Gender = 1 });
            //builder
            //      .HasOne(p => p.CreatedBy)
            //      .WithMany()
            //      .HasForeignKey(p => p.CreatedById)
            //      .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
