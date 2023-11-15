using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyDiem.Data;
using QuanLyDiem.Models;

namespace QuanLyDiem.Controllers
{
    public class LopHocPhanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LopHocPhanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LopHocPhan
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LopHocPhan.Include(l => l.GiangVien).Include(l => l.HocKy).Include(l => l.HocPhan);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LopHocPhan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.LopHocPhan == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhan
                .Include(l => l.GiangVien)
                .Include(l => l.HocKy)
                .Include(l => l.HocPhan)
                .FirstOrDefaultAsync(m => m.MaLopHocPhan == id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            return View(lopHocPhan);
        }

        // GET: LopHocPhan/Create
        public IActionResult Create()
        {
            ViewData["MaGiangVien"] = new SelectList(_context.GiangVien, "MaGiangVien", "MaGiangVien");
            ViewData["MaHocKy"] = new SelectList(_context.HocKy, "MaHocKy", "MaHocKy");
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhan, "MaHocPhan", "MaHocPhan");
            return View();
        }

        // POST: LopHocPhan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLopHocPhan,TenLopHocPhan,MaHocPhan,MaGiangVien,MaHocKy")] LopHocPhan lopHocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopHocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGiangVien"] = new SelectList(_context.GiangVien, "MaGiangVien", "MaGiangVien", lopHocPhan.MaGiangVien);
            ViewData["MaHocKy"] = new SelectList(_context.HocKy, "MaHocKy", "MaHocKy", lopHocPhan.MaHocKy);
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhan, "MaHocPhan", "MaHocPhan", lopHocPhan.MaHocPhan);
            return View(lopHocPhan);
        }

        // GET: LopHocPhan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.LopHocPhan == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhan.FindAsync(id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }
            ViewData["MaGiangVien"] = new SelectList(_context.GiangVien, "MaGiangVien", "MaGiangVien", lopHocPhan.MaGiangVien);
            ViewData["MaHocKy"] = new SelectList(_context.HocKy, "MaHocKy", "MaHocKy", lopHocPhan.MaHocKy);
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhan, "MaHocPhan", "MaHocPhan", lopHocPhan.MaHocPhan);
            return View(lopHocPhan);
        }

        // POST: LopHocPhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaLopHocPhan,TenLopHocPhan,MaHocPhan,MaGiangVien,MaHocKy")] LopHocPhan lopHocPhan)
        {
            if (id != lopHocPhan.MaLopHocPhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopHocPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHocPhanExists(lopHocPhan.MaLopHocPhan))
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
            ViewData["MaGiangVien"] = new SelectList(_context.GiangVien, "MaGiangVien", "MaGiangVien", lopHocPhan.MaGiangVien);
            ViewData["MaHocKy"] = new SelectList(_context.HocKy, "MaHocKy", "MaHocKy", lopHocPhan.MaHocKy);
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhan, "MaHocPhan", "MaHocPhan", lopHocPhan.MaHocPhan);
            return View(lopHocPhan);
        }

        // GET: LopHocPhan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.LopHocPhan == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhan
                .Include(l => l.GiangVien)
                .Include(l => l.HocKy)
                .Include(l => l.HocPhan)
                .FirstOrDefaultAsync(m => m.MaLopHocPhan == id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            return View(lopHocPhan);
        }

        // POST: LopHocPhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.LopHocPhan == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LopHocPhan'  is null.");
            }
            var lopHocPhan = await _context.LopHocPhan.FindAsync(id);
            if (lopHocPhan != null)
            {
                _context.LopHocPhan.Remove(lopHocPhan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHocPhanExists(string id)
        {
          return (_context.LopHocPhan?.Any(e => e.MaLopHocPhan == id)).GetValueOrDefault();
        }
    }
}
