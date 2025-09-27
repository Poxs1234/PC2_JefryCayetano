using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pc2_Progra.Data;
using Pc2_Progra.Models;

namespace Pc2_Progra.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Catalogo
        public async Task<IActionResult> Index(string? ciudad, string? tipo, decimal? precioMin, decimal? precioMax, int? dormitorios, int page = 1, int pageSize = 5)
        {
            var query = _context.Inmuebles.Where(i => i.Activo).AsQueryable();

            // Filtros
            if (!string.IsNullOrEmpty(ciudad))
                query = query.Where(i => i.Ciudad.Contains(ciudad));

            if (!string.IsNullOrEmpty(tipo))
                query = query.Where(i => i.Tipo == tipo);

            if (precioMin.HasValue && precioMin >= 0)
                query = query.Where(i => i.Precio >= precioMin.Value);

            if (precioMax.HasValue && precioMax >= 0)
                query = query.Where(i => i.Precio <= precioMax.Value);

            if (precioMin.HasValue && precioMax.HasValue && precioMin > precioMax)
                ModelState.AddModelError("", "El precio mínimo no puede ser mayor que el máximo.");

            if (dormitorios.HasValue && dormitorios >= 0)
                query = query.Where(i => i.Dormitorios >= dormitorios.Value);

            // Paginación
            var total = await query.CountAsync();
            var inmuebles = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            ViewBag.Page = page;
            ViewBag.TotalPages = (int)Math.Ceiling(total / (double)pageSize);

            return View(inmuebles);
        }

        // GET: /Catalogo/Detalle/5
        public async Task<IActionResult> Detalle(int id)
        {
            var inmueble = await _context.Inmuebles.FindAsync(id);
            if (inmueble == null) return NotFound();

            return View(inmueble);
        }
    }
}
