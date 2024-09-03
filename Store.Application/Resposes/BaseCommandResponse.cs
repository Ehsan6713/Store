using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Resposes
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
    public class BaseResponse<T> : BaseResponse
    {
        public BaseResponse() : base()
        {
        }
        public T Data { get; set; }
    }
}
