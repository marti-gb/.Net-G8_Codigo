using DomainLayer.Entities;
using InfraestructureLayer.Dto;
using System.Net.Http.Json;

namespace ApplicationLayer.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ServiceResponse> AddAsync(Employee employee)
        {
            try
            {
                var data = await _httpClient.PostAsJsonAsync("api/Employees", employee);
                if (data.IsSuccessStatusCode)
                {
                    var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
                    return response;
                }
                else
                {
                    return new ServiceResponse(false, "Error in response from server.");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, $"Exception: {ex.Message}");
            }

        }

        public async Task<ServiceResponse> UpdateAsync(Employee employee)
        {
            var data = await _httpClient.PutAsJsonAsync("api/Employees", employee);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response;
        }
        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var data = await _httpClient.DeleteAsync($"api/Employees/{id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var list = await _httpClient.GetFromJsonAsync<List<Employee>>("api/Employees");
            return list;
        }
            

        public async Task<Employee> GetByIdAsync(int id) =>
            await _httpClient.GetFromJsonAsync<Employee>($"api/Employees/{id}");

        
    }
}
