using DomainLayer.Entities;
using InfraestructureLayer.Dto;

namespace ApplicationLayer.Service
{
    public interface IEmployeeService
    {
        Task<ServiceResponse> AddAsync(Employee employee);
        Task<ServiceResponse> UpdateAsync(Employee employee);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<Employee> GetByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
    }
}
