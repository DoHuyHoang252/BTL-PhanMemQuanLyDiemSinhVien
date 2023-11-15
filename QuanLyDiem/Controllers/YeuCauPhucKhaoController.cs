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
    public class YeuCauPhucKhaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YeuCauPhucKhaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YeuCauPhucKhao
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.YeuCauPhucKhao.Include(y => y.BangDiem).Include(y => y.HocPhan).Include(y => y.SinhVien);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: YeuCauPhucKhao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.YeuCauPhucKhao == null)
            {
                return NotFound();
            }

            var yeuCauPhucKhao = await _context.YeuCauPhucKhao
                .Include(y => y.BangDiem)
                .Include(y => y.HocPhan)
                .Include(y => y.SinhVien)
                .FirstOrDefaultAsync(m => m.MaYeuCauPhucKhao == id);
            if (yeuCauPhucKhao == null)
            {
                return NotFound();
            }

            return View(yeuCauPhucKhao);
        }

        // GET: YeuCauPhucKhao/Create
        public IActionResult Create()
        {
            ViewData["DiemThi"] = new SelectList(_context.BangDiem, "MaBangDiem", "MaBangDiem");
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhan, "MaHocPhan", "MaHocPhan");
            ViewData["MaSinhVien"] = new SelectList(_context.SinhVien, "MaSinhVien", "MaSinhVien");
            return View();
        }

        // POST: YeuCauPhucKhao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaYeuCauPhucKhao,MaSinhVien,MaHocPhan,DiemThi,LyDo,TrangThai")] YeuCauPhucKhao yeuCauPhucKhao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yeuCauPhucKhao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiemThi"] = new SelectList(_context.BangDiem, "MaBangDiem", "MaBangDiem", yeuCauPhucKhao.DiemThi);
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhan, "MaHocPhan", "MaHocPhan", yeuCauPhucKhao.MaHocPhan);
            ViewData["MaSinhVien"] = new SelectList(_context.SinhVien, "MaSinhVien", "MaSinhVien", yeuCauPhucKhao.MaSinhVien);
            return View(yeuCauPhucKhao);
        }

        // GET: YeuCauPhucKhao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.YeuCauPhucKhao == null)
            {
                return NotFound();
            }

            var yeuCauPhucKhao = await _context.YeuCauPhucKhao.FindAsync(id);
            if (yeuCauPhucKhao == null)
            {
                return NotFound();
            }
            ViewData["DiemThi"] = new SelectList(_context.BangDiem, "MaBangDiem", "MaBangDiem", yeuCauPhucKhao.DiemThi);
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhan, "MaHocPhan", "MaHocPhan", yeuCauPhucKhao.MaHocPhan);
            ViewData["MaSinhVien"] = new SelectList(_context.SinhVien, "MaSinhVien", "MaSinhVien", yeuCauPhucKhao.MaSinhVien);
            return View(yeuCauPhucKhao);
        }

        // POST: YeuCauPhucKhao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaYeuCauPhucKhao,MaSinhVien,MaHocPhan,DiemThi,LyDo,TrangThai")] YeuCauPhucKhao yeuCauPhucKhao)
        {
            if (id != yeuCauPhucKhao.MaYeuCauPhucKhao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yeuCauPhucKhao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YeuCauPhucKhaoExists(yeuCauPhucKhao.MaYeuCauPhucKhao))
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
            ViewData["DiemThi"] = new SelectList(_context.BangDiem, "MaBangDiem", "MaBangDiem", yeuCauPhucKhao.DiemThi);
            ViewData["MaHocPhan"] = new SelectList(_context.HocPhan, "MaHocPhan", "MaHocPhan", yeuCauPhucKhao.MaHocPhan);
            ViewData["MaSinhVien"] = new SelectList(_context.SinhVien, "MaSinhVien", "MaSinhVien", yeuCauPhucKhao.MaSinhVien);
            return View(yeuCauPhucKhao);
        }

        // GET: YeuCauPhucKhao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.YeuCauPhucKhao == null)
            {
                return NotFound();
            }

            var yeuCauPhucKhao = await _context.YeuCauPhucKhao
                .Include(y => y.BangDiem)
                .Include(y => y.HocPhan)
                .Include(y => y.SinhVien)
                .FirstOrDefaultAsync(m => m.MaYeuCauPhucKhao == id);
            if (yeuCauPhucKhao == null)
            {
                return NotFound();
            }

            return View(yeuCauPhucKhao);
        }

        // POST: YeuCauPhucKhao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.YeuCauPhucKhao == null)
            {
                return Problem("Entity set 'ApplicationDbContext.YeuCauPhucKhao'  is null.");
            }
            var yeuCauPhucKhao = await _context.YeuCauPhucKhao.FindAsync(id);
            if (yeuCauPhucKhao != null)
            {
                _context.YeuCauPhucKhao.Remove(yeuCauPhucKhao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YeuCauPhucKhaoExists(int id)
        {
          return (_context.YeuCauPhucKhao?.Any(e => e.MaYeuCauPhucKhao == id)).GetValueOrDefault();
        }
    }
}
