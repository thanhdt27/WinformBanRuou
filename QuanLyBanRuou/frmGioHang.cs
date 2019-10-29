using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;

namespace QuanLyBanRuou
{
    public partial class frmGioHang : Form
    {
        public frmGioHang()
        {
            InitializeComponent();
        }
        SanPhamHoaDonBUL sphdBUL = new SanPhamHoaDonBUL();
        private void frmGioHang_Load(object sender, EventArgs e)
        {
            if (sphdBUL.LayGioHang() != null)
            {
                dgvListSanPhamMua.DataSource = sphdBUL.LayGioHang();
                txtThanhTien.Text = Convert.ToString(sphdBUL.ThanhTien());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
