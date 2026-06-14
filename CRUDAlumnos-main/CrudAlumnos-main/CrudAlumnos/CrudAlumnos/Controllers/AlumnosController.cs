using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudAlumnos.Data;
using CrudAlumnos.Models;

namespace CrudAlumnos.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly AppDbContext _context;

        public AlumnosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Alumnos
        public async Task<IActionResult> Index()
        {
            var alumnos = await _context.Alumnos
                .Include(a => a.Ciudad)
                .OrderBy(a => a.Apellido)
                .ToListAsync();
            return View(alumnos);
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var alumno = await _context.Alumnos
                .Include(a => a.Ciudad)
                .FirstOrDefaultAsync(m => m.CodAlumno == id);

            if (alumno == null) return NotFound();

            return View(alumno);
        }

        // GET: Alumnos/Create
        public IActionResult Create()
        {
            CargarCiudades();
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Apellido,Edad,Sexo,CodCiudad")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Alumno registrado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            CargarCiudades(alumno.CodCiudad);
            return View(alumno);
        }

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null) return NotFound();

            CargarCiudades(alumno.CodCiudad);
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodAlumno,Nombre,Apellido,Edad,Sexo,CodCiudad")] Alumno alumno)
        {
            if (id != alumno.CodAlumno) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                    TempData["Mensaje"] = "Alumno actualizado correctamente.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.CodAlumno)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            CargarCiudades(alumno.CodCiudad);
            return View(alumno);
        }

        // GET: Alumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var alumno = await _context.Alumnos
                .Include(a => a.Ciudad)
                .FirstOrDefaultAsync(m => m.CodAlumno == id);

            if (alumno == null) return NotFound();

            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Alumno eliminado correctamente.";
            }
            return RedirectToAction(nameof(Index));
        }

        // Vista parcial de Ciudades
        public IActionResult ListaCiudades()
        {
            var ciudades = _context.Ciudades.OrderBy(c => c.Nombre).ToList();
            return PartialView("_ListaCiudades", ciudades);
        }

        private bool AlumnoExists(int id) =>
            _context.Alumnos.Any(e => e.CodAlumno == id);

        private void CargarCiudades(int? selectedId = null)
        {
            ViewBag.CodCiudad = new SelectList(
                _context.Ciudades.OrderBy(c => c.Nombre),
                "CodCiudad", "Nombre", selectedId);
        }
    }
}
