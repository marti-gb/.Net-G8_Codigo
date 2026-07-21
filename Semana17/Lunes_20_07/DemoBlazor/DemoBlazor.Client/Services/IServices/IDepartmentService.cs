using DemoBlazor.Shared;

namespace DemoBlazor.Client.Services.IServices
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetListDepartments();
    }
}
