using LayerProject.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LayerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
