﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyDiem.Data;

#nullable disable

namespace QuanLyDiem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231114154648_Create_column_YeuCauSuaDiem_YeuCauPhucKhao")]
    partial class Create_column_YeuCauSuaDiem_YeuCauPhucKhao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("QuanLyDiem.Models.BangDiem", b =>
                {
                    b.Property<int>("MaBangDiem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("DiemChuyenCan")
                        .HasColumnType("REAL");

                    b.Property<double>("DiemKiemTra")
                        .HasColumnType("REAL");

                    b.Property<double>("DiemThi")
                        .HasColumnType("REAL");

                    b.Property<string>("MaHocPhan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaSinhVien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaBangDiem");

                    b.HasIndex("MaHocPhan");

                    b.HasIndex("MaSinhVien");

                    b.ToTable("BangDiem");
                });

            modelBuilder.Entity("QuanLyDiem.Models.ChuyenNganh", b =>
                {
                    b.Property<string>("MaChuyenNganh")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaKhoa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenChuyenNganh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaChuyenNganh");

                    b.HasIndex("MaKhoa");

                    b.ToTable("ChuyenNganh");
                });

            modelBuilder.Entity("QuanLyDiem.Models.GiangVien", b =>
                {
                    b.Property<string>("MaGiangVien")
                        .HasColumnType("TEXT");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaChuyenNganh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaKhoa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGiangVien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaGiangVien");

                    b.HasIndex("MaChuyenNganh");

                    b.HasIndex("MaKhoa");

                    b.ToTable("GiangVien");
                });

            modelBuilder.Entity("QuanLyDiem.Models.HocKy", b =>
                {
                    b.Property<string>("MaHocKy")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaKhoaHoc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenHocKy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaHocKy");

                    b.HasIndex("MaKhoaHoc");

                    b.ToTable("HocKy");
                });

            modelBuilder.Entity("QuanLyDiem.Models.HocPhan", b =>
                {
                    b.Property<string>("MaHocPhan")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaChuyenNganh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SoTinChi")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenHocPhan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaHocPhan");

                    b.HasIndex("MaChuyenNganh");

                    b.ToTable("HocPhan");
                });

            modelBuilder.Entity("QuanLyDiem.Models.Khoa", b =>
                {
                    b.Property<string>("MaKhoa")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaKhoa");

                    b.ToTable("Khoa");
                });

            modelBuilder.Entity("QuanLyDiem.Models.KhoaHoc", b =>
                {
                    b.Property<string>("MaKhoaHoc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NamBatDau")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NamKetThuc")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenKhoaHoc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaKhoaHoc");

                    b.ToTable("KhoaHoc");
                });

            modelBuilder.Entity("QuanLyDiem.Models.LopHocPhan", b =>
                {
                    b.Property<string>("MaLopHocPhan")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaGiangVien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaHocKy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaHocPhan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenLopHocPhan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaLopHocPhan");

                    b.HasIndex("MaGiangVien");

                    b.HasIndex("MaHocKy");

                    b.HasIndex("MaHocPhan");

                    b.ToTable("LopHocPhan");
                });

            modelBuilder.Entity("QuanLyDiem.Models.SinhVien", b =>
                {
                    b.Property<string>("MaSinhVien")
                        .HasColumnType("TEXT");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaChuyenNganh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaKhoaHoc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenSinhVien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TinhTrang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaSinhVien");

                    b.HasIndex("MaChuyenNganh");

                    b.HasIndex("MaKhoaHoc");

                    b.ToTable("SinhVien");
                });

            modelBuilder.Entity("QuanLyDiem.Models.YeuCauPhucKhao", b =>
                {
                    b.Property<int>("MaYeuCauPhucKhao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiemThi")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LyDo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaHocPhan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaSinhVien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaYeuCauPhucKhao");

                    b.HasIndex("DiemThi");

                    b.HasIndex("MaHocPhan");

                    b.HasIndex("MaSinhVien");

                    b.ToTable("YeuCauPhucKhao");
                });

            modelBuilder.Entity("QuanLyDiem.Models.YeuCauSuaDiem", b =>
                {
                    b.Property<int>("MaYeuCauSuaDiem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiemChuyenCan")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiemChuyenCanMoi")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiemKiemTra")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiemKiemTraMoi")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LyDo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaGiangVien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaHocPhan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaSinhVien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaYeuCauSuaDiem");

                    b.HasIndex("DiemKiemTra");

                    b.HasIndex("MaGiangVien");

                    b.HasIndex("MaHocPhan");

                    b.HasIndex("MaSinhVien");

                    b.ToTable("YeuCauSuaDiem");
                });

            modelBuilder.Entity("QuanLyDiem.Models.BangDiem", b =>
                {
                    b.HasOne("QuanLyDiem.Models.HocPhan", "HocPhan")
                        .WithMany()
                        .HasForeignKey("MaHocPhan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyDiem.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("MaSinhVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HocPhan");

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("QuanLyDiem.Models.ChuyenNganh", b =>
                {
                    b.HasOne("QuanLyDiem.Models.Khoa", "Khoa")
                        .WithMany()
                        .HasForeignKey("MaKhoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("QuanLyDiem.Models.GiangVien", b =>
                {
                    b.HasOne("QuanLyDiem.Models.ChuyenNganh", "ChuyenNganh")
                        .WithMany()
                        .HasForeignKey("MaChuyenNganh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyDiem.Models.Khoa", "Khoa")
                        .WithMany()
                        .HasForeignKey("MaKhoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChuyenNganh");

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("QuanLyDiem.Models.HocKy", b =>
                {
                    b.HasOne("QuanLyDiem.Models.KhoaHoc", "KhoaHoc")
                        .WithMany()
                        .HasForeignKey("MaKhoaHoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhoaHoc");
                });

            modelBuilder.Entity("QuanLyDiem.Models.HocPhan", b =>
                {
                    b.HasOne("QuanLyDiem.Models.ChuyenNganh", "ChuyenNganh")
                        .WithMany()
                        .HasForeignKey("MaChuyenNganh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChuyenNganh");
                });

            modelBuilder.Entity("QuanLyDiem.Models.LopHocPhan", b =>
                {
                    b.HasOne("QuanLyDiem.Models.GiangVien", "GiangVien")
                        .WithMany()
                        .HasForeignKey("MaGiangVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyDiem.Models.HocKy", "HocKy")
                        .WithMany()
                        .HasForeignKey("MaHocKy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyDiem.Models.HocPhan", "HocPhan")
                        .WithMany()
                        .HasForeignKey("MaHocPhan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GiangVien");

                    b.Navigation("HocKy");

                    b.Navigation("HocPhan");
                });

            modelBuilder.Entity("QuanLyDiem.Models.SinhVien", b =>
                {
                    b.HasOne("QuanLyDiem.Models.ChuyenNganh", "ChuyeNganh")
                        .WithMany()
                        .HasForeignKey("MaChuyenNganh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyDiem.Models.KhoaHoc", "KhoaHoc")
                        .WithMany()
                        .HasForeignKey("MaKhoaHoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChuyeNganh");

                    b.Navigation("KhoaHoc");
                });

            modelBuilder.Entity("QuanLyDiem.Models.YeuCauPhucKhao", b =>
                {
                    b.HasOne("QuanLyDiem.Models.BangDiem", "BangDiem")
                        .WithMany()
                        .HasForeignKey("DiemThi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyDiem.Models.HocPhan", "HocPhan")
                        .WithMany()
                        .HasForeignKey("MaHocPhan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyDiem.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("MaSinhVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BangDiem");

                    b.Navigation("HocPhan");

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("QuanLyDiem.Models.YeuCauSuaDiem", b =>
                {
                    b.HasOne("QuanLyDiem.Models.BangDiem", "BangDiem")
                        .WithMany()
                        .HasForeignKey("DiemKiemTra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyDiem.Models.GiangVien", "GianhVien")
                        .WithMany()
                        .HasForeignKey("MaGiangVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyDiem.Models.HocPhan", "HocPhan")
                        .WithMany()
                        .HasForeignKey("MaHocPhan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyDiem.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("MaSinhVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BangDiem");

                    b.Navigation("GianhVien");

                    b.Navigation("HocPhan");

                    b.Navigation("SinhVien");
                });
#pragma warning restore 612, 618
        }
    }
}
