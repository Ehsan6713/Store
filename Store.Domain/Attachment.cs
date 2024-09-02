using Store.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class Attachment:BaseDomainEntity
    {
        public string Title { get; set; }
        public byte[] Content { get; set; }
        public string Format { get; set; }
    }
}
