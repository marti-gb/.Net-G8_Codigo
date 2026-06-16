using DomainLayer.Entities;
using InfraestructureLayer.Contracts;
using InfraestructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AplicationDbContext _context;
        public EmployeeRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InfraestructureLayer.Dto.ServiceResponse> AddAsync(Employee employee)
        {
            var check = await _context.Employees
                .FirstOrDefaultAsync(x => x.Name!.Trim().ToLower() == employee.Name!.Trim().ToLower());

            if (check != null)
            {
                return new InfraestructureLayer.Dto.ServiceResponse(false, "El empleado ya existe, cree otro");
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return new InfraestructureLayer.Dto.ServiceResponse(true, "Empleado creado con exito");
        }

        public async Task<InfraestructureLayer.Dto.ServiceResponse> UpdateAsync(Employee employee)
        {
            var check = await _context.Employees
                .FirstOrDefaultAsync(x => x.Name!.Trim().ToLower() == employee.Name!.Trim().ToLower());

            if (check == null)
            {
                return new InfraestructureLayer.Dto.ServiceResponse(false, "El empleado no existe");
            }

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return new InfraestructureLayer.Dto.ServiceResponse(true, "El empleado se actualizo correctamente");
        }
        public async Task<InfraestructureLayer.Dto.ServiceResponse> DeleteAsync(int id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return new InfraestructureLayer.Dto.ServiceResponse(false, "El empleado no existe");
            }

            employee.IsDeleted = true;
            await _context.SaveChangesAsync();

            return new InfraestructureLayer.Dto.ServiceResponse(true, "El empleado se elimino correctamente");

        }

        public async Task<List<Employee>> GetALLAsync() => await
            _context.Employees.AsNoTracking().ToListAsync();

        public async Task<Employee> GetByIdAsync(int id) => await
            _context.Employees.FindAsync(id);
    }
}
