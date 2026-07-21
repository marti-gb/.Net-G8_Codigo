using DemoBlazor.Client.Services.IServices;
using DemoBlazor.Shared;
using System.Net.Http.Json;

namespace DemoBlazor.Client.Services
{
    public class EmployeeService :IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<EmployeeDto>>($"api/Employees/getById/{id}");
            if (result!.Flag)
            {
                return result.Value!;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<List<EmployeeDto>> GetListEmployees()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<List<EmployeeDto>>>("api/Employees/getAll");
            if (result!.Flag)
            {
                return result.Value!;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<int> Save(EmployeeDto employeeDto)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Employees/save", employeeDto);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.Flag)
            {
                return response.Value!;
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        public async Task<int> Edit(EmployeeDto employeeDto)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Employees/edit/{employeeDto.Id}", employeeDto);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.Flag)
            {
                return response.Value!;
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Employees/delete/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.Flag)
            {
                return response.Flag!;
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

    }
}
