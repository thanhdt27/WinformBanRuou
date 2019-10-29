using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace BUL
{
    public class ChiTietHoaDonBUL
    {
        ChiTietHoaDonDAL cthdDAL = new ChiTietHoaDonDAL();

        public DataSet BaoCaoDoanhThu(string tungay, string denngay)
        {
            try
            {
                return cthdDAL.BaoCaoDoanhThu(tungay,denngay);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public DataSet LayDataSet(int mahd)
        {
            try
            {
                return cthdDAL.LayDataSet(mahd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public List<ChiTietHoaDon> TimTheoMaHoaDon(int mahd)
        {
            try
            {
                return cthdDAL.TimTheoMaHoaDon(mahd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public Boolean ThemChiTietHoaDon(ChiTietHoaDon cthd)
        {
            try
            {
                return cthdDAL.ThemChiTietHoaDon(cthd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
    }
}
