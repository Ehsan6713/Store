using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = "eb165788-0707-4f81-a157-48cf13f802a2",
                    UserId = "b18ed074-f0e3-460a-938d-cb13430cb252"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "6ef99fcc-bf39-44b9-b416-43515fde528e",
                    UserId = "f204b234-3e63-4251-ac72-31a94e25cea2"
                });
        }
    }
}
