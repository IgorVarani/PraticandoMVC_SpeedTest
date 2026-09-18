using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CafeteriaMVC.Data;
using CafeteriaMVC.Models;

namespace CafeteriaMVC.Controllers
{
    public class InterController : Controller
    {
        private readonly AppDbContext _context;

        public InterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Inter
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Inter_ItemUsuario.Include(i => i.Item).Include(i => i.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Inter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inter_ItemUsuario = await _context.Inter_ItemUsuario
                .Include(i => i.Item)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.Inter_ItemUsuarioID == id);
            if (inter_ItemUsuario == null)
            {
                return NotFound();
            }

            return View(inter_ItemUsuario);
        }

        // GET: Inter/Create
        public IActionResult Create()
        {
            ViewData["ItemID"] = new SelectList(_context.Item, "ItemID", "ItemID");
            ViewData["UsuarioID"] = new SelectList(_context.Usuario, "UsuarioID", "UsuarioID");
            return View();
        }

        // POST: Inter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Inter_ItemUsuarioID,ItemID,UsuarioID")] Inter_ItemUsuario inter_ItemUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inter_ItemUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemID"] = new SelectList(_context.Item, "ItemID", "ItemID", inter_ItemUsuario.ItemID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuario, "UsuarioID", "UsuarioID", inter_ItemUsuario.UsuarioID);
            return View(inter_ItemUsuario);
        }

        // GET: Inter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inter_ItemUsuario = await _context.Inter_ItemUsuario.FindAsync(id);
            if (inter_ItemUsuario == null)
            {
                return NotFound();
            }
            ViewData["ItemID"] = new SelectList(_context.Item, "ItemID", "ItemID", inter_ItemUsuario.ItemID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuario, "UsuarioID", "UsuarioID", inter_ItemUsuario.UsuarioID);
            return View(inter_ItemUsuario);
        }

        // POST: Inter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Inter_ItemUsuarioID,ItemID,UsuarioID")] Inter_ItemUsuario inter_ItemUsuario)
        {
            if (id != inter_ItemUsuario.Inter_ItemUsuarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inter_ItemUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Inter_ItemUsuarioExists(inter_ItemUsuario.Inter_ItemUsuarioID))
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
            ViewData["ItemID"] = new SelectList(_context.Item, "ItemID", "ItemID", inter_ItemUsuario.ItemID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuario, "UsuarioID", "UsuarioID", inter_ItemUsuario.UsuarioID);
            return View(inter_ItemUsuario);
        }

        // GET: Inter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inter_ItemUsuario = await _context.Inter_ItemUsuario
                .Include(i => i.Item)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.Inter_ItemUsuarioID == id);
            if (inter_ItemUsuario == null)
            {
                return NotFound();
            }

            return View(inter_ItemUsuario);
        }

        // POST: Inter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inter_ItemUsuario = await _context.Inter_ItemUsuario.FindAsync(id);
            if (inter_ItemUsuario != null)
            {
                _context.Inter_ItemUsuario.Remove(inter_ItemUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Inter_ItemUsuarioExists(int id)
        {
            return _context.Inter_ItemUsuario.Any(e => e.Inter_ItemUsuarioID == id);
        }
    }
}
