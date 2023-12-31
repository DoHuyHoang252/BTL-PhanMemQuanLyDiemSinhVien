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
    [Migration("20231109155617_Update_DataType_BangDiem")]
    partial class Update_DataType_BangDiem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("QuanLyDiem.Models.BangDiem", b =>
                {
                    b.Property<string>("MaBangDiem")
                        .HasColumnType("TEXT");

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

                    b.Property<string>("MaKhoa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGiangVien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaGiangVien");

                    b.HasIndex("MaKhoa");

                    b.ToTable("GiangVien");
                });

            modelBuilder.Entity("QuanLyDiem.Models.HocKy", b =>
                {
                    b.Property<string>("MaHocKy")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenHocKy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaHocKy");

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

                    b.Property<string>("MaHocPhan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenLopHocPhan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaLopHocPhan");

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

                    b.ToTable("SinhVien");
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
                    b.HasOne("QuanLyDiem.Models.Khoa", "Khoa")
                        .WithMany()
                        .HasForeignKey("MaKhoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
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
                    b.HasOne("QuanLyDiem.Models.HocPhan", "HocPhan")
                        .WithMany()
                        .HasForeignKey("MaHocPhan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HocPhan");
                });

            modelBuilder.Entity("QuanLyDiem.Models.SinhVien", b =>
                {
                    b.HasOne("QuanLyDiem.Models.ChuyenNganh", "ChuyeNganh")
                        .WithMany()
                        .HasForeignKey("MaChuyenNganh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChuyeNganh");
                });
#pragma warning restore 612, 618
        }
    }
}
