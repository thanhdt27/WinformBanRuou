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
    public class HoaDonBUL
    {
        HoaDonDAL hdDAL = new HoaDonDAL();

        public int TimMaHoaDonCuoiCung()
        {
            try
            {
                return hdDAL.TimMaHoaDonCuoiCung();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return 0;
        }

        public List<HoaDon> TimHoaDon(string tungay, string denngay)
        {
            try
            {
                return hdDAL.TimHoaDon(tungay, denngay);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public HoaDon LayHoaDonCuoiCung(int mahd)
        {
            try
            {
                return hdDAL.LayHoaDonCuoiCung(mahd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public List<HoaDon> LayHoaDon()
        {
            try
            {
                return hdDAL.LayHoaDon();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
        public Boolean ThemHoaDon(HoaDon hd)
        {
            try
            {
                return hdDAL.ThemHoaDon(hd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
    }
}
