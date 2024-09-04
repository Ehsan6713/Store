using AutoMapper;
using MediatR;
using Store.Application.DTOS.OrderDetail;
using Store.Application.Features.OrderDetail.Requests.Queries;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.OrderDetail.Handlers.Queries
{
    public class GetOrderDetailDetailRequestHandler : IRequestHandler<GetOrderDetailDetailRequest, OrderDetailDto>
    {
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IMapper mapper;

        public GetOrderDetailDetailRequestHandler(IOrderDetailRepository orderDetailRepository,IMapper mapper)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.mapper = mapper;
        }
        public async Task<OrderDetailDto> Handle(GetOrderDetailDetailRequest request, CancellationToken cancellationToken)
        {
            var orderdetail = await orderDetailRepository.Get(request.Id);
            return mapper.Map<OrderDetailDto>(orderdetail);
        }
    }
}
