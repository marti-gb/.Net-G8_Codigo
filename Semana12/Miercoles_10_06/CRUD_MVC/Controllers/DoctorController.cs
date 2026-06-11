using CRUD_MVC.Data;
using CRUD_MVC.Models.OneToMany;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC.Controllers
{
    public class DoctorController : Controller
    {
        private readonly AppDbContext _context;
        public DoctorController(AppDbContext context)
        {
            _context = context;
        }
        // GET: OneToManyController
        public async Task<ActionResult> Index()
        {
            var doctors = await _context.Doctors
                .Where(d => !d.IsDeleted)
                .Include(d => d.ListPatients)
                .ToListAsync();

            return View(doctors);
        }

        // GET: OneToManyController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var doctor = await _context.Doctors
                .Include(x => x.ListPatients)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // GET: OneToManyController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OneToManyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: OneToManyController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null || doctor.IsDeleted)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: OneToManyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid && !doctor.IsDeleted)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: OneToManyController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);

            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: OneToManyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                doctor.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
