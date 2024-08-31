﻿using Store.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class Category: BaseDomainEntity
    {
        public string Name { get; set; }
    }
}
