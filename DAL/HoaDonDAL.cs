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
    public class HoaDonDAL:KetNoi
    {
        public HoaDon LayHoaDonCuoiCung(int mahd)
        {
            OpenConn();
            HoaDon hd = null;
            string sql = "select * from HoaDon where MaHoaDon='"+mahd+"'";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            if (sqlDr.Read())
            {
                hd = new HoaDon();
                hd.MaHoaDon = sqlDr.GetInt32(0);
                hd.Ngay = sqlDr.GetDateTime(1).ToString();
                hd.ThanhTien = sqlDr.GetInt32(2);
                hd.TenKhachHang = sqlDr.GetString(3);
                hd.MaNhanVien = sqlDr.GetString(4);
            }
            sqlDr.Close();

            CloseConn();
            return hd;

        }

        public int TimMaHoaDonCuoiCung()
        {
            int a = 0;
            OpenConn();
            string sql = "select TOP 1 MaHoaDon from HoaDon order by MaHoaDon desc";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            if (sqlDr.Read())
                a = sqlDr.GetInt32(0);

            sqlDr.Close();
            CloseConn();
            return a;
        }

        public List<HoaDon> TimHoaDon(string tungay, string denngay)
        {
            List<HoaDon> list = new List<HoaDon>();
            OpenConn();
            string sql = "select * from HoaDon where Ngay >= @tungay and Ngay <=@denngay";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tungay", SqlDbType.Date)).Value = tungay;
            sqlComm.Parameters.Add(new SqlParameter("@denngay", SqlDbType.Date)).Value = denngay;
            
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                HoaDon hd = new HoaDon();
                hd.MaHoaDon = sqlDr.GetInt32(0);
                hd.Ngay = sqlDr.GetDateTime(1).ToString();
                hd.ThanhTien = sqlDr.GetInt32(2);
                hd.TenKhachHang = sqlDr.GetString(3);
                hd.MaNhanVien = sqlDr.GetString(4);
                list.Add(hd);
            }
            sqlDr.Close();
            CloseConn();

            return list;
        }

        public List<HoaDon> LayHoaDon()
        {
            List<HoaDon> list = new List<HoaDon>();
            OpenConn();
            string sql = "select * from HoaDon";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                HoaDon hd = new HoaDon();
                hd.MaHoaDon = sqlDr.GetInt32(0);
                hd.Ngay = sqlDr.GetDateTime(1).ToString();
                hd.ThanhTien = sqlDr.GetInt32(2);
                hd.TenKhachHang = sqlDr.GetString(3);
                hd.MaNhanVien = sqlDr.GetString(4);
                list.Add(hd);
            }
            sqlDr.Close();

            CloseConn();
            return list;

        }

        public Boolean ThemHoaDon(HoaDon hd)
        {
            OpenConn();
            string sql = "insert into HoaDon values(@ngay,@thanhTien,@tenKH,@maNV)";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            
            sqlComm.Parameters.Add(new SqlParameter("@ngay", SqlDbType.NVarChar)).Value = hd.Ngay;
            sqlComm.Parameters.Add(new SqlParameter("@thanhTien", SqlDbType.Int)).Value = hd.ThanhTien;
            sqlComm.Parameters.Add(new SqlParameter("@tenKH", SqlDbType.NVarChar)).Value = hd.TenKhachHang;
            sqlComm.Parameters.Add(new SqlParameter("@maNV", SqlDbType.NChar)).Value = hd.MaNhanVien;
            int kq = sqlComm.ExecuteNonQuery();
            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }
    }
}
