using AutoMapper;
using MediatR;
using Store.Application.Exceptions;
using Store.Application.Features.OrderDetail.Requests.Commands;
using Store.Application.Contracts.Persistence;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Resposes;

namespace Store.Application.Features.OrderDetail.Handlers.Commands
{
    public class DeleteOrderDetailCommandRequestHandler : IRequestHandler<DeleteOrderDetailCommandRequest, BaseResponse<Unit>>
    {
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IMapper mapper;

        public DeleteOrderDetailCommandRequestHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(DeleteOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var respons = new BaseResponse<Unit>();
            var orderDetail = await orderDetailRepository.Get(request.Id);
            if (orderDetail == null)
            {
                respons.Success = false;
                respons.Errors.Add($"Not Found Id {request.Id}");
                respons.Message = "Not Found";
            }
            else
            {
                await orderDetailRepository.Delete(orderDetail);
                respons.Data = Unit.Value;
            }
            return respons;
        }
    }
}
