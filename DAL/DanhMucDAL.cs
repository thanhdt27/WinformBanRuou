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
    public class DanhMucDAL:KetNoi
    {
        public string  TimMaDanhMuc(string tenDM)
        {
            string maDM = "";
            OpenConn();
            string sql = "select MaDanhMuc from DanhMucSanPham where TenDanhMuc = @tenDM";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tenDM", SqlDbType.NChar)).Value = tenDM;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            sqlDr.Read();
            maDM = sqlDr.GetString(0);

            sqlDr.Close();
            CloseConn();

            return maDM;
        }

        public Boolean XoaSanPhamTheoDanhMuc(DanhMucSanPham dmsp)
        {
            OpenConn();
            string sqlLayMaSanPham = "select MaSanPham from SanPham where MaDanhMuc = '" + dmsp.MaDanhMuc + "'";
            SqlCommand sqlComm1 = new SqlCommand(sqlLayMaSanPham, conn);
            SqlDataReader sqlDr = sqlComm1.ExecuteReader();
            List<string> list = new List<string>();
            while (sqlDr.Read())
            {
                list.Add(sqlDr.GetString(0));
            }
            sqlDr.Close();
            CloseConn();

            foreach (string ele in list)
            {
                OpenConn();
                string sql2 = "delete ChiTietHoaDon where MaSanPham=@masp";
                SqlCommand sqlComm2 = new SqlCommand(sql2, conn);
                sqlComm2.Parameters.Add(new SqlParameter("@masp", SqlDbType.NChar)).Value = ele;
                sqlComm2.ExecuteNonQuery();
                CloseConn();
            }

            OpenConn();
            string sql = "delete SanPham where MaDanhMuc = @madm";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@madm", SqlDbType.NChar)).Value = dmsp.MaDanhMuc;
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();

            if (kq != 0)
                return true;

            return false;
        }

        public Boolean XoaDanhMuc(DanhMucSanPham dmsp)
        {
            XoaSanPhamTheoDanhMuc(dmsp);
            OpenConn();
            string sql = "delete DanhMucSanPham where MaDanhMuc = @madm or TenDanhMuc = @tendm";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@madm", SqlDbType.NChar)).Value = dmsp.MaDanhMuc;
            sqlComm.Parameters.Add(new SqlParameter("@tendm", SqlDbType.NVarChar)).Value = dmsp.TenDanhMuc;
            int kq = sqlComm.ExecuteNonQuery();
            CloseConn();

            if (kq != 0)
                return true;

            return false;
        }

        public Boolean CapNhatDanhMuc(DanhMucSanPham dmsp)
        {
            OpenConn();
            string sql = "update DanhMucSanPham set TenDanhMuc = @tendanhmuc where MaDanhMuc = @madanhmuc";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tendanhmuc", SqlDbType.NVarChar)).Value = dmsp.TenDanhMuc;
            sqlComm.Parameters.Add(new SqlParameter("@madanhmuc", SqlDbType.NChar)).Value = dmsp.MaDanhMuc;
            sqlComm.Parameters.Add(new SqlParameter("@mota", SqlDbType.NVarChar)).Value = dmsp.MoTa;
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }

        public Boolean ThemDanhMuc(DanhMucSanPham dmsp)
        {
            OpenConn();
            string sql = "insert into DanhMucSanPham values(@madm,@tendm,@mota)";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@madm", SqlDbType.NChar)).Value = dmsp.MaDanhMuc;
            sqlComm.Parameters.Add(new SqlParameter("@tendm", SqlDbType.NVarChar)).Value = dmsp.TenDanhMuc;
            sqlComm.Parameters.Add(new SqlParameter("@mota", SqlDbType.NVarChar)).Value = dmsp.MoTa;
            int kq = sqlComm.ExecuteNonQuery();
            CloseConn();

            if (kq != 0)
                return true;

            return false;
        }

        public List<DanhMucSanPham> TimDanhMuc(string maDM, string tenDM)
        {
            List<DanhMucSanPham> list = new List<DanhMucSanPham>();
            OpenConn();
            string sql = "select * from DanhMucSanPham where MaDanhMuc = @maDM or TenDanhMuc = @tenDM";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@maDM", SqlDbType.Char)).Value = maDM;
            sqlComm.Parameters.Add(new SqlParameter("@tenDM", SqlDbType.NVarChar)).Value = tenDM;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                DanhMucSanPham dm = new DanhMucSanPham();
                dm.MaDanhMuc = sqlDr.GetString(0);
                dm.TenDanhMuc = sqlDr.GetString(1);
                dm.MoTa = sqlDr.GetString(2);
                list.Add(dm);
            }
            sqlDr.Close();
            CloseConn();

            return list;
        }

        public List<DanhMucSanPham> LayDanhMuc()
        {
            List<DanhMucSanPham> list = new List<DanhMucSanPham>();
            OpenConn();
            string sql ="select * from DanhMucSanPham";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                DanhMucSanPham dm = new DanhMucSanPham();
                dm.MaDanhMuc = sqlDr.GetString(0);
                dm.TenDanhMuc = sqlDr.GetString(1);
                dm.MoTa = sqlDr.GetString(2);
                list.Add(dm);
            }
            sqlDr.Close();
            CloseConn();

            return list;
        }
    }
}
