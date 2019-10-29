using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanRuou
{
    public partial class frmMainNhanVien : Form
    {
        public frmMainNhanVien()
        {
            InitializeComponent();
        }

        public frmTrangChu fTC = new frmTrangChu();
        public frmLapHoaDon fLHD = new frmLapHoaDon();
        public frmXemHoaDon fXHD = new frmXemHoaDon();

        private void switchForm(Form frm)
        {
            fTC.Hide();
            fLHD.Hide();
            fXHD.Hide();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tmiTrangChu_Click(object sender, EventArgs e)
        {
            switchForm(fTC);
        }

        private void tmiLapHoaDon_Click(object sender, EventArgs e)
        {
            switchForm(fLHD);
        }

        private void tmiXemHoaDon_Click(object sender, EventArgs e)
        {
            switchForm(fXHD);
        }

        private void frmMainAdmin_Load(object sender, EventArgs e)
        {
            fTC.MdiParent = this;
            fTC.Show();
        }

        private void tmiDangXuat_Click(object sender, EventArgs e)
        {
            fTC.Close();
            fLHD.Close();
            fXHD.Close();
            this.Close();
        }
    }
}
