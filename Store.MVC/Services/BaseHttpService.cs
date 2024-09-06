using Hanssens.Net;
using Store.MVC.Contracts;
using Store.MVC.Services.Base;
using System.Net.Http.Headers;

namespace Store.MVC.Services
{
    public class BaseHttpService
    {
        protected readonly ILocalStorageService storage;
        protected readonly IClient client;

        public BaseHttpService(ILocalStorageService storage, IClient client)
        {
            this.storage = storage;
            this.client = client;
        }
        protected Response<T> ConvertApiException<T>(ApiException exception)
        {
            switch(exception.StatusCode)
            {
                case 400:
                    return new Response<T>() { ValidationErrors = exception.Response, Message = "Validation Errors", Success = false };
                case 404:
                    return new Response<T>() { Message = "Not Found ", Success = false };
                default:
                    return new Response<T>() { Message = "there is a error ", Success = false };

            }
        }
        protected void AddBearerToken()
        {
            if (storage.Exists("token"))
            {
                client.HttpClient.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", storage.GetStorageValue<string>("token"));
            }
        }
    }
}
