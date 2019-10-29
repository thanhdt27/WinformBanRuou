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
    public partial class frmMainAdmin : Form
    {
        public frmMainAdmin()
        {
            InitializeComponent();
        }
        frmQuanLyDanhMuc fQLDM = new frmQuanLyDanhMuc();
        frmQuanLySanPham fQLSP = new frmQuanLySanPham();
        frmQuanLyNhanVien fQLNV = new frmQuanLyNhanVien();
        frmQuanLyNhaCungCap fQLNCC = new frmQuanLyNhaCungCap();
        frmBaoCaoDoanhThu fBCDT = new frmBaoCaoDoanhThu();
        private void switchForm(Form frm)
        {
            fBCDT.Hide();
            fQLDM.Hide();
            fQLSP.Hide();
            fQLNV.Hide();
            fQLNCC.Hide();
            frm.MdiParent = this;
            frm.Show();
            //this.Show();
        }
        private void frmMainAdmin_Load(object sender, EventArgs e)
        {
            fQLSP.MdiParent = this;
            fQLSP.Show();
        }

        private void tmnQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            frmQuanLyDanhMuc fQLDM = new frmQuanLyDanhMuc();
            switchForm(fQLDM);
        }

        private void mntQuanLySanPham_Click(object sender, EventArgs e)
        {
            frmQuanLySanPham fQLSP = new frmQuanLySanPham();
            switchForm(fQLSP);
        }

        private void tmnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien fQLNV = new frmQuanLyNhanVien();
            switchForm(fQLNV);
        }

        private void tmnDongUngDung_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void tmnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            
        }

        private void tmnDangXuat_Click(object sender, EventArgs e)
        {
            
            fQLDM.Close();
            fQLSP.Close();
            fQLNV.Close();
            this.Close();
        }

        private void frmMainAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void menuAdmin_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tmnQuanLyNhaCungCap_Click(object sender, EventArgs e)
        {
            frmQuanLyNhaCungCap fQLNCC = new frmQuanLyNhaCungCap();
            switchForm(fQLNCC);
        }

        private void tmnBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            frmBaoCaoDoanhThu fBCDT = new frmBaoCaoDoanhThu();
            switchForm(fBCDT);
        }
    }
}
