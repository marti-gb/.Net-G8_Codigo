using DemoBlazor.Server1.Data;
using DemoBlazor.Server1.Models;
using DemoBlazor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazor.Server1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var responseApi = new ResponseAPI<List<EmployeeDto>>();
            var listEmployees = new List<EmployeeDto>();

            try
            {
                foreach(var item in await _dbContext.Employees.Where(x=>!x.IsDeleted)
                    .Include(x => x.Department).ToListAsync())
                {
                    listEmployees.Add(new EmployeeDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DepartmentId = item.DepartmentId,
                        Salary = item.Salary,
                        DateContract = item.DateContract,
                        DepartmentDto = item.Department != null ? new DepartmentDto
                        {
                            Id = item.Department.Id,
                            Name = item.Department.Name
                        } : null
                    });
                }
                responseApi.Flag = true;
                responseApi.Value = listEmployees;
                responseApi.Message = "OK";
            }
            catch (Exception ex)
            {
                responseApi.Flag= false;
                responseApi.Message= ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var responseApi = new ResponseAPI<EmployeeDto>();
            var employeeDto = new EmployeeDto();

            try
            {
                var employeFromDB = await _dbContext.Employees
                    .Include(x => x.Department) 
                    .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

                if (employeFromDB != null)
                {
                    employeeDto.Id = employeFromDB.Id;
                    employeeDto.Name = employeFromDB.Name;
                    employeeDto.DepartmentId = employeFromDB.DepartmentId;
                    employeeDto.Salary = employeFromDB.Salary;
                    employeeDto.DateContract = employeFromDB.DateContract;

                    employeeDto.DepartmentDto = employeFromDB.Department != null ? new DepartmentDto
                    {
                        Id = employeFromDB.Department.Id,
                        Name = employeFromDB.Department.Name
                    } : null;

                    responseApi.Flag = true;
                    responseApi.Value = employeeDto;
                    responseApi.Message = "OK";
                }
                else
                {
                    responseApi.Flag = false;
                    responseApi.Value = null;
                    responseApi.Message = "Empleado no encontrado";
                }
            }
            catch (Exception ex)
            {
                responseApi.Flag = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save(EmployeeDto employeeDto)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbEmployee = new Employee
                {
                    Name = employeeDto.Name,
                    DepartmentId = employeeDto.DepartmentId,
                    Salary = employeeDto.Salary,
                    DateContract = employeeDto.DateContract,
                };

                _dbContext.Employees.Add(dbEmployee);
                await _dbContext.SaveChangesAsync();

                if(dbEmployee.Id >  0)
                {
                    responseApi.Flag = true;
                    responseApi.Value = dbEmployee.Id;
                    responseApi.Message = "Empleado agregado con exito";
                }
                else
                {
                    responseApi.Flag = false;
                    responseApi.Value = 0;
                    responseApi.Message = "No se pudo guardar el empleado";
                }

            }
            catch (Exception ex)
            {
                responseApi.Flag = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(EmployeeDto employeeDto, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var employeFromDB = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
                if (employeFromDB != null)
                {
                    employeFromDB.Name = employeeDto.Name;
                    employeFromDB.DepartmentId = employeeDto.DepartmentId;
                    employeFromDB.Salary = employeeDto.Salary;
                    employeFromDB.DateContract = employeeDto.DateContract;

                    await _dbContext.SaveChangesAsync();

                    responseApi.Flag = true;
                    responseApi.Value = employeFromDB.Id;
                    responseApi.Message = "Empleado actualizado con exito";
                }
                else
                {
                    responseApi.Flag = false;
                    responseApi.Value = 0;
                    responseApi.Message = "No se pudo actualizar el empleado";
                }

            }
            catch (Exception ex)
            {
                responseApi.Flag = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var employeFromDB = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
                if (employeFromDB != null)
                {
                    employeFromDB.IsDeleted = true;
                    await _dbContext.SaveChangesAsync();

                    responseApi.Flag = true;
                    responseApi.Value = employeFromDB.Id;
                    responseApi.Message = "Empleado eliminado con exito";
                }
                else
                {
                    responseApi.Flag = false;
                    responseApi.Value = 0;
                    responseApi.Message = "No se pudo eliminar el empleado";
                }

            }
            catch (Exception ex)
            {
                responseApi.Flag = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}
