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
    public class TaiKhoanDangNhapDAL:KetNoi
    {
        public Boolean CapNhatTaiKhoan(TaiKhoanDangNhap tkdn)
        {
            OpenConn();
            string sql = "update TaiKhoanDangNhap set TenDangNhap=@tenDN, MatKhau=@matKhau, LoaiTaiKhoan = @loaiTK, MaNhanVien= @maNV where MaTaiKhoan = @maTK";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tenDN", SqlDbType.NVarChar)).Value = tkdn.TenDangNhap;
            sqlComm.Parameters.Add(new SqlParameter("@matKhau", SqlDbType.NVarChar)).Value = tkdn.MatKhau;
            sqlComm.Parameters.Add(new SqlParameter("@loaiTK", SqlDbType.NVarChar)).Value = tkdn.LoaiTaiKhoan;
            sqlComm.Parameters.Add(new SqlParameter("@maNV", SqlDbType.NChar)).Value = tkdn.MaNhanVien;

            sqlComm.Parameters.Add(new SqlParameter("@maTK", SqlDbType.NChar)).Value = tkdn.MaTaiKhoan;
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }

        public List<TaiKhoanDangNhap> TimTaiKhoan(string maTK, string tenDN, string maNV)
        {
            List<TaiKhoanDangNhap> list = new List<TaiKhoanDangNhap>();
            OpenConn();
            string sql = "select * from TaiKhoanDangNhap where MaTaiKhoan=@maTK or TenDangNhap =@tenDN or MaNhanVien = @maNV";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@maTK", SqlDbType.NChar)).Value = maTK;
            sqlComm.Parameters.Add(new SqlParameter("@tenDN", SqlDbType.NChar)).Value = tenDN;
            sqlComm.Parameters.Add(new SqlParameter("@maNV", SqlDbType.NChar)).Value = maNV;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                TaiKhoanDangNhap tkdn = new TaiKhoanDangNhap();
                tkdn.MaTaiKhoan = sqlDr.GetString(0);
                tkdn.TenDangNhap = sqlDr.GetString(1);
                tkdn.MatKhau = sqlDr.GetString(2);
                tkdn.LoaiTaiKhoan = sqlDr.GetString(3);
                tkdn.MaNhanVien = sqlDr.GetString(4);
                list.Add(tkdn);
            }
            sqlDr.Close();

            CloseConn();


            return list;
        }

        public Boolean ThemTaiKhoan(TaiKhoanDangNhap tkdn)
        {
            OpenConn();
            string sql = "insert into TaiKhoanDangNhap values(@maTK,@tenDN,@matKhau,@loaiTK,@maNV)";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@maTK", SqlDbType.NChar)).Value = tkdn.MaTaiKhoan;
            sqlComm.Parameters.Add(new SqlParameter("@tenDN", SqlDbType.NVarChar)).Value = tkdn.TenDangNhap;
            sqlComm.Parameters.Add(new SqlParameter("@matKhau", SqlDbType.NVarChar)).Value = tkdn.MatKhau;
            sqlComm.Parameters.Add(new SqlParameter("@loaiTK", SqlDbType.NVarChar)).Value = tkdn.LoaiTaiKhoan;
            sqlComm.Parameters.Add(new SqlParameter("@maNV", SqlDbType.NChar)).Value = tkdn.MaNhanVien;

            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }

        public Boolean XoaTaiKhoan(string maTK, string tenDN, string maNV)
        {
            OpenConn();
            string sql = "delete TaiKhoanDangNhap where MaTaiKhoan=@maTK or TenDangNhap =@tenDN or MaNhanVien = @maNV";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@maTK", SqlDbType.NChar)).Value = maTK;
            sqlComm.Parameters.Add(new SqlParameter("@tenDN", SqlDbType.NVarChar)).Value = tenDN;
            sqlComm.Parameters.Add(new SqlParameter("@maNV", SqlDbType.NChar)).Value = maNV;
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }
        public List<NhanVien> LayTaiKhoan()
        {
            List<NhanVien> list = new List<NhanVien>();
            OpenConn();
            string sql = "select * from NhanVien";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                NhanVien nv = new NhanVien();
                nv.MaNhanVien = sqlDr.GetString(0);
                nv.TenNhanVien = sqlDr.GetString(1);
                nv.GioiTinh = sqlDr.GetString(2);
                nv.SDT = sqlDr.GetString(3);
                nv.TenDangNhap = sqlDr.GetString(4);
                nv.MatKhau = sqlDr.GetString(5);
                nv.LoaiTaiKhoan = sqlDr.GetString(6);
                
                list.Add(nv);
            }
            sqlDr.Close();

            CloseConn();


            return list;
        }

        public string KiemTraDangNhap(string TenDangNhap, string MatKhau)
        {
            OpenConn();
            string sql="select LoaiTaiKhoan from NhanVien where TenTaiKhoan=@tendangnhap and MatKhau = @matkhau";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tendangnhap", SqlDbType.NChar)).Value = TenDangNhap;
            sqlComm.Parameters.Add(new SqlParameter("@matkhau", SqlDbType.NChar)).Value = MatKhau;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            string LoaiTaiKhoan = "";
            while (sqlDr.Read())
            {
                LoaiTaiKhoan = sqlDr.GetString(0);
            }

            sqlDr.Close();
            CloseConn();
            return LoaiTaiKhoan;
        }
    }
}
