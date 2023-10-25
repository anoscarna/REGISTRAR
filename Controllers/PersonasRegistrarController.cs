using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using REGISTRAR.Models;

namespace REGISTRAR.Controllers
{
    public class PersonasRegistrarController : Controller
    {
        private readonly PERSONASContext _context;

        public PersonasRegistrarController(PERSONASContext context)
        {
            _context = context;
        }

        // GET: PersonasRegistrar
        public async Task<IActionResult> Index()
        {
              return _context.Personas != null ? 
                          View(await _context.Personas.ToListAsync()) :
                          Problem("Entity set 'PERSONASContext.Personas'  is null.");
        }

        // GET: PersonasRegistrar/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .FirstOrDefaultAsync(m => m.Documentoidentidad == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: PersonasRegistrar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonasRegistrar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Documentoidentidad,Nombres,Apellidos,Fechadenacimiento,Telefono1,Telefono2,Correoelectronico,Correoelectronico2,Direccionfisica1,Direccionfisica2")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: PersonasRegistrar/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: PersonasRegistrar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Documentoidentidad,Nombres,Apellidos,Fechadenacimiento,Telefono1,Telefono2,Correoelectronico,Correoelectronico2,Direccionfisica1,Direccionfisica2")] Persona persona)
        {
            if (id != persona.Documentoidentidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.Documentoidentidad))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: PersonasRegistrar/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .FirstOrDefaultAsync(m => m.Documentoidentidad == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: PersonasRegistrar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Personas == null)
            {
                return Problem("Entity set 'PERSONASContext.Personas'  is null.");
            }
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(string id)
        {
          return (_context.Personas?.Any(e => e.Documentoidentidad == id)).GetValueOrDefault();
        }
    }
}
