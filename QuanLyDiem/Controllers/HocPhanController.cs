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
    public class HocPhanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HocPhanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HocPhantroller
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HocPhan.Include(h => h.ChuyenNganh);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HocPhantroller/Create
        public IActionResult Create()
        {
            ViewData["MaChuyenNganh"] = new SelectList(_context.Set<ChuyenNganh>(), "MaChuyenNganh", "TenChuyenNganh");
            return View();
        }

        // POST: HocPhantroller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHocPhan,TenHocPhan,SoTinChi,MaChuyenNganh")] HocPhan hocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChuyenNganh"] = new SelectList(_context.Set<ChuyenNganh>(), "MaChuyenNganh", "TenChuyenNganh", hocPhan.MaChuyenNganh);
            return View(hocPhan);
        }

        // GET: HocPhantroller/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HocPhan == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhan.FindAsync(id);
            if (hocPhan == null)
            {
                return NotFound();
            }
            ViewData["MaChuyenNganh"] = new SelectList(_context.Set<ChuyenNganh>(), "MaChuyenNganh", "TenChuyenNganh", hocPhan.MaChuyenNganh);
            return View(hocPhan);
        }

        // POST: HocPhantroller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHocPhan,TenHocPhan,SoTinChi,MaChuyenNganh")] HocPhan hocPhan)
        {
            if (id != hocPhan.MaHocPhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HocPhanExists(hocPhan.MaHocPhan))
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
            ViewData["MaChuyenNganh"] = new SelectList(_context.Set<ChuyenNganh>(), "MaChuyenNganh", "TenChuyenNganh", hocPhan.MaChuyenNganh);
            return View(hocPhan);
        }

        // GET: HocPhantroller/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HocPhan == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhan
                .Include(h => h.ChuyenNganh)
                .FirstOrDefaultAsync(m => m.MaHocPhan == id);
            if (hocPhan == null)
            {
                return NotFound();
            }

            return View(hocPhan);
        }

        // POST: HocPhantroller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HocPhan == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HocPhan'  is null.");
            }
            var hocPhan = await _context.HocPhan.FindAsync(id);
            if (hocPhan != null)
            {
                _context.HocPhan.Remove(hocPhan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HocPhanExists(string id)
        {
          return (_context.HocPhan?.Any(e => e.MaHocPhan == id)).GetValueOrDefault();
        }
    }
}
