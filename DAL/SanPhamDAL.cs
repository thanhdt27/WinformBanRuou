using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class SanPhamDAL:KetNoi
    {
        ChiTietHoaDonDAL cthdDAL = new ChiTietHoaDonDAL();
        public SanPham TimSanPhamTheoMa(string maSP)
        {
            SanPham sp = new SanPham();
            OpenConn();
            string sql = "select * from SanPham where MaSanPham =@maSP";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@maSP", SqlDbType.NVarChar)).Value = maSP;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            if (sqlDr.Read())
            {
                sp.MaSanPham = sqlDr.GetString(0);
                sp.TenSanPham = sqlDr.GetString(1);
                sp.DungTich = sqlDr.GetInt32(2);
                sp.NongDo = sqlDr.GetInt32(3);
                sp.SoLuong = sqlDr.GetInt32(4);
                sp.DonGia = sqlDr.GetInt32(5);
                sp.MaDanhMuc = sqlDr.GetString(6);
                sp.MaNCC = sqlDr.GetString(7);
            }

            CloseConn();

            return sp;
        }
        public string TimMaSanPhamTheoTen(string tenSP)
        {
            string maSP = "";
            OpenConn();
            string sql = "select MaSanPham from SanPham where TenSanPham =@tenSP";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tenSP", SqlDbType.NVarChar)).Value = tenSP;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            if (sqlDr.Read())
                maSP = sqlDr.GetString(0);

            CloseConn();

            return maSP;

        }

        public Boolean XoaSanPham(string maSP, string tenSP)
        {
            OpenConn();
            cthdDAL.xoaChiTietHoaDonKhiXoaSanPham(maSP);
            string sql = "delete SanPham where MaSanPham=@maSP or TenSanPham =@tenSP";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@maSP", SqlDbType.NChar)).Value = maSP;
            sqlComm.Parameters.Add(new SqlParameter("@tenSP", SqlDbType.NVarChar)).Value = tenSP;
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }

        public Boolean CapNhatSanPham(SanPham sp)
        {
            OpenConn();
            string sql = "update SanPham set TenSanPham=@tenSP, DungTich=@dungTich, NongDo=@nongDo, SoLuong=@soLuong,DonGia=@donGia,MaDanhMuc =@maDM,MaNCC = @maNCC where MaSanPham = @maSP";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tenSP", SqlDbType.NVarChar)).Value = sp.TenSanPham;
            sqlComm.Parameters.Add(new SqlParameter("@dungTich", SqlDbType.Int)).Value = sp.DungTich;
            sqlComm.Parameters.Add(new SqlParameter("@nongDo", SqlDbType.Int)).Value = sp.NongDo;
            sqlComm.Parameters.Add(new SqlParameter("@soLuong", SqlDbType.Int)).Value = sp.SoLuong;
            sqlComm.Parameters.Add(new SqlParameter("@donGia", SqlDbType.Int)).Value = sp.DonGia;
            sqlComm.Parameters.Add(new SqlParameter("@maDM", SqlDbType.NChar)).Value = sp.MaDanhMuc;
            sqlComm.Parameters.Add(new SqlParameter("@maNCC", SqlDbType.NChar)).Value = sp.MaNCC;
            sqlComm.Parameters.Add(new SqlParameter("@maSP", SqlDbType.NChar)).Value = sp.MaSanPham;
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }

        public Boolean ThemSanPham(SanPham sp)
        {
            OpenConn();
            string sql = "insert into SanPham values(@maSP,@tenSP,@dungTich,@nongDo,@soLuong,@donGia,@maDM,@tenNCC)";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@maSP", SqlDbType.NChar)).Value = sp.MaSanPham;
            sqlComm.Parameters.Add(new SqlParameter("@tenSP", SqlDbType.NVarChar)).Value = sp.TenSanPham;
            sqlComm.Parameters.Add(new SqlParameter("@dungTich", SqlDbType.Int)).Value = sp.DungTich;
            sqlComm.Parameters.Add(new SqlParameter("@nongDo", SqlDbType.Int)).Value = sp.NongDo;
            sqlComm.Parameters.Add(new SqlParameter("@soLuong", SqlDbType.Int)).Value = sp.SoLuong;
            sqlComm.Parameters.Add(new SqlParameter("@donGia", SqlDbType.Int)).Value = sp.DonGia;
            sqlComm.Parameters.Add(new SqlParameter("@maDM", SqlDbType.NChar)).Value = sp.MaDanhMuc;
            sqlComm.Parameters.Add(new SqlParameter("@tenNCC", SqlDbType.NChar)).Value = sp.MaNCC;
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }

        public List<SanPham> TimSanPham(SanPham spTim,string TenDM, string TenNCC)
        {
            List<SanPham> list = new List<SanPham>();
            OpenConn();
            string sql = "select SanPham.* from SanPham, DanhMucSanPham, NhaCungCap where SanPham.MaDanhMuc = DanhMucSanPham.MaDanhMuc and SanPham.MaNCC = NhaCungCap.MaNCC and (MaSanPham = @maSP or TenSanPham = @tenSP or DanhMucSanPham.TenDanhMuc = @tenDM or NhaCungCap.TenNCC = @tenNCC)";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tenSP", SqlDbType.NVarChar)).Value = spTim.TenSanPham;
            sqlComm.Parameters.Add(new SqlParameter("@maSP", SqlDbType.NChar)).Value = spTim.MaSanPham;
            sqlComm.Parameters.Add(new SqlParameter("@tenDM", SqlDbType.NVarChar)).Value = TenDM;
            sqlComm.Parameters.Add(new SqlParameter("@tenNCC", SqlDbType.NVarChar)).Value = TenNCC;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                SanPham sp = new SanPham();
                sp.MaSanPham = sqlDr.GetString(0);
                sp.TenSanPham = sqlDr.GetString(1);
                sp.DungTich = sqlDr.GetInt32(2);
                sp.NongDo = sqlDr.GetInt32(3);
                sp.SoLuong = sqlDr.GetInt32(4);
                sp.DonGia = sqlDr.GetInt32(5);
                sp.MaDanhMuc = sqlDr.GetString(6);
                sp.MaNCC = sqlDr.GetString(7);
                list.Add(sp);
            }
            sqlDr.Close();
            CloseConn();

            return list;
        }


        public List<SanPham> TimTheoTenSanPham(string tenSP)
        {
            List<SanPham> list = new List<SanPham>();
            OpenConn();
            string sql = "select * from SanPham where TenSanPham = @tenSP";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tenSP", SqlDbType.NVarChar)).Value = tenSP;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                SanPham sp = new SanPham();
                sp.MaSanPham = sqlDr.GetString(0);
                sp.TenSanPham = sqlDr.GetString(1);
                sp.DungTich = sqlDr.GetInt32(2);
                sp.NongDo = sqlDr.GetInt32(3);
                sp.SoLuong = sqlDr.GetInt32(4);
                sp.DonGia = sqlDr.GetInt32(5);
                sp.MaDanhMuc = sqlDr.GetString(6);
                sp.MaNCC = sqlDr.GetString(7);
                list.Add(sp);
            }
            sqlDr.Close();
            CloseConn();

            return list;
        }

        public List<SanPham> TimTheoDanhMuc(string dm)
        {
            List<SanPham> list = new List<SanPham>();
            OpenConn();
            string sql = "select SanPham.* from SanPham, DanhMucSanPham where SanPham.MaDanhMuc = DanhMucSanPham.MaDanhMuc and DanhMucSanPham.TenDanhMuc = @tendanhmuc";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tendanhmuc", SqlDbType.NVarChar)).Value = dm;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                SanPham sp = new SanPham();
                sp.MaSanPham = sqlDr.GetString(0);
                sp.TenSanPham = sqlDr.GetString(1);
                sp.DungTich = sqlDr.GetInt32(2);
                sp.NongDo = sqlDr.GetInt32(3);
                sp.SoLuong = sqlDr.GetInt32(4);
                sp.DonGia = sqlDr.GetInt32(5);
                sp.MaDanhMuc = sqlDr.GetString(6);
                sp.MaNCC = sqlDr.GetString(7);
                list.Add(sp);
            }
            sqlDr.Close();
            CloseConn();

            return list;
        }
        public Boolean CapNhatSoLuong(string masanpham, int sl)
        {
            OpenConn();
            string sql = "update SanPham set SoLuong=SoLuong-@sl where MaSanPham = @masanpham";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@sl", SqlDbType.Int)).Value = sl;
            sqlComm.Parameters.Add(new SqlParameter("@masanpham", SqlDbType.NChar)).Value = masanpham;
            int kq = sqlComm.ExecuteNonQuery();
            CloseConn();
            if(kq!=0)
                return true;
            
            return false;
        }
        public List<SanPham> LaySanPham()
        {
            List<SanPham> list = new List<SanPham>();
            OpenConn();
            string sql = "select * from SanPham";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                SanPham sp = new SanPham();
                sp.MaSanPham = sqlDr.GetString(0);
                sp.TenSanPham = sqlDr.GetString(1);
                sp.DungTich = sqlDr.GetInt32(2);
                sp.NongDo = sqlDr.GetInt32(3);
                sp.SoLuong = sqlDr.GetInt32(4);
                sp.DonGia = sqlDr.GetInt32(5);
                sp.MaDanhMuc = sqlDr.GetString(6);
                sp.MaNCC = sqlDr.GetString(7);
                list.Add(sp);
            }
            sqlDr.Close();

            CloseConn();
            return list;
        }
    }
}
