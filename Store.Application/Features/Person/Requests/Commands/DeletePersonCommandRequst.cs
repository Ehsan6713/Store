using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Person.Requests.Commands
{
    public class DeletePersonCommandRequst:IRequest
    {
        public int Id { get; set; }
    }
}
