using MediatR;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Person.Requests.Commands
{
    public class DeletePersonCommandRequst:IRequest<BaseResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
