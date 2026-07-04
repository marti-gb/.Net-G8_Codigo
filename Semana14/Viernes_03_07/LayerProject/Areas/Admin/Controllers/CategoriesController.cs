using LayerProject.DataAccess.Data.Repository.IRepository;
using LayerProject.Models;
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

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.ICategoryRepository.Add(category);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(category);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            else
            {
                Category category = new Category();
                category = _unitOfWork.ICategoryRepository.GetById(id);
                if(category != null)
                {
                    return View(category);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ICategoryRepository.Update(category);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(category);
        }
        #endregion

        #region Call Apis
        [HttpGet]
        public IActionResult GetALL()
        {
            return Json(new { data = _unitOfWork.ICategoryRepository.GetAll(x => !x.IsDeleted) });
        }
        #endregion
    }
}
