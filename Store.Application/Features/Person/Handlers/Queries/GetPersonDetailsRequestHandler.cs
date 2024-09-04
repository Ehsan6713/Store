using AutoMapper;
using MediatR;
using Store.Application.DTOS.Person;
using Store.Application.Features.Person.Requests.Queries;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Person.Handlers.Queries
{
    public class GetPersonDetailsRequestHandler : IRequestHandler<GetPersonDetailsRequest, PersonDto>
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public GetPersonDetailsRequestHandler(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }
        public async Task<PersonDto> Handle(GetPersonDetailsRequest request, CancellationToken cancellationToken)
        {
            var person = await personRepository.Get(request.Id);
            return mapper.Map<PersonDto>(person);
        }
    }
}
