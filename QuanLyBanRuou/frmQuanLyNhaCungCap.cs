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
using System.Text.RegularExpressions;

namespace QuanLyBanRuou
{
    public partial class frmQuanLyNhaCungCap : Form
    {
        NhaCungCapBUL nccBUL = new NhaCungCapBUL();
        public frmQuanLyNhaCungCap()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        int trangHienTai = 1;
        private void frmQuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            List<NhaCungCap> list = new List<NhaCungCap>();
            for (int i = 0; i < 6 * trangHienTai; i++)
            {
                if (i < nccBUL.LayNhaCungCap().Count)
                    list.Add(nccBUL.LayNhaCungCap()[i]);
            }
            dgvNhaCungCap.DataSource = list;

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Không được để tên nhà cung cấp trống");
                txtTenNCC.Focus();
                return;
            }
            string maNCC = txtMaNCC.Text;
            string tenNCC = txtTenNCC.Text;
            dgvNhaCungCap.DataSource = nccBUL.TimNhaCungCap(maNCC, tenNCC);
        }
        private void xoaText()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChiNCC.Text = "";
            txtEmailNCC.Text = "";
            txtSDTNCC.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Mã Nhà cung cấp không được để trống");
                txtMaNCC.Focus();
                return;
            }
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Không được để tên nhà cung cấp trống");
                txtTenNCC.Focus();
                return;
            }
            try
            {
                double gt = double.Parse(txtSDTNCC.Text);
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu của SĐT k hợp lệ. Xin kiểm tra lai!", "Thông báo");
                txtSDTNCC.Clear();
                txtSDTNCC.Focus();
                return;
            };

            if (txtEmailNCC.Text == "")
            {
                MessageBox.Show("Email không được để trống");
                txtEmailNCC.Focus();
                return;
            }
            if (txtDiaChiNCC.Text == "")
            {
                MessageBox.Show("Địa chỉ nhà cung cấp không được để trống");
                txtMaNCC.Focus();
                return;
            }

            int a = 0;
            for (int i = 0; i < nccBUL.LayNhaCungCap().Count; i++)
            {
                if (nccBUL.LayNhaCungCap()[i].MaNCC == txtMaNCC.Text)
                {
                    MessageBox.Show("Đã tồn tại MaNCC");
                    a=1;
                }
            }
            if (a == 1) return;

            ncc.MaNCC = txtMaNCC.Text;
            ncc.TenNCC = txtTenNCC.Text;
            ncc.DiaChi = txtDiaChiNCC.Text;
            ncc.Email = txtEmailNCC.Text;
            ncc.SDT = txtSDTNCC.Text;
            if (nccBUL.ThemNhaCungCap(ncc))
            {
                dgvNhaCungCap.DataSource = nccBUL.LayNhaCungCap();
                xoaText();
            }
            else
            {
                MessageBox.Show("Khong thanh cong");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Mã Nhà cung cấp không được để trống");
                txtMaNCC.Focus();
                return;
            }
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Không được để tên nhà cung cấp trống");
                txtTenNCC.Focus();
                return;
            }
            try
            {
                double gt = double.Parse(txtSDTNCC.Text);
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu của SĐT k hợp lệ. Xin kiểm tra lai!", "Thông báo");
                txtSDTNCC.Clear();
                txtSDTNCC.Focus();
                return;
            };

            if (txtEmailNCC.Text == "")
            {
                MessageBox.Show("Email không được để trống");
                txtEmailNCC.Focus();
                return;
            }
            if (txtDiaChiNCC.Text == "")
            {
                MessageBox.Show("Địa chỉ nhà cung cấp không được để trống");
                txtMaNCC.Focus();
                return;
            }

            NhaCungCap ncc = new NhaCungCap();
            ncc.MaNCC = txtMaNCC.Text;
            ncc.TenNCC = txtTenNCC.Text;
            ncc.DiaChi = txtDiaChiNCC.Text;
            ncc.Email = txtEmailNCC.Text;
            ncc.SDT = txtSDTNCC.Text;
            if (nccBUL.CapNhatNhaCungCap(ncc))
            {
                dgvNhaCungCap.DataSource = nccBUL.TimNhaCungCap(ncc.MaNCC,ncc.TenNCC);
                xoaText();
            }
            else
            {
                MessageBox.Show("Khong thanh cong");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống");
                txtMaNCC.Focus();
                return;
            }
            string mancc = txtMaNCC.Text;
            if (nccBUL.XoaNhaCungCap(mancc))
            {
                dgvNhaCungCap.DataSource = nccBUL.LayNhaCungCap();
                txtMaNCC.Text = "";
                txtTenNCC.Text = "";
                txtDiaChiNCC.Text = "";
                txtEmailNCC.Text = "";
                txtSDTNCC.Text = "";
            }
            else
            {
                MessageBox.Show("Khong thanh cong");
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (trangHienTai > 1)
                trangHienTai--;
            List<NhaCungCap> list = new List<NhaCungCap>();
            list = nccBUL.LayNhaCungCap();
            List<NhaCungCap> listSP = new List<NhaCungCap>();
            for (int i = 6 * (trangHienTai - 1); i < 6 * trangHienTai; i++)
            {
                if (i < list.Count)
                {
                    listSP.Add(list[i]);
                }
            }
            dgvNhaCungCap.DataSource = listSP;
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            List<NhaCungCap> list = new List<NhaCungCap>();
            list = nccBUL.LayNhaCungCap();
            List<NhaCungCap> listSP = new List<NhaCungCap>();

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
            dgvNhaCungCap.DataSource = listSP;
        }

        private void txtSDTNCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChiNCC.Text = "";
            txtEmailNCC.Text = "";
            txtSDTNCC.Text = "";
            int index = dgvNhaCungCap.CurrentCell.RowIndex;
            if (index == -1)
                return;
            txtMaNCC.Text = dgvNhaCungCap.Rows[index].Cells[0].Value.ToString();
            txtTenNCC.Text = dgvNhaCungCap.Rows[index].Cells[1].Value.ToString();
            txtDiaChiNCC.Text = dgvNhaCungCap.Rows[index].Cells[2].Value.ToString();
            txtEmailNCC.Text = dgvNhaCungCap.Rows[index].Cells[3].Value.ToString();
            txtSDTNCC.Text = dgvNhaCungCap.Rows[index].Cells[4].Value.ToString();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChiNCC.Text = "";
            txtEmailNCC.Text = "";
            txtSDTNCC.Text = "";
            List<NhaCungCap> list = new List<NhaCungCap>();
            for (int i = 0; i < 6; i++)
            {
                if (i < nccBUL.LayNhaCungCap().Count)
                    list.Add(nccBUL.LayNhaCungCap()[i]);
            }
            dgvNhaCungCap.DataSource = list;
        }
    }
}
