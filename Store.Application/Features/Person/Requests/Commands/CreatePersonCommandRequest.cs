using MediatR;
using Store.Application.DTOS.Person;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Person.Requests.Commands
{
    public class CreatePersonCommandRequest:IRequest<BaseResponse<int>>
    {
        public CreatePersonDto CreatePersonDto { get; set; }
    }
}
