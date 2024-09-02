using Store.Application.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Category
{
    public class UpdateCategoryDto:BaseDto
    {
        public string Name { get; set; }
    }
}
