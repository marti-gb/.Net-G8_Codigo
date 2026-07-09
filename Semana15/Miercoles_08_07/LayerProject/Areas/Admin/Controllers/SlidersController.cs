using LayerProject.DataAccess.Data.Repository.IRepository;
using LayerProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LayerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SlidersController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult Create(Slider slider)
        {
            string mainRoute = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if(files.Count > 0)
            {
                string nameFile = Guid.NewGuid().ToString();
                string upload = Path.Combine(mainRoute, @"images\sliders");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStreams = new FileStream(Path.Combine(upload, nameFile + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStreams);
                }

                slider.UrlImage = @"\images\sliders\" + nameFile + extension;

                _unitOfWork.ISliderRepository.Add(slider);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(slider);
        }
        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            else
            {
                Slider slider = new();
                slider = _unitOfWork.ISliderRepository.GetById(id);
                if(slider != null)
                {
                    return View(slider);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            string mainRoute = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var sliderFromDB = _unitOfWork.ISliderRepository.GetById(slider.Id);

            if(files.Count > 0)
            {
                string nameFile = Guid.NewGuid().ToString();
                string upload = Path.Combine(mainRoute, @"images\sliders");
                var extension = Path.GetExtension(files[0].FileName);

                //Comprobamos que la imagen existe
                var oldPath = Path.Combine(mainRoute, sliderFromDB.UrlImage.TrimStart('\\'));
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                //Nuvamente subimos la imagen
                using(var fileStream = new FileStream(Path.Combine(upload, nameFile+extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                slider.UrlImage = @"\images\sliders\" + nameFile + extension;

                _unitOfWork.ISliderRepository.Update(slider);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                slider.UrlImage = sliderFromDB.UrlImage;
            }

            _unitOfWork.ISliderRepository.Update(slider);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        #endregion


        #region Call to API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = _unitOfWork.ISliderRepository.GetAll(x=>!x.IsDeleted)});
        }
        #endregion
    }
}
