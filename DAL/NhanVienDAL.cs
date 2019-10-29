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
    public class NhanVienDAL:KetNoi
    {

        public List<string> LayTenTaiKhoan()
        {
            List<string> list = new List<string>();
            OpenConn();
            string sql = "select * from NhanVien";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                list.Add(sqlDr.GetString(4));
            }
            sqlDr.Close();

            CloseConn();
            return list;
        }

        public string TimMaNhanVien(string tenNV)
        {
            string maNV = "";
            OpenConn();
            string sql = "select MaNhanVien from NhanVien where TenNhanVien = @tenNV";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tenNV", SqlDbType.NVarChar)).Value = tenNV;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            if(sqlDr.Read())
                maNV = sqlDr.GetString(0);
            sqlDr.Close();
            CloseConn();
            return maNV;
        }
        public List<string> LayTenNhanVien()
        {
            List<string> list = new List<string>();
            OpenConn();
            string sql = "select * from NhanVien";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                list.Add(sqlDr.GetString(1));
            }
            sqlDr.Close();

            CloseConn();
            return list;
        }

        public Boolean XoaNhanVien(string maNV)
        {
            OpenConn();
            string sql = "delete NhanVien where MaNhanVien=@maNV";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@maNV", SqlDbType.NChar)).Value = maNV;
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }

        public Boolean CapNhatNhanVien(NhanVien nv)
        {
            OpenConn();
            string sql = "update NhanVien set TenNhanVien=@tenNV, GioiTinh=@gioiTinh, SDT = @sDT, TenTaiKhoan=@tenTaiKhoan,MatKhau=@matKhau,@LoaiTaiKhoan=@loaiTaiKhoan where MaNhanVien = @maNV";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tenNV", SqlDbType.NVarChar)).Value = nv.TenNhanVien;
            sqlComm.Parameters.Add(new SqlParameter("@gioiTinh", SqlDbType.NVarChar)).Value = nv.GioiTinh;
            sqlComm.Parameters.Add(new SqlParameter("@sDT", SqlDbType.NVarChar)).Value = nv.SDT;
            sqlComm.Parameters.Add(new SqlParameter("@TenTaiKhoan", SqlDbType.NVarChar)).Value = nv.TenDangNhap;
            sqlComm.Parameters.Add(new SqlParameter("@MatKhau", SqlDbType.NVarChar)).Value = nv.MatKhau;
            sqlComm.Parameters.Add(new SqlParameter("@LoaiTaiKhoan", SqlDbType.NVarChar)).Value = nv.LoaiTaiKhoan;

            sqlComm.Parameters.Add(new SqlParameter("@maNV", SqlDbType.NChar)).Value = nv.MaNhanVien;
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }

        public Boolean ThemNhanVien(NhanVien nv)
        {
            OpenConn();
            string sql = "insert into NhanVien values(@maNV,@tenNV,@gioiTinh,@sDT,@TenTaiKhoan,@MatKhau,@LoaiTaiKhoan)";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@maNV", SqlDbType.NChar)).Value = nv.MaNhanVien;
            sqlComm.Parameters.Add(new SqlParameter("@tenNV", SqlDbType.NVarChar)).Value = nv.TenNhanVien;
            sqlComm.Parameters.Add(new SqlParameter("@gioiTinh", SqlDbType.NVarChar)).Value = nv.GioiTinh;
            sqlComm.Parameters.Add(new SqlParameter("@sDT", SqlDbType.NVarChar)).Value = nv.SDT;
            sqlComm.Parameters.Add(new SqlParameter("@TenTaiKhoan", SqlDbType.NVarChar)).Value = nv.TenDangNhap;
            sqlComm.Parameters.Add(new SqlParameter("@MatKhau", SqlDbType.NVarChar)).Value = nv.MatKhau;
            sqlComm.Parameters.Add(new SqlParameter("@LoaiTaiKhoan", SqlDbType.NVarChar)).Value = nv.LoaiTaiKhoan;

            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }

        public List<NhanVien> TimNhanVien(string maNV, string tenNV)
        {
            List<NhanVien> list = new List<NhanVien>();
            OpenConn();
            string sql = "select * from NhanVien where MaNhanVien=@maNV or TenNhanVien = @tenNV";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@maNV", SqlDbType.NChar)).Value = maNV;
            sqlComm.Parameters.Add(new SqlParameter("@tenNV", SqlDbType.NVarChar)).Value = tenNV;
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

            CloseConn();
            return list;
        }

        public List<NhanVien> LayNhanVien()
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
    }
}
