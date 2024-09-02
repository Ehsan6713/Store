using MediatR;
using Store.Application.DTOS.Brand;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Brands.Requests.Queries
{
    public class GetBrandListRequest:IRequest<List<BrandDto>>
    {
    }
}
