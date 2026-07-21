using DemoBlazor.Client.Services.IServices;
using DemoBlazor.Shared;
using System.Net.Http.Json;

namespace DemoBlazor.Client.Services
{
    public class DepartmentService :IDepartmentService
    {
        private readonly HttpClient _httpClient;
        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DepartmentDto>> GetListDepartments()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<List<DepartmentDto>>>("api/Departments/getAll");
            if (result!.Flag)
            {
                return result.Value!;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }
    }
}
