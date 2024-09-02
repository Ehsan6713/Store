using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Category.Requests.Commands
{
    public class DeleteCategoryCommandRequest:IRequest
    {
        public int Id { get; set; }
    }
}
