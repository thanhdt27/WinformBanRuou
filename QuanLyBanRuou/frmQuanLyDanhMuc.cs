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
using DTO;

namespace QuanLyBanRuou
{
    public partial class frmQuanLyDanhMuc : Form
    {
        DanhMucBUL dmBUL = new DanhMucBUL();
        public frmQuanLyDanhMuc()
        {
            InitializeComponent();
        }
        int trangHienTai = 1;
        private void frmQuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            List<DanhMucSanPham> list = new List<DanhMucSanPham>();
            for (int i = 0; i < 6 * trangHienTai; i++)
            {
                if (i < dmBUL.LayDanhMuc().Count)
                {
                    list.Add(dmBUL.LayDanhMuc()[i]);
                }
                
            }
            dgvDanhMuc.DataSource = list;

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            
            if (txtTenDanhMuc.Text == "")
            {
                MessageBox.Show("Không được để tên danh mục trống");
                txtTenDanhMuc.Focus();
                return;
            }
            string maDM = txtMaDanhMuc.Text;
            string tenDM = txtTenDanhMuc.Text;
            dgvDanhMuc.DataSource = dmBUL.TimDanhMuc(maDM, tenDM);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaDanhMuc.Text == "")
            {
                MessageBox.Show("Không được để mã danh mục trống");
                txtMaDanhMuc.Focus();
                return;
            }
            if (txtTenDanhMuc.Text == "")
            {
                MessageBox.Show("Không được để tên danh mục trống");
                txtTenDanhMuc.Focus();
                return;
            }
            DanhMucSanPham dmsp = new DanhMucSanPham();
            if (txtMaDanhMuc.Text == "" || txtTenDanhMuc.Text == "")
            {
                MessageBox.Show("Nhập thông tin lỗi xin mời kiểm tra lại");
                return;
            }
            dmsp.MaDanhMuc = txtMaDanhMuc.Text;
            dmsp.TenDanhMuc = txtTenDanhMuc.Text;
            dmsp.MoTa = txtMoTa.Text;
            if (dmBUL.ThemDanhMuc(dmsp))
            {
                dgvDanhMuc.DataSource = dmBUL.TimDanhMuc(dmsp.MaDanhMuc, "");
                txtMaDanhMuc.Text = "";
                txtTenDanhMuc.Text = "";
                txtMoTa.Text = "";
            }
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaDanhMuc.Text == "")
            {
                MessageBox.Show("Không được để mã danh mục trống");
                txtMaDanhMuc.Focus();
                return;
            }
            if (txtTenDanhMuc.Text == "")
            {
                MessageBox.Show("Không được để tên danh mục trống");
                txtTenDanhMuc.Focus();
                return;
            }
            DanhMucSanPham dmsp = new DanhMucSanPham();
            if (txtMaDanhMuc.Text == "" || txtTenDanhMuc.Text == "")
            {
                MessageBox.Show("Nhập thông tin lỗi xin mời kiểm tra lại");
                return;
            }
            dmsp.MaDanhMuc = txtMaDanhMuc.Text;
            dmsp.TenDanhMuc = txtTenDanhMuc.Text;
            dmsp.MoTa = txtMoTa.Text;
            if (dmBUL.CapNhatDanhMuc(dmsp))
            {
                dgvDanhMuc.DataSource = dmBUL.TimDanhMuc(txtMaDanhMuc.Text, txtTenDanhMuc.Text);
            }
            else
            {
                MessageBox.Show("Khong thanh cong");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDanhMuc.Text == "")
            {
                MessageBox.Show("Không được để mã danh mục trống");
                txtMaDanhMuc.Focus();
                return;
            }
            
            DanhMucSanPham dmsp = new DanhMucSanPham();
            dmsp.MaDanhMuc = txtMaDanhMuc.Text;
            dmsp.TenDanhMuc = txtTenDanhMuc.Text;
            List<DanhMucSanPham> list = dmBUL.LayDanhMuc();
            
            if (dmBUL.XoaDanhMuc(dmsp))
            {
                //dgvDanhMuc.DataSource = dmBUL.LayDanhMuc();
                txtMaDanhMuc.Text = "";
                txtTenDanhMuc.Text = "";
                txtMoTa.Text = "";
            }
            else
            {
                MessageBox.Show("Khong thanh cong");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (trangHienTai > 1)
                trangHienTai--;
            List<DanhMucSanPham> list = new List<DanhMucSanPham>();
            list = dmBUL.LayDanhMuc();
            List<DanhMucSanPham> listSP = new List<DanhMucSanPham>();
            for (int i = 6 * (trangHienTai - 1); i < 6 * trangHienTai; i++)
            {
                if (i < list.Count)
                {
                    listSP.Add(list[i]);
                }
            }
            dgvDanhMuc.DataSource = listSP;
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            List<DanhMucSanPham> list = new List<DanhMucSanPham>();
            list = dmBUL.LayDanhMuc();
            List<DanhMucSanPham> listSP = new List<DanhMucSanPham>();

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
            dgvDanhMuc.DataSource = listSP;
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvDanhMuc.CurrentCell.RowIndex;

            txtMoTa.Text = "";
            txtMaDanhMuc.Text = dgvDanhMuc.Rows[index].Cells[0].Value.ToString();
            txtTenDanhMuc.Text = dgvDanhMuc.Rows[index].Cells[1].Value.ToString();
            txtMoTa.Text = dgvDanhMuc.Rows[index].Cells[2].Value.ToString();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            List<DanhMucSanPham> list = new List<DanhMucSanPham>();
            for (int i = 0; i < 6; i++)
            {
                if (i < dmBUL.LayDanhMuc().Count)
                {
                    list.Add(dmBUL.LayDanhMuc()[i]);
                }

            }
            dgvDanhMuc.DataSource = list;
            txtMaDanhMuc.Text = "";
            txtTenDanhMuc.Text = "";
            txtMoTa.Text = "";
        }
        

        
    }
}
