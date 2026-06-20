using DomainLayer.Entities;
using InfraestructureLayer.Contracts;
using InfraestructureLayer.Data;
using InfraestructureLayer.Dto;
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

        public async Task<ServiceResponse> AddAsync(Employee employee)
        {
            try
            {

                _context.Database.SetCommandTimeout(60);

                var check = await _context.Employees
                    .FirstOrDefaultAsync(x => x.Name == employee.Name);


                if (check != null)
                {
                    return new ServiceResponse(false, "Empleado agregado con exito");
                }

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return new ServiceResponse(true, "Empleado creado con exito");
            }
            catch(Exception ex)
            {
                return new ServiceResponse(false, ex.Message);
            }
            
        }

        public async Task<InfraestructureLayer.Dto.ServiceResponse> UpdateAsync(Employee employee)
        {
            var check = await _context.Employees
                .FirstOrDefaultAsync(x => x.Name!.Trim().ToLower() == employee.Name!.Trim().ToLower());

            if (check == null)
            {
                return new ServiceResponse(false, "El empleado no existe");
            }

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return new ServiceResponse(true, "El empleado se actualizo correctamente");

        }
        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return new ServiceResponse(false, "El empleado no existe");
            }

            employee.IsDeleted = true;
            await _context.SaveChangesAsync();

            return new ServiceResponse(true, "El empleado se elimino correctamente");

        }

        public async Task<List<Employee>> GetALLAsync() => await
            _context.Employees.AsNoTracking().ToListAsync();

        public async Task<Employee> GetByIdAsync(int id) => await
            _context.Employees.FindAsync(id);
    }
}
