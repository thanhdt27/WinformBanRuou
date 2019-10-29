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
    public partial class frmQuanLyNhanVien : Form
    {
        NhanVienBUL nvBUL = new NhanVienBUL();
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        int trangHienTai = 1;
        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            radNam.Checked = true;
            List<NhanVien> list = new List<NhanVien>();
            for (int i = 0; i < 6 * trangHienTai; i++)
            {
                if (i < nvBUL.LayNhanVien().Count)
                    list.Add(nvBUL.LayNhanVien()[i]);
            }
            dgvNhanVien.DataSource = list;

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNhanVien.Text;
            string tenNV = txtTenNhanVien.Text;
            dgvNhanVien.DataSource = nvBUL.TimNhanVien(maNV, tenNV);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string gioiTinh = "";
            if (radNam.Checked)
                gioiTinh = "Nam";
            else gioiTinh = "Nu";
            if (txtMaNhanVien.Text == "" || txtTenNhanVien.Text == "" || txtSDT.Text==""||gioiTinh=="")
            {
                MessageBox.Show("Không được để trống");
                return;
            }

    //kiem tra trung ten tai khoan
            int kiemtratrungtentaikhoan = 0;
            foreach (string ele in nvBUL.LayTenTaiKhoan())
            {
                if (ele.Equals(txtTaiKhoan.Text))
                {
                    kiemtratrungtentaikhoan = 1;
                }
            }
            if (kiemtratrungtentaikhoan == 1)
            {
                MessageBox.Show("Tai khoan da ton tai nhap tai khoan khac");
                txtTaiKhoan.Text = "";
                txtTaiKhoan.Focus();
                return;
            }
            //-----hetkiemtra trung tai khoan

            try
            {
                int gt = Int32.Parse(txtSDT.Text);
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu của số điện thoại k hợp lệ. Xin kiểm tra lai!", "Thông báo");
                txtSDT.Clear();
                txtSDT.Focus();
                return;
            };
            NhanVien nv = new NhanVien();
            nv.MaNhanVien = txtMaNhanVien.Text;
            nv.TenNhanVien = txtTenNhanVien.Text;
            
            nv.GioiTinh = gioiTinh;
            nv.SDT = txtSDT.Text;

            nv.TenDangNhap = txtTaiKhoan.Text;
            nv.MatKhau = txtMatKhau.Text;
            nv.LoaiTaiKhoan = cmbLoaiTaiKhoan.SelectedItem.ToString();
            if (nvBUL.ThemNhanVien(nv))
            {
                dgvNhanVien.DataSource = nvBUL.LayNhanVien();
            }
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtSDT.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            cmbLoaiTaiKhoan.SelectedIndex = -1;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MaNhanVien = txtMaNhanVien.Text;
            nv.TenNhanVien = txtTenNhanVien.Text;
            string gioiTinh = "";
            if (radNam.Checked)
                gioiTinh = "Nam";
            else gioiTinh = "Nu";

            //kiem tra trung ten tai khoan
            int kiemtratrungtentaikhoan = 0;
            foreach (string ele in nvBUL.LayTenTaiKhoan())
            {
                if (ele.Equals(txtTaiKhoan.Text))
                {
                    kiemtratrungtentaikhoan = 1;
                }
            }
            if (kiemtratrungtentaikhoan == 1)
            {
                MessageBox.Show("Tai khoan da ton tai nhap tai khoan khac");
                txtTaiKhoan.Text = "";
                txtTaiKhoan.Focus();
                return;
            }
            //-----hetkiemtra trung tai khoan

            try
            {
                int gt = Int32.Parse(txtSDT.Text);
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu của số lượng k hợp lệ. Xin kiểm tra lai!", "Thông báo");
                txtSDT.Clear();
                txtSDT.Focus();
                return;
            };
            nv.GioiTinh = gioiTinh;
            nv.SDT = txtSDT.Text;
            nv.TenDangNhap = txtTaiKhoan.Text;
            nv.MatKhau = txtMatKhau.Text;
            nv.LoaiTaiKhoan = cmbLoaiTaiKhoan.SelectedItem.ToString();

            if (nvBUL.CapNhatNhanVien(nv))
            {
                dgvNhanVien.DataSource = nvBUL.TimNhanVien(nv.MaNhanVien, nv.TenNhanVien);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNhanVien.Text;
            string tenNV = txtTenNhanVien.Text;
            if (nvBUL.XoaNhanVien(maNV))
            {
                dgvNhanVien.DataSource = nvBUL.LayNhanVien();
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (trangHienTai > 1)
                trangHienTai--;
            List<NhanVien> list = new List<NhanVien>();
            list = nvBUL.LayNhanVien();
            List<NhanVien> listSP = new List<NhanVien>();
            for (int i = 6 * (trangHienTai - 1); i < 6 * trangHienTai; i++)
            {
                if (i < list.Count)
                {
                    listSP.Add(list[i]);
                }
            }
            dgvNhanVien.DataSource = listSP;
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            List<NhanVien> list = new List<NhanVien>();
            list = nvBUL.LayNhanVien();
            List<NhanVien> listSP = new List<NhanVien>();

            double d = list.Count / 6.0;
            int soTrang = (int)Math.Ceiling(d);
            if (trangHienTai < soTrang)
                trangHienTai++;


            for (int i = 6 * (trangHienTai - 1); i < 6 * trangHienTai; i++)
            {
                if (i < list.Count)
                {
                    listSP.Add(list[i]);
                }
            }
            dgvNhanVien.DataSource = listSP;
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtSDT.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            cmbLoaiTaiKhoan.SelectedIndex = -1;
            radNam.Checked = true;
            List<NhanVien> list = new List<NhanVien>();
            for (int i = 0; i < 6 * trangHienTai; i++)
            {
                if (i < nvBUL.LayNhanVien().Count)
                    list.Add(nvBUL.LayNhanVien()[i]);
            }
            dgvNhanVien.DataSource = list;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvNhanVien.CurrentCell.RowIndex;
            txtMaNhanVien.Text = dgvNhanVien.Rows[index].Cells[0].Value.ToString();
            txtTenNhanVien.Text = dgvNhanVien.Rows[index].Cells[1].Value.ToString();
            txtTaiKhoan.Text = dgvNhanVien.Rows[index].Cells[4].Value.ToString();
            txtMatKhau.Text = dgvNhanVien.Rows[index].Cells[5].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[index].Cells[3].Value.ToString();
            if (dgvNhanVien.Rows[index].Cells[2].Value.ToString().Trim().Equals("Nam"))
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
            cmbLoaiTaiKhoan.SelectedItem = dgvNhanVien.Rows[index].Cells[6].Value.ToString();
        }
    }
}
