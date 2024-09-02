using AutoMapper;
using MediatR;
using Store.Application.DTOS.OrderDetail;
using Store.Application.Features.OrderDetail.Requests.Queries;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.OrderDetail.Handlers.Queries
{
    public class GetOrderDetailRequestHandler : IRequestHandler<GetOrderDetailRequest, List<OrderDetailDto>>
    {
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IMapper mapper;

        public GetOrderDetailRequestHandler(IOrderDetailRepository orderDetailRepository,IMapper mapper)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.mapper = mapper;
        }
        public async Task<List<OrderDetailDto>> Handle(GetOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var orderDetails =await orderDetailRepository.GetAll();
            return mapper.Map<List<OrderDetailDto>>(orderDetails);
        }
    }
}
