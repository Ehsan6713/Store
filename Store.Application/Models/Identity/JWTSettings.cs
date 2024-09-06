using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Models.Identity
{
    public class JWTSettings
    {
        public string Audience { get; set; }
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
