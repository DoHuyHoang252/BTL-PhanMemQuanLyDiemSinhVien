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
    public class BangDiemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BangDiemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BangDiem
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BangDiem.Include(b => b.HocPhan).Include(b => b.SinhVien);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BangDiem/Create
        public IActionResult Create()
        {
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhan, "MaHocPhan", "TenHocPhan");
            ViewData["MaSinhVien"] = new SelectList(_context.SinhVien, "MaSinhVien", "TenSinhVien");
            return View();
        }

        // POST: BangDiem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSinhVien,MaHocPhan,MaBangDiem,DiemChuyenCan,DiemKiemTra,DiemThi")] BangDiem bangDiem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bangDiem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhan, "MaHocPhan", "TenHocPhan", bangDiem.MaHocPhan);
            ViewData["MaSinhVien"] = new SelectList(_context.SinhVien, "MaSinhVien", "TenSinhVien", bangDiem.MaSinhVien);
            return View(bangDiem);
        }

        // GET: BangDiem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BangDiem == null)
            {
                return NotFound();
            }

            var bangDiem = await _context.BangDiem.FindAsync(id);
            if (bangDiem == null)
            {
                return NotFound();
            }
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhan, "MaHocPhan", "TenHocPhan", bangDiem.MaHocPhan);
            ViewData["MaSinhVien"] = new SelectList(_context.SinhVien, "MaSinhVien", "TenSinhVien", bangDiem.MaSinhVien);
            return View(bangDiem);
        }

        // POST: BangDiem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSinhVien,MaHocPhan,MaBangDiem,DiemChuyenCan,DiemKiemTra,DiemThi")] BangDiem bangDiem)
        {
            if (id != bangDiem.MaBangDiem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bangDiem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BangDiemExists(bangDiem.MaBangDiem))
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
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhan, "MaHocPhan", "TenHocPhan", bangDiem.MaHocPhan);
            ViewData["MaSinhVien"] = new SelectList(_context.SinhVien, "MaSinhVien", "TenSinhVien", bangDiem.MaSinhVien);
            return View(bangDiem);
        }

        // GET: BangDiem/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.BangDiem == null)
            {
                return NotFound();
            }

            var bangDiem = await _context.BangDiem
                .Include(b => b.HocPhan)
                .Include(b => b.SinhVien)
                .FirstOrDefaultAsync(m => m.MaBangDiem == id);
            if (bangDiem == null)
            {
                return NotFound();
            }

            return View(bangDiem);
        }

        // POST: BangDiem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BangDiem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BangDiem'  is null.");
            }
            var bangDiem = await _context.BangDiem.FindAsync(id);
            if (bangDiem != null)
            {
                _context.BangDiem.Remove(bangDiem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BangDiemExists(int id)
        {
          return (_context.BangDiem?.Any(e => e.MaBangDiem == id)).GetValueOrDefault();
        }
    }
}
