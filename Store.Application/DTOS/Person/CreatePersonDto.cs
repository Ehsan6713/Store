using Store.Application.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Person
{
    public class CreatePersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
    }
}
