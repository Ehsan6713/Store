using AutoMapper;
using MediatR;
using Store.Application.Features.Person.Requests.Commands;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Person.Handlers.Commands
{
    public class DeletePersonCommandRequstHandler : IRequestHandler<DeletePersonCommandRequst>
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public DeletePersonCommandRequstHandler(IPersonRepository personRepository,IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }
        public async Task Handle(DeletePersonCommandRequst request, CancellationToken cancellationToken)
        {
            var person=await personRepository.Get(request.Id);
            await personRepository.Delete(person);
        }
    }
}
