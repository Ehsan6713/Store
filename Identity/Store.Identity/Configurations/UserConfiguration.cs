using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser()
                {
                    Id = "b18ed074-f0e3-460a-938d-cb13430cb252",
                    FirstName = "javad",
                    LastName = "sagheb",
                    Email = "sagheb2012@yahoo.com",
                    UserName= "sagheb2012@yahoo.com",
                    NormalizedUserName="SAGHEB2012@YAHOO.COM",
                    NormalizedEmail= "SAGHEB2012@YAHOO.COM",
                    PasswordHash=hasher.HashPassword(null,"!@#$%^")
                },
                new ApplicationUser()
                {
                    Id = "f204b234-3e63-4251-ac72-31a94e25cea2",
                    FirstName = "user",
                    LastName = "usersystem",
                    Email = "user@yahoo.com",
                    UserName = "user@yahoo.com",
                    NormalizedUserName = "USER@YAHOO.COM",
                    NormalizedEmail = "USER@YAHOO.COM",
                    PasswordHash = hasher.HashPassword(null, "!@#$%^")
                }
                );
        }
    }
}
