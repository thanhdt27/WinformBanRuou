using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUL;

namespace QuanLyBanRuou
{
    public partial class frmDangNhap : Form
    {
        TaiKhoanDangNhapBUL tKDNBul = new TaiKhoanDangNhapBUL();
        public frmDangNhap()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            frmMainAdmin fMA = new frmMainAdmin();
            frmMainNhanVien fMNV = new frmMainNhanVien();
            string loaiTaiKhoan = tKDNBul.KiemTraDangNhap(txtTenDangNhap.Text, txtMatKhau.Text);
            txtMatKhau.Text = "";
            if (loaiTaiKhoan == "Admin")
            {
                this.Hide();
                fMA.ShowDialog();
                this.Show();
            }else
            if (loaiTaiKhoan == "User")
            {
                this.Hide();
                fMNV.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai Ten Dang Nhap hoac mat Khau");
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn tắt chương trình", "Mess", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if(ret == DialogResult.Yes)
            this.Close();
        }

        private void chbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHienMatKhau.Checked)
                txtMatKhau.UseSystemPasswordChar = false;
            else txtMatKhau.UseSystemPasswordChar = true;
        }
    }
}
