using AutoMapper;
using MediatR;
using Store.Application.DTOS.Person;
using Store.Application.Features.Person.Requests.Queries;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Person.Handlers.Queries
{
    public class GetPersonListRequestHandler : IRequestHandler<GetPersonListRequest, List<PersonDto>>
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public GetPersonListRequestHandler(IPersonRepository personRepository,IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }
        public async Task<List<PersonDto>> Handle(GetPersonListRequest request, CancellationToken cancellationToken)
        {
            var people =await personRepository.GetAll();
            return mapper.Map<List<PersonDto>>(people);
        }
    }
}
