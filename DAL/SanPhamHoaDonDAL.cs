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
    public class SanPhamHoaDonDAL:KetNoi
    {
        public void XoaBangSanPhamHoaDon()
        {
            OpenConn();
            string sql = "delete SanPhamHoaDon";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
        }

        public int ThanhTien()
        {
            int thanhtien = 0;
            OpenConn();
            string sql = "select sum(SoLuong*DonGia) from SanPhamHoaDon";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            thanhtien = (int)sqlComm.ExecuteScalar();

            CloseConn();

            return thanhtien;
        }

        public List<SanPhamHoaDon> LayGioHang()
        {
            List<SanPhamHoaDon> list = new List<SanPhamHoaDon>();
            OpenConn();
            string sql = "select * from SanPhamHoaDon";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                SanPhamHoaDon sphd = new SanPhamHoaDon();
                sphd.TenSanPham = sqlDr.GetString(0);
                sphd.DungTich = sqlDr.GetInt32(1);
                sphd.NongDo = sqlDr.GetInt32(2);
                sphd.SoLuongMua = sqlDr.GetInt32(3);
                sphd.DonGia = sqlDr.GetInt32(4);
                list.Add(sphd);
            }
            sqlDr.Close();

            CloseConn();
            return list;
        }

        public Boolean ThemGioHang(SanPhamHoaDon sphd)
        {
            OpenConn();
            string sql = "insert into SanPhamHoaDon values(@tensanpham,@dungtich,@nongdo,@soluongmua,@dongia)";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@tensanpham", SqlDbType.NVarChar)).Value = sphd.TenSanPham;
            sqlComm.Parameters.Add(new SqlParameter("@dungtich", SqlDbType.Int)).Value = sphd.DungTich;
            sqlComm.Parameters.Add(new SqlParameter("@nongdo", SqlDbType.Int)).Value = sphd.NongDo;
            sqlComm.Parameters.Add(new SqlParameter("@soluongmua", SqlDbType.Int)).Value = sphd.SoLuongMua;
            sqlComm.Parameters.Add(new SqlParameter("@dongia", SqlDbType.Int)).Value = sphd.DonGia;
            int kq = sqlComm.ExecuteNonQuery();

            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }
    }
}
