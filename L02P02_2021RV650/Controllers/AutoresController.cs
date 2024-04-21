using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L02P02_2021RV650.Models;

namespace L02P02_2021RV650.Controllers
{
    public class AutoresController : Controller
    {
        private readonly LibreriaDbContext _context;

        public AutoresController(LibreriaDbContext context)
        {
            _context = context;
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autores.ToListAsync());
        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.Autores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autore == null)
            {
                return NotFound();
            }

            return View(autore);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Autor")] Autore autore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autore);
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.Autores.FindAsync(id);
            if (autore == null)
            {
                return NotFound();
            }
            return View(autore);
        }

        [HttpGet]
        public async Task<IActionResult> LibrosAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            var librosDelAutor = await _context.Libros
                .Where(l => l.IdAutor == autor.Id)
                .ToListAsync();

            ViewBag.NombreAutor = autor.Autor;

            return View("LibrosAutor", librosDelAutor);
        }

        [HttpGet]
        public async Task<IActionResult> ComentariosLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            var autorDelLibro = await _context.Autores.FindAsync(libro.IdAutor);
            if (autorDelLibro == null)
            {
                return NotFound();
            }

            var comentariosDelLibro = await _context.ComentariosLibros
                .Where(c => c.IdLibro == id)
                .ToListAsync();

            ViewBag.NombreLibro = libro.Nombre;
            ViewBag.IdLibro = libro.Id;
            ViewBag.NombreAutor = autorDelLibro.Autor;

            return View("ComentariosLibro", comentariosDelLibro);
        }

       

        private bool AutoreExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
}
