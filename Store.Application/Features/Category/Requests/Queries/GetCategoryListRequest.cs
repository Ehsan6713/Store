using MediatR;
using Store.Application.DTOS.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Category.Requests.Queries
{
    public class GetCategoryListRequest:IRequest<List<CategoryDto>>
    {
    }
}
