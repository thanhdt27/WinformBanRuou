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
    public class ChiTietHoaDonDAL:KetNoi
    {
        public DataSet BaoCaoDoanhThu(string tungay, string denngay)
        {
            DataSet ds = new DataSet();
            OpenConn();
            string sql = "select SanPham.TenSanPham, SanPham.DungTich, SanPham.NongDo, SanPham.DonGia, sum(ChiTietHoaDon.SoLuong) as SoLuongBan, sum(ChiTietHoaDon.SoLuong * SanPham.DonGia) as ThanhTien from SanPham, ChiTietHoaDon, HoaDon where SanPham.MaSanPham = ChiTietHoaDon.MaSanPham and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon  and HoaDon.Ngay>='"+tungay+"' and HoaDon.Ngay<='"+denngay+"' group by SanPham.TenSanPham, SanPham.DungTich, SanPham.NongDo, SanPham.DonGia";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sql, conn);
            sqlDa.Fill(ds, "BaoCaoDoanhThu");

            CloseConn();

            return ds;
        }

        public DataSet LayDataSet(int mahd)
        {
            DataSet ds = new DataSet();
            OpenConn();
            string sql = "select SanPham.TenSanPham, SanPham.DungTich, SanPham.NongDo, ChiTietHoaDon.SoLuong, SanPham.DonGia  from SanPham, ChiTietHoaDon where SanPham.MaSanPham = ChiTietHoaDon.MaSanPham and ChiTietHoaDon.MaHoaDon='"+mahd+"'";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sql, conn);
            sqlDa.Fill(ds,"SanPham");

            CloseConn();

            return ds;
        }

        public List<ChiTietHoaDon> TimTheoMaHoaDon(int mahd)
        {
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();
            OpenConn();
            string sql = "select * from ChiTietHoaDon where MaHoaDon=@mahd";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@mahd", SqlDbType.NChar)).Value = mahd;
            SqlDataReader sqlDr = sqlComm.ExecuteReader();
            while (sqlDr.Read())
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.MaHoaDon = sqlDr.GetInt32(0);
                cthd.MaSanPham = sqlDr.GetString(1);
                cthd.SoLuong = sqlDr.GetInt32(2);
                list.Add(cthd);
            }
            sqlDr.Close();
            CloseConn();
            return list;
        }
        public void xoaChiTietHoaDonKhiXoaSanPham(string masp)
        {
            OpenConn();
            string sql = "delete ChiTietHoaDon where MaSanPham=@masp";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@masp", SqlDbType.NChar)).Value = masp;
            sqlComm.ExecuteNonQuery();
            CloseConn();

        }
        public Boolean ThemChiTietHoaDon(ChiTietHoaDon cthd)
        {
            OpenConn();
            string sql = "insert into ChiTietHoaDon values(@maHD,@maSP,@soluong)";
            SqlCommand sqlComm = new SqlCommand(sql, conn);
            sqlComm.Parameters.Add(new SqlParameter("@maHD", SqlDbType.NChar)).Value = cthd.MaHoaDon;
            sqlComm.Parameters.Add(new SqlParameter("@soluong", SqlDbType.Int)).Value = cthd.SoLuong;
            sqlComm.Parameters.Add(new SqlParameter("@maSP", SqlDbType.NChar)).Value = cthd.MaSanPham;
            int kq = sqlComm.ExecuteNonQuery();
            CloseConn();
            if (kq != 0)
                return true;

            return false;
        }
    }
}
