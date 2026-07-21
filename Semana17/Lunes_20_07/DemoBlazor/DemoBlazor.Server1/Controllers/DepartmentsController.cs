using DemoBlazor.Server1.Data;
using DemoBlazor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazor.Server1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var responseApi = new ResponseAPI<List<DepartmentDto>>();
            var listDepartmentsDto = new List<DepartmentDto>();

            try
            {
                foreach (var item in await _dbContext.Departments.Where(x => !x.IsDeleted).ToListAsync())
                {
                    listDepartmentsDto.Add(new DepartmentDto
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }

                responseApi.Flag = true;
                responseApi.Value = listDepartmentsDto;
                responseApi.Message = "OK";
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
