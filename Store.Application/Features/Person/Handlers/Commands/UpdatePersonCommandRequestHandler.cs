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
    public class UpdatePersonCommandRequestHandler : IRequestHandler<UpdatePersonCommandRequest, Unit>
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public UpdatePersonCommandRequestHandler(IPersonRepository personRepository,IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            var person =await personRepository.Get(request.UpdatePersonDto.Id);
            mapper.Map(request.UpdatePersonDto, person);
            await personRepository.Update(person);
            return Unit.Value;
        }
    }
}
