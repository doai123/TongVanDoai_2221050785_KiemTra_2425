using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KiemTra.Data;

namespace KiemTra.Controllers
{
    public class TongVanDoaiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TongVanDoaiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TongVanDoai
        public async Task<IActionResult> Index()
        {
            return View(await _context.TongVanDoai.ToListAsync());
        }

        // GET: TongVanDoai/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tongVanDoai = await _context.TongVanDoai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tongVanDoai == null)
            {
                return NotFound();
            }

            return View(tongVanDoai);
        }

        // GET: TongVanDoai/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TongVanDoai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ten,Ma")] TongVanDoai tongVanDoai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tongVanDoai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tongVanDoai);
        }

        // GET: TongVanDoai/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tongVanDoai = await _context.TongVanDoai.FindAsync(id);
            if (tongVanDoai == null)
            {
                return NotFound();
            }
            return View(tongVanDoai);
        }

        // POST: TongVanDoai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Ten,Ma")] TongVanDoai tongVanDoai)
        {
            if (id != tongVanDoai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tongVanDoai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TongVanDoaiExists(tongVanDoai.Id))
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
            return View(tongVanDoai);
        }

        // GET: TongVanDoai/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tongVanDoai = await _context.TongVanDoai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tongVanDoai == null)
            {
                return NotFound();
            }

            return View(tongVanDoai);
        }

        // POST: TongVanDoai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tongVanDoai = await _context.TongVanDoai.FindAsync(id);
            if (tongVanDoai != null)
            {
                _context.TongVanDoai.Remove(tongVanDoai);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TongVanDoaiExists(string id)
        {
            return _context.TongVanDoai.Any(e => e.Id == id);
        }
    }
}
