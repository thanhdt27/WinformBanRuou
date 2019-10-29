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
    public class TaiKhoanDangNhapBUL
    {
        TaiKhoanDangNhapDAL tKDN = new TaiKhoanDangNhapDAL();

        public Boolean CapNhatTaiKhoan(TaiKhoanDangNhap tkdn)
        {
            try
            {
                return tKDN.CapNhatTaiKhoan(tkdn);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }

        public List<TaiKhoanDangNhap> TimTaiKhoan(string maTK, string tenDN, string maNV)
        {
            try
            {
                return tKDN.TimTaiKhoan(maTK, tenDN, maNV);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }

        public Boolean ThemTaiKhoan(TaiKhoanDangNhap tkdn)
        {
            try
            {
                return tKDN.ThemTaiKhoan(tkdn);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }

        public Boolean XoaTaiKhoan(string maTK, string tenDN, string maNV)
        {
            try
            {
                return tKDN.XoaTaiKhoan(maTK, tenDN, maNV);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }

        public List<NhanVien> LayTaiKhoan()
        {
            try
            {
                return tKDN.LayTaiKhoan();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }
        public string KiemTraDangNhap(string TenDangNhap, string MatKhau)
        {
            try
            {
                return tKDN.KiemTraDangNhap(TenDangNhap, MatKhau);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "";
            }
        }
    }
}
