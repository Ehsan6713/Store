using Store.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class Person: BaseDomainEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
    }
}
