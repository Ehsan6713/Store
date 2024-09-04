using AutoMapper;
using MediatR;
using Store.Application.Exceptions;
using Store.Application.Features.Person.Requests.Commands;
using Store.Application.Contracts.Persistence;
using Store.Domain;
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
            if (person == null)
            {
                throw new NotFoundException(nameof(Domain.Person), request.Id);
            }
            await personRepository.Delete(person);
        }
    }
}
