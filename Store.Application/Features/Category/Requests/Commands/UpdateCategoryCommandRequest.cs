using MediatR;
using Store.Application.DTOS.Category;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Category.Requests.Commands
{
    public class UpdateCategoryCommandRequest:IRequest<BaseResponse<Unit>>
    {
        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }
}
