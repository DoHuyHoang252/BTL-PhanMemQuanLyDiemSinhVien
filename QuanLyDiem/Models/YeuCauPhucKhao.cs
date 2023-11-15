using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NuGet.Protocol.Plugins;
namespace QuanLyDiem.Models
{
    public class YeuCauPhucKhao {
        [Key]
        public int MaYeuCauPhucKhao { get; set; }
        public string MaSinhVien { get; set; }
        [ForeignKey("MaSinhVien")]
        public SinhVien? SinhVien{get; set;}
        public string MaHocPhan { get; set; }
        [ForeignKey("MaHocPhan")]
        public HocPhan? HocPhan {get; set;}
        public int DiemThi { get; set; }
        [ForeignKey("DiemThi")]
        public BangDiem? BangDiem {get; set;}
        public string LyDo { get; set; }
        public string TrangThai{get; set;}
        public YeuCauPhucKhao(){
            TrangThai = "Đang chờ xử lý";
        }
    }
}