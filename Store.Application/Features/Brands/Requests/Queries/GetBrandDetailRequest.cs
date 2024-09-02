using MediatR;
using Store.Application.DTOS.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Brands.Requests.Queries
{
    public class GetBrandDetailRequest:IRequest<BrandDto>
    {
        public int Id { get; set; }
    }
}
