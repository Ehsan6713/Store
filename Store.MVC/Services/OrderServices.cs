using AutoMapper;
using Store.MVC.Contracts;
using Store.MVC.Models.Brands;
using Store.MVC.Models.OrderViewModels;
using Store.MVC.Services.Base;

namespace Store.MVC.Services
{
    public class OrderServices : BaseHttpService, IOrderServices
    {
        private readonly IMapper mapper;

        public OrderServices(IClient client, ILocalStorageService localStorageService, IMapper mapper) : base(localStorageService, client)
        {
            this.mapper = mapper;
        }

        public async Task<Response<int>> Create(OrderVM record)
        {
            var response = new Response<int>();
            var OrderDto = mapper.Map<CreateOrderDto>(record);
            AddBearerToken();
            var responseApi = await client.OrderPOSTAsync(OrderDto);
            response.Message = responseApi.Message;
            response.Success = responseApi.Success;
            foreach (var item in responseApi.Errors)
            {
                response.ValidationErrors += item + Environment.NewLine;
            }
            return response;
        }

        public async Task<Response<int>> Delete(int id)
        {
            var response = new Response<int>();
            AddBearerToken();
            var responseApi = await client.OrderDELETEAsync(id);
            response.Message = responseApi.Message;
            response.Success = responseApi.Success;
            if (responseApi.Errors != null)
                foreach (var item in responseApi.Errors)
            {
                response.ValidationErrors += item + Environment.NewLine;
            }
            return response;
        }

        public async Task<OrderVM> Get(int id)
        {
            AddBearerToken();
            var OrderDto = await client.OrderGETAsync(id);
            return mapper.Map<OrderVM>(OrderDto.Data);
        }

        public async Task<List<OrderVM>> GetAll()
        {
            AddBearerToken();
            var lst = await client.OrderAllAsync();
            return mapper.Map<List<OrderVM>>(lst);
        }

        public async Task<Response<int>> Update(int id, OrderVM record)
        {
            var response = new Response<int>();
            var OrderDto = mapper.Map<UpdateOrderDto>(record);
            AddBearerToken();
            var responseApi = await client.OrderPUTAsync(id, OrderDto);
            response.Message = responseApi.Message;
            response.Success = responseApi.Success;
            if (responseApi.Errors != null)
                foreach (var item in responseApi.Errors)
            {
                response.ValidationErrors += item + Environment.NewLine;
            }
            return response;
        }
    }
}
