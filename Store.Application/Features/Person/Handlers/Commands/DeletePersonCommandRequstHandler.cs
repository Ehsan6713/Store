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
using Store.Application.Resposes;

namespace Store.Application.Features.Person.Handlers.Commands
{
    public class DeletePersonCommandRequstHandler : IRequestHandler<DeletePersonCommandRequst, BaseResponse<Unit>>
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public DeletePersonCommandRequstHandler(IPersonRepository personRepository,IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(DeletePersonCommandRequst request, CancellationToken cancellationToken)
        {
            var respons = new BaseResponse<Unit>();
            var person=await personRepository.Get(request.Id);
            if (person == null)
            {
                respons.Success = false;
                respons.Errors.Add($"Not Found Id {request.Id}");
                respons.Message = "Not Found";
            }
            else
            {
                await personRepository.Delete(person);
                respons.Data = Unit.Value;
            }
            return respons;
        }
    }
}
