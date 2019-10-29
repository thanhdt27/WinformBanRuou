using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NhaCungCapDAL:KetNoi
    {
        ChiTietHoaDonDAL cthdDAL = new ChiTietHoaDonDAL();
        SanPhamDAL spDAL = new SanPhamDAL();
        
        public Boolean XoaSanPhamNhaCungCap(NhaCungCap ncc)
        {
            ChiTietHoaDonDAL cthdDAL = new ChiTietHoaDonDAL();
            OpenConn();
            string sqlLayMaSanPham = "select MaSanPham from SanPham where MaNCC = '" + ncc.MaNCC + "'";
            SqlCommand sqlComm1 = new SqlCommand(sqlLayMaSanPham, conn);
            SqlDataReader sqlDr = sqlComm1.ExecuteReader();
            List<string> list = new List<string>();
            while (sqlDr.Read())
            {
                list.Add(sqlDr.GetString(0));
            }
            foreach (string ele in list)
            {
                string sql2 = "delete ChiTietHoaDon where MaSanPham=@masp";
                SqlCommand sqlComm2 = new SqlCommand(sql2, conn);
                sqlComm2.Parameters.Add(new SqlParameter("@masp", SqlDbType.NChar)).Value = ele;
                sqlComm2.ExecuteNonQuery();
            }
            string sql = "delete SanPham where MaNCC = @mancc";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@mancc", SqlDbType.NChar)).Value = ncc.MaNCC;
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();

            if (kq != 0)
                return true;

            return false;
        }

        public Boolean XoaNhaCungCap(string mancc)
        {
            OpenConn();
            string sqlLayMaSanPham = "select MaSanPham from SanPham where MaNCC = '" + mancc + "'";
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
            string sql3 = "delete SanPham where MaNCC = @mancc";
            SqlCommand sqlComm3 = new SqlCommand(sql3, conn);
            sqlComm3.Parameters.Add(new SqlParameter("@mancc", SqlDbType.NChar)).Value = mancc;
            int kq3 = sqlComm3.ExecuteNonQuery();
            CloseConn();

            OpenConn();
            string sql = "delete NhaCungCap where MaNCC = @mancc";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@mancc", SqlDbType.NChar)).Value = mancc;
            int kq = sqlComm.ExecuteNonQuery();
            CloseConn();

            if (kq != 0)
                return true;

            return false;
        }

        public Boolean CapNhatNhaCungCap(NhaCungCap ncc)
        {
            OpenConn();
            string sql = "update NhaCungCap set TenNCC = @tenncc,DiaChi=@diachi,Email=@email,SDT=@sdt where MaNCC = @mancc";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tenncc", SqlDbType.NVarChar)).Value = ncc.TenNCC;
            sqlComm.Parameters.Add(new SqlParameter("@diachi", SqlDbType.NChar)).Value = ncc.DiaChi;
            sqlComm.Parameters.Add(new SqlParameter("@email", SqlDbType.NChar)).Value = ncc.Email;
            sqlComm.Parameters.Add(new SqlParameter("@sdt", SqlDbType.NChar)).Value = ncc.SDT;
            sqlComm.Parameters.Add(new SqlParameter("@mancc", SqlDbType.NChar)).Value = ncc.MaNCC;
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }

        public Boolean ThemNhaCungCap(NhaCungCap ncc)
        {
            OpenConn();
            string sql = "insert into NhaCungCap values(@mancc,@tenncc,@diachi,@email,@sdt)";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@mancc", SqlDbType.NChar)).Value = ncc.MaNCC;
            sqlComm.Parameters.Add(new SqlParameter("@tenncc", SqlDbType.NVarChar)).Value = ncc.TenNCC;
            sqlComm.Parameters.Add(new SqlParameter("@diachi", SqlDbType.NVarChar)).Value = ncc.DiaChi;
            sqlComm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar)).Value = ncc.Email;
            sqlComm.Parameters.Add(new SqlParameter("@sdt", SqlDbType.NVarChar)).Value = ncc.SDT;
            int kq = sqlComm.ExecuteNonQuery();
            CloseConn();

            if (kq != 0)
                return true;

            return false;
        }


        public List<NhaCungCap> TimNhaCungCap(string maNCC, string tenNCC)
        {
            List<NhaCungCap> list = new List<NhaCungCap>();
            OpenConn();
            string sql = "select * from NhaCungCap where MaNCC = @maNCC or TenNCC = @tenNCC";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@MaNCC", SqlDbType.Char)).Value = maNCC;
            sqlComm.Parameters.Add(new SqlParameter("@tenNCC", SqlDbType.NVarChar)).Value = tenNCC;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNCC = sqlDr.GetString(0);
                ncc.TenNCC = sqlDr.GetString(1);
                ncc.DiaChi = sqlDr.GetString(2);
                ncc.Email = sqlDr.GetString(3);
                ncc.SDT = sqlDr.GetString(4);
                list.Add(ncc);
            }
            sqlDr.Close();
            CloseConn();

            return list;
        }

        public string TimMaNhaCungCap(string tenNCC)
        {
            string maNCC = "";
            OpenConn();
            string sql = "select MaNCC from NhaCungCap where TenNCC = @tenNCC";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tenNCC", SqlDbType.NChar)).Value = tenNCC;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            sqlDr.Read();
            maNCC = sqlDr.GetString(0);

            sqlDr.Close();
            CloseConn();

            return maNCC;
        }

        public List<NhaCungCap> LayNhaCungCap()
        {
            List<NhaCungCap> list = new List<NhaCungCap>();
            OpenConn();
            string sql = "select * from NhaCungCap";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNCC = sqlDr.GetString(0);
                ncc.TenNCC = sqlDr.GetString(1);
                ncc.DiaChi = sqlDr.GetString(2);
                ncc.Email = sqlDr.GetString(3);
                ncc.SDT = sqlDr.GetString(4);
                list.Add(ncc);
            }
            sqlDr.Close();
            CloseConn();

            return list;
        }
    }
}
