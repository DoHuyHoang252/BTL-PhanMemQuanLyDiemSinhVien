using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLyDiem.Models
{
    public class SinhVien {
        [Key]
        public string MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public string GioiTinh { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        public string TinhTrang { get; set; }
        public string MaChuyenNganh { get; set; }
        [ForeignKey("MaChuyenNganh")]
        public ChuyenNganh? ChuyenNganh {get; set;}
        public string MaKhoaHoc { get; set; }
        [ForeignKey("MaKhoaHoc")]
        public KhoaHoc? KhoaHoc {get; set;}
    }
}