using DemoBlazor.Shared;

namespace DemoBlazor.Client.Services.IServices
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetListEmployees();
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<int> Save(EmployeeDto employeeDto);
        Task<int> Edit(EmployeeDto employeeDto);
        Task<bool> Delete(int id);
    }
}
