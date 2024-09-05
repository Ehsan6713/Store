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
    public class CreateCategoryCommandRequest:IRequest<BaseResponse<int>>
    {
        public CreateCategoryDto CreateCategoryDto { get; set; }
    }
}
