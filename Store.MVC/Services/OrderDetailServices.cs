using AutoMapper;
using Store.MVC.Contracts;
using Store.MVC.Models.Brands;
using Store.MVC.Models.CategoryViewModels;
using Store.MVC.Models.OrderDetailViewModels;
using Store.MVC.Services;
using Store.MVC.Services.Base;

public class OrderDetailServices : BaseHttpService, IOrderDetailServices
{
    private readonly IMapper mapper;

    public OrderDetailServices(IClient client, ILocalStorageService localStorageService, IMapper mapper) : base(localStorageService, client)
    {
        this.mapper = mapper;
    }

    public async Task<Response<int>> Create(OrderDetailVM record)
    {
        var response = new Response<int>();
        var OrderDetailDto = mapper.Map<CreateOrderDetailDto>(record);
        AddBearerToken();
        var responseApi = await client.OrderDetailPOSTAsync(OrderDetailDto);
        response.Message = responseApi.Message;
        response.Success = responseApi.Success;
        if (responseApi.Errors != null)
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
        var responseApi = await client.OrderDetailDELETEAsync(id);
        response.Message = responseApi.Message;
        response.Success = responseApi.Success;
        if (responseApi.Errors != null)
            foreach (var item in responseApi.Errors)
            {
                response.ValidationErrors += item + Environment.NewLine;
            }
        return response;
    }

    public async Task<OrderDetailVM> Get(int id)
    {
        AddBearerToken();
        var OrderDetailDto = await client.OrderDetailGETAsync(id);
        return mapper.Map<OrderDetailVM>(OrderDetailDto);
    }

    public async Task<List<OrderDetailVM>> GetAll()
    {
        AddBearerToken();
        var lst = await client.OrderDetailAllAsync();
        return mapper.Map<List<OrderDetailVM>>(lst);
    }

    public async Task<Response<int>> Update(int id, OrderDetailVM record)
    {
        var response = new Response<int>();
        var OrderDetailDto = mapper.Map<UpdateOrderDetailDto>(record);
        AddBearerToken();
        var responseApi = await client.OrderDetailPUTAsync(id, OrderDetailDto);
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

