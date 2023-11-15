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
    public class SinhVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SinhVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SinhVien
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SinhVien.Include(s => s.ChuyenNganh).Include(s => s.KhoaHoc);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SinhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SinhVien == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .Include(s => s.ChuyenNganh)
                .Include(s => s.KhoaHoc)
                .FirstOrDefaultAsync(m => m.MaSinhVien == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: SinhVien/Create
        public IActionResult Create()
        {
            ViewData["MaChuyenNganh"] = new SelectList(_context.ChuyenNganh, "MaChuyenNganh", "MaChuyenNganh");
            ViewData["MaKhoaHoc"] = new SelectList(_context.KhoaHoc, "MaKhoaHoc", "MaKhoaHoc");
            return View();
        }

        // POST: SinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSinhVien,TenSinhVien,GioiTinh,NgaySinh,TinhTrang,MaChuyenNganh,MaKhoaHoc")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChuyenNganh"] = new SelectList(_context.ChuyenNganh, "MaChuyenNganh", "MaChuyenNganh", sinhVien.MaChuyenNganh);
            ViewData["MaKhoaHoc"] = new SelectList(_context.KhoaHoc, "MaKhoaHoc", "MaKhoaHoc", sinhVien.MaKhoaHoc);
            return View(sinhVien);
        }

        // GET: SinhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SinhVien == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewData["MaChuyenNganh"] = new SelectList(_context.ChuyenNganh, "MaChuyenNganh", "MaChuyenNganh", sinhVien.MaChuyenNganh);
            ViewData["MaKhoaHoc"] = new SelectList(_context.KhoaHoc, "MaKhoaHoc", "MaKhoaHoc", sinhVien.MaKhoaHoc);
            return View(sinhVien);
        }

        // POST: SinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSinhVien,TenSinhVien,GioiTinh,NgaySinh,TinhTrang,MaChuyenNganh,MaKhoaHoc")] SinhVien sinhVien)
        {
            if (id != sinhVien.MaSinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.MaSinhVien))
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
            ViewData["MaChuyenNganh"] = new SelectList(_context.ChuyenNganh, "MaChuyenNganh", "MaChuyenNganh", sinhVien.MaChuyenNganh);
            ViewData["MaKhoaHoc"] = new SelectList(_context.KhoaHoc, "MaKhoaHoc", "MaKhoaHoc", sinhVien.MaKhoaHoc);
            return View(sinhVien);
        }

        // GET: SinhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SinhVien == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .Include(s => s.ChuyenNganh)
                .Include(s => s.KhoaHoc)
                .FirstOrDefaultAsync(m => m.MaSinhVien == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SinhVien == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SinhVien'  is null.");
            }
            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhVien.Remove(sinhVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
          return (_context.SinhVien?.Any(e => e.MaSinhVien == id)).GetValueOrDefault();
        }
    }
}
