using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Common
{
    /// <summary>
    /// Using abstract because avoiding creating a new instance of this class
    /// </summary>
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreatedById { get; set; }
        public Person CreatedBy { get; set; }
    }
}
