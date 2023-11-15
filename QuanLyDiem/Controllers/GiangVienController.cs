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
    public class GiangVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GiangVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GiangVien
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GiangVien.Include(g => g.ChuyenNganh).Include(g => g.Khoa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GiangVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.GiangVien == null)
            {
                return NotFound();
            }

            var giangVien = await _context.GiangVien
                .Include(g => g.ChuyenNganh)
                .Include(g => g.Khoa)
                .FirstOrDefaultAsync(m => m.MaGiangVien == id);
            if (giangVien == null)
            {
                return NotFound();
            }

            return View(giangVien);
        }

        // GET: GiangVien/Create
        public IActionResult Create()
        {
            ViewData["MaChuyenNganh"] = new SelectList(_context.ChuyenNganh, "MaChuyenNganh", "MaChuyenNganh");
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "MaKhoa");
            return View();
        }

        // POST: GiangVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGiangVien,TenGiangVien,GioiTinh,NgaySinh,MaKhoa,MaChuyenNganh")] GiangVien giangVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giangVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChuyenNganh"] = new SelectList(_context.ChuyenNganh, "MaChuyenNganh", "MaChuyenNganh", giangVien.MaChuyenNganh);
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "MaKhoa", giangVien.MaKhoa);
            return View(giangVien);
        }

        // GET: GiangVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.GiangVien == null)
            {
                return NotFound();
            }

            var giangVien = await _context.GiangVien.FindAsync(id);
            if (giangVien == null)
            {
                return NotFound();
            }
            ViewData["MaChuyenNganh"] = new SelectList(_context.ChuyenNganh, "MaChuyenNganh", "MaChuyenNganh", giangVien.MaChuyenNganh);
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "MaKhoa", giangVien.MaKhoa);
            return View(giangVien);
        }

        // POST: GiangVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaGiangVien,TenGiangVien,GioiTinh,NgaySinh,MaKhoa,MaChuyenNganh")] GiangVien giangVien)
        {
            if (id != giangVien.MaGiangVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giangVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiangVienExists(giangVien.MaGiangVien))
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
            ViewData["MaChuyenNganh"] = new SelectList(_context.ChuyenNganh, "MaChuyenNganh", "MaChuyenNganh", giangVien.MaChuyenNganh);
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "MaKhoa", giangVien.MaKhoa);
            return View(giangVien);
        }

        // GET: GiangVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.GiangVien == null)
            {
                return NotFound();
            }

            var giangVien = await _context.GiangVien
                .Include(g => g.ChuyenNganh)
                .Include(g => g.Khoa)
                .FirstOrDefaultAsync(m => m.MaGiangVien == id);
            if (giangVien == null)
            {
                return NotFound();
            }

            return View(giangVien);
        }

        // POST: GiangVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.GiangVien == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GiangVien'  is null.");
            }
            var giangVien = await _context.GiangVien.FindAsync(id);
            if (giangVien != null)
            {
                _context.GiangVien.Remove(giangVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiangVienExists(string id)
        {
          return (_context.GiangVien?.Any(e => e.MaGiangVien == id)).GetValueOrDefault();
        }
    }
}
