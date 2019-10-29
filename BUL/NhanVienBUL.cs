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
    public class NhanVienBUL
    {
        NhanVienDAL nvDAL = new NhanVienDAL();

        public List<string> LayTenTaiKhoan()
        {
            try
            {
                return nvDAL.LayTenTaiKhoan();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }


        public string TimMaNhanVien(string tenNV)
        {
            try
            {
                return nvDAL.TimMaNhanVien(tenNV);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return "";
        }

        public List<string> LayTenNhanVien()
        {
            try
            {
                return nvDAL.LayTenNhanVien();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public Boolean XoaNhanVien(string maNV)
        {
            try
            {
                return nvDAL.XoaNhanVien(maNV);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }

        public Boolean CapNhatNhanVien(NhanVien nv)
        {
            try
            {
                return nvDAL.CapNhatNhanVien(nv);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }

        public Boolean ThemNhanVien(NhanVien nv)
        {
            try
            {
                return nvDAL.ThemNhanVien(nv);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }

        public List<NhanVien> TimNhanVien(string maNV, string tenNV)
        {
            try
            {
                return nvDAL.TimNhanVien(maNV, tenNV);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public List<NhanVien> LayNhanVien()
        {
            try
            {
                return nvDAL.LayNhanVien();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
    }
}
