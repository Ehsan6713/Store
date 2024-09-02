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
    public class CreatePersonCommandRequestHandler : IRequestHandler<CreatePersonCommandRequest, int>
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public CreatePersonCommandRequestHandler(IPersonRepository personRepository,IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            var person = mapper.Map<Domain.Person>(request.CreatePersonDto);
            await personRepository.Add(person);
            return person.Id;
        }
    }
}
