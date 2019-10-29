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
    public class NhaCungCapBUL
    {
        NhaCungCapDAL nccDAL = new NhaCungCapDAL();

        public Boolean XoaNhaCungCap(string mancc)
        {
            try
            {
                return nccDAL.XoaNhaCungCap(mancc);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }

        public Boolean CapNhatNhaCungCap(NhaCungCap ncc)
        {
            try
            {
                return nccDAL.CapNhatNhaCungCap(ncc);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }

        public Boolean ThemNhaCungCap(NhaCungCap ncc)
        {
            try
            {
                return nccDAL.ThemNhaCungCap(ncc);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }

        public List<NhaCungCap> TimNhaCungCap(string maNCC, string tenNCC)
        {
            List<NhaCungCap> list = new List<NhaCungCap>();
            try
            {
                return nccDAL.TimNhaCungCap(maNCC, tenNCC);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public string TimMaNhaCungCap(string tenNCC)
        {
            try
            {
                return nccDAL.TimMaNhaCungCap(tenNCC);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return "";
        }

        public List<NhaCungCap> LayNhaCungCap()
        {
            List<NhaCungCap> list = new List<NhaCungCap>();
            try
            {
                return nccDAL.LayNhaCungCap();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
    }
}
