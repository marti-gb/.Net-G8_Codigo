using Microservices.FrontEnd.Web.Models;
using Microservices.FrontEnd.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Microservices.FrontEnd.Web.Utility.SD;

namespace Microservices.FrontEnd.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("Microservices1");

                //--------------------Request----------------------------------------
                HttpRequestMessage requestMessage = new HttpRequestMessage();
                requestMessage.Headers.Add("Accept", "application/json");

                //Token

                requestMessage.RequestUri = new Uri(requestDto.Url);

                requestMessage.Method = requestDto.ApiType switch
                {
                    ApiType.GET => HttpMethod.Get,
                    ApiType.POST => HttpMethod.Post,
                    ApiType.PUT => HttpMethod.Put,
                    ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get
                };

                if(requestDto.Data != null )
                {
                    var jsonData = JsonConvert.SerializeObject(requestDto.Data);
                    requestMessage.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                }

                //----------------------Response-------------------------------------
                HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    var errorContent = await responseMessage.Content.ReadAsStringAsync();
                }

                switch(responseMessage.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new ResponseDto { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new ResponseDto { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new ResponseDto { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new ResponseDto { IsSuccess = false, Message = "Internal Server Error" };
                    case HttpStatusCode.BadRequest:
                        return new ResponseDto { IsSuccess = false, Message = "Bad Request" };
                    default:
                        var content = await responseMessage.Content.ReadAsStringAsync();
                        var responseDto = JsonConvert.DeserializeObject<ResponseDto>(content);
                        return responseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto { IsSuccess = false, Message= ex.Message };
                return dto;
            }
        }
    }
}
