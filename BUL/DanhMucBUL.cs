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
    public class DanhMucBUL
    {
        DanhMucDAL dmd = new DanhMucDAL();

        public string TimMaDanhMuc(string tenDM)
        {
            try
            {
                return dmd.TimMaDanhMuc(tenDM);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return "";
        }

        public Boolean XoaDanhMuc(DanhMucSanPham dmsp)
        {
            try
            {
                return dmd.XoaDanhMuc(dmsp);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }

        public Boolean CapNhatDanhMuc(DanhMucSanPham dmsp)
        {
            try
            {
                return dmd.CapNhatDanhMuc(dmsp);
            }
            catch (Exception e)
            {
                //MessageBox.Show("");
            }
            return false;
        }

        public Boolean ThemDanhMuc(DanhMucSanPham dmsp)
        {
            try
            {
                return dmd.ThemDanhMuc(dmsp);
            }
            catch (Exception e)
            {
                MessageBox.Show("Mã Danh mục đã tồn tại");
            }
            return false;
        }

        public List<DanhMucSanPham> TimDanhMuc(string maDM, string tenDM)
        {
            List<DanhMucSanPham> list = new List<DanhMucSanPham>();
            try
            {
                return dmd.TimDanhMuc(maDM, tenDM);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return list;
        }

        public List<DanhMucSanPham> LayDanhMuc()
        {
            List<DanhMucSanPham> list = new List<DanhMucSanPham>();
            try
            {
                return dmd.LayDanhMuc();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return list;
        }
    }
}
