using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NuGet.Protocol.Plugins;
namespace QuanLyDiem.Models
{
    public class YeuCauSuaDiem {
        [Key]
        public int MaYeuCauSuaDiem { get; set; }
        public string MaGiangVien { get; set; }
        [ForeignKey("MaGiangVien")]
        public GiangVien? GianhVien{get; set;}
        public string MaSinhVien { get; set; }
        [ForeignKey("MaSinhVien")]
        public SinhVien? SinhVien{get; set;}
        public string MaHocPhan { get; set; }
        [ForeignKey("MaHocPhan")]
        public HocPhan? HocPhan {get; set;}
        public int DiemChuyenCan { get; set; }
        [ForeignKey("DiemChuyenCan")]
        public BangDiem? BangDiem {get; set;}
        public int DiemKiemTra { get; set; }
        [ForeignKey("DiemKiemTra")]

        public int DiemChuyenCanMoi { get; set; }
        public int DiemKiemTraMoi { get; set; }
        public string LyDo { get; set; }
        public string TrangThai {get; set;}
        public YeuCauSuaDiem(){
            TrangThai = "Đang chờ xử lý";
        }
    }
}