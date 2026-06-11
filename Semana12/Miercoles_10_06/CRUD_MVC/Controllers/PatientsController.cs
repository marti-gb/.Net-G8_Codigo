using CRUD_MVC.Data;
using CRUD_MVC.Models.OneToMany;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace CRUD_MVC.Controllers
{
    public class PatientsController : Controller
    {
        private readonly AppDbContext _context;
        public PatientsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: PatientsController
        public async Task<IActionResult> Index()
        {
            var patients = await _context.Patients
                .Where(p => !p.IsDeleted)
                .Include(x => x.Doctor)
                .ToListAsync();

            return View(patients);
        }

        // GET: PatientsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientsController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: PatientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: PatientsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
