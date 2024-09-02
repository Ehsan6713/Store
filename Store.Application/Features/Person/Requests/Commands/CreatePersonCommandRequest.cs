using MediatR;
using Store.Application.DTOS.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Person.Requests.Commands
{
    public class CreatePersonCommandRequest:IRequest<int>
    {
        public CreatePersonDto CreatePersonDto { get; set; }
    }
}
