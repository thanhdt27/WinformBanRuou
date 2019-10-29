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
    public class SanPhamBUL
    {
        SanPhamDAL spd = new SanPhamDAL();
        public SanPham TimSanPhamTheoMa(string maSP)
        {
            try
            {
                return spd.TimSanPhamTheoMa(maSP);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string TimMaSanPhamTheoTen(string tenSP)
        {
            try
            {
                return spd.TimMaSanPhamTheoTen(tenSP);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return "";

        }

        public Boolean XoaSanPham(string maSP, string tenSP)
        {
            try
            {
                return spd.XoaSanPham(maSP, tenSP);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }

        public Boolean CapNhatSanPham(SanPham sp)
        {
            try
            {
                return spd.CapNhatSanPham(sp);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }

        public Boolean ThemSanPham(SanPham sp)
        {
            try
            {
                return spd.ThemSanPham(sp);
            }
            catch (Exception e)
            {
                MessageBox.Show("Mã trùng");
            }

            return false;
        }

        public List<SanPham> TimSanPham(SanPham spTim, string TenDM, string TenNCC)
        {
            try
            {
                return spd.TimSanPham(spTim, TenDM, TenNCC);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public List<SanPham> TimTheoTenSanPham(string tenSP)
        {
            try
            {
                return spd.TimTheoTenSanPham(tenSP);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public List<SanPham> TimTheoDanhMuc(string dm)
        {
            try
            {
                return spd.TimTheoDanhMuc(dm);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public Boolean CapNhatSoLuong(string masanpham, int sl)
        {
            try
            {
                return spd.CapNhatSoLuong(masanpham,sl);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public List<SanPham> LaySanPham()
        {

            try
            {
                return spd.LaySanPham();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
    }
}
