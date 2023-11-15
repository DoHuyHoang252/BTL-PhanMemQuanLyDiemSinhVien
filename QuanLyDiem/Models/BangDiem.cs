using System.Linq.Expressions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace QuanLyDiem.Models
{
    public class BangDiem {
        public string MaSinhVien { get; set; }
        [ForeignKey("MaSinhVien")]
        public SinhVien? SinhVien {get; set;}
        public string MaHocPhan { get; set; }
        [ForeignKey("MaHocPhan")]
        public HocPhan? HocPhan {get; set;}
        [Key]
        public int MaBangDiem { get; set; }
        public double DiemChuyenCan { get; set; }
        public double DiemKiemTra { get; set; }
        public double DiemThi { get; set; }
    }
}