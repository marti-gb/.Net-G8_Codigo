using Microservices.FrontEnd.Web.Models;

namespace Microservices.FrontEnd.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
