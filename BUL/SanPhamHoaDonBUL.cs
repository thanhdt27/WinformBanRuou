using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Windows.Forms;

namespace BUL
{
    public class SanPhamHoaDonBUL
    {
        SanPhamHoaDonDAL sphdd = new SanPhamHoaDonDAL();

        public void XoaBangSanPhamHoaDon()
        {
            try
            {
                sphdd.XoaBangSanPhamHoaDon();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public int ThanhTien()
        {
            try
            {
                return sphdd.ThanhTien();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }

        public List<SanPhamHoaDon> LayGioHang()
        {
            try
            {
                return sphdd.LayGioHang();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Boolean ThemGioHang(SanPhamHoaDon sphd)
        {
            try
            {
                return sphdd.ThemGioHang(sphd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }
    }
}
