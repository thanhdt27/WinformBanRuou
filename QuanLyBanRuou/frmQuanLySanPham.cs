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
    public partial class frmQuanLySanPham : Form
    {
        SanPhamBUL spBUL = new SanPhamBUL();
        DanhMucBUL dmBUL = new DanhMucBUL();
        NhaCungCapBUL nccBUL = new NhaCungCapBUL();
        public frmQuanLySanPham()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string TenDM;
            string TenNCC;
            if (txtMaSanPham.Text == "" && txtTenSanPham.Text == "" && cmbDanhMuc.SelectedIndex == -1 && cmbNhaCungCap.SelectedIndex == -1) {
                MessageBox.Show("Phải Nhập 1 trường nào đó để tìm !");
                return;
            }
            if (cmbDanhMuc.SelectedIndex != -1)
                TenDM = cmbDanhMuc.SelectedItem.ToString();
            else TenDM = "";
            if (cmbNhaCungCap.SelectedIndex != -1)
                TenNCC = cmbNhaCungCap.SelectedItem.ToString();
            else TenNCC = "";

            SanPham sp = new SanPham();

            sp.MaSanPham = txtMaSanPham.Text;
            sp.TenSanPham = txtTenSanPham.Text;
            sp.DungTich = 0;
            sp.NongDo = 0;
            sp.SoLuong = 0;
            sp.DonGia = 0;
            sp.MaDanhMuc = "";
            sp.MaNCC = "";
            dgvSanPham.DataSource = spBUL.TimSanPham(sp,TenDM,TenNCC);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int trangHienTai = 1;
        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            foreach (DanhMucSanPham ele in dmBUL.LayDanhMuc())
            {
                cmbDanhMuc.Items.Add(ele.TenDanhMuc);
            }
            foreach (NhaCungCap ele in nccBUL.LayNhaCungCap())
            {
                cmbNhaCungCap.Items.Add(ele.TenNCC);
            }
            List<SanPham> list = new List<SanPham>();
            for (int i = 0; i < 6 * trangHienTai; i++)
            {
                if(i<spBUL.LaySanPham().Count)
                    list.Add(spBUL.LaySanPham()[i]);
            }
            dgvSanPham.DataSource = list;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text == "" && txtTenSanPham.Text == "" && txtDungTich.Text == "" && txtNongDo.Text == "" && txtSoLuong.Text == "" && txtDonGia.Text == "")
            {
                MessageBox.Show("Không được để trống một trường dữ liệu nào");
                return;
            }
            if (txtMaSanPham.Text == "") {
                MessageBox.Show("Ma San Pham Không được để trống");
                return;
            }
            if (txtTenSanPham.Text == "")
            {
                MessageBox.Show("Tên San Pham Không được để trống");
                return;
            }
            if (txtDungTich.Text == "")
            {
                MessageBox.Show("Dung Tích Không được để trống");
                return;
            }
            if (txtNongDo.Text == "")
            {
                MessageBox.Show("Nồng Độ Không được để trống");
                return;
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Số Lượng Không được để trống");
                return;
            }
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Đơn Giá Không được để trống");
                return;
            }
            if (cmbDanhMuc.SelectedIndex == -1)
            {
                MessageBox.Show("Danh Muc Không được để trống");
                return;
            }
            if(cmbNhaCungCap.SelectedIndex==-1){
                MessageBox.Show("Nhà Cung Cấp Không được để trống");
                return;
            }
            string maDM = dmBUL.TimMaDanhMuc(cmbDanhMuc.SelectedItem.ToString());
            string maNCC = nccBUL.TimMaNhaCungCap(cmbNhaCungCap.SelectedItem.ToString());
            SanPham sp = new SanPham();
            sp.MaSanPham = txtMaSanPham.Text;
            sp.TenSanPham = txtTenSanPham.Text;
            try
            {
                int gt = Int32.Parse(txtDungTich.Text);
                sp.DungTich = gt;
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu của dung tích k hợp lệ. Xin kiểm tra lai!", "Thông báo");
                txtDungTich.Clear();
                txtDungTich.Focus();
                return;
            };
            try
            {
                int gt = Int32.Parse(txtNongDo.Text);
                sp.NongDo = gt;
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu của nồng độ k hợp lệ. Xin kiểm tra lai!", "Thông báo");
                txtNongDo.Clear();
                txtNongDo.Focus();
                return;
            };
            try
            {
                int gt = Int32.Parse(txtSoLuong.Text);
                sp.SoLuong = gt;
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu của số lượng k hợp lệ. Xin kiểm tra lai!", "Thông báo");
                txtSoLuong.Clear();
                txtSoLuong.Focus();
                return;
            };
            try
            {
                int gt = Int32.Parse(txtDonGia.Text);
                sp.DonGia = gt;
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu của đơn giá k hợp lệ. Xin kiểm tra lai!", "Thông báo");
                txtDonGia.Clear();
                txtDonGia.Focus();
                return;
            };
            
            sp.MaDanhMuc = maDM;
            sp.MaNCC = maNCC;

            if (spBUL.ThemSanPham(sp))
            {
                dgvSanPham.DataSource = spBUL.LaySanPham();
                txtMaSanPham.Text = "";
                txtTenSanPham.Text="";
                txtDungTich.Text = "";
                txtNongDo.Text = "";
                txtSoLuong.Text = "";
                txtDonGia.Text = "";
                cmbDanhMuc.SelectedIndex = -1;
                cmbNhaCungCap.SelectedIndex = -1;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text == "" && txtTenSanPham.Text == "" && txtDungTich.Text == "" && txtNongDo.Text == "" && txtSoLuong.Text == "" && txtDonGia.Text == "")
            {
                MessageBox.Show("Không được để trống một trường dữ liệu nào");
                return;
            }
            if (txtMaSanPham.Text == "")
            {
                MessageBox.Show("Ma San Pham Không được để trống");
                return;
            }
            
            if (txtTenSanPham.Text == "")
            {
                MessageBox.Show("Tên San Pham Không được để trống");
                return;
            }
            if (cmbDanhMuc.SelectedIndex == -1)
            {
                MessageBox.Show("Danh Muc Không được để trống");
                return;
            }
            if (cmbNhaCungCap.SelectedIndex == -1)
            {
                MessageBox.Show("Nhà Cung Cấp Không được để trống");
                return;
            }
            if (txtDungTich.Text == "")
            {
                MessageBox.Show("Dung Tích Không được để trống");
                return;
            }
            if (txtNongDo.Text == "")
            {
                MessageBox.Show("Nồng Độ Không được để trống");
                return;
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Số Lượng Không được để trống");
                return;
            }
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Đơn Giá Không được để trống");
                return;
            }
            
            string maDM = dmBUL.TimMaDanhMuc(cmbDanhMuc.SelectedItem.ToString());
            string maNCC = nccBUL.TimMaNhaCungCap(cmbNhaCungCap.SelectedItem.ToString());
            SanPham sp = new SanPham();
            sp.MaSanPham = txtMaSanPham.Text;
            sp.TenSanPham = txtTenSanPham.Text;
            try
            {
                int gt = Int32.Parse(txtDungTich.Text);
                sp.DungTich = gt;
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu của dung tích k hợp lệ. Xin kiểm tra lai!", "Thông báo");
                txtDungTich.Clear();
                txtDungTich.Focus();
                return;
            };
            try
            {
                int gt = Int32.Parse(txtNongDo.Text);
                sp.NongDo = gt;
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu của nồng độ k hợp lệ. Xin kiểm tra lai!", "Thông báo");
                txtNongDo.Clear();
                txtNongDo.Focus();
                return;
            };
            try
            {
                int gt = Int32.Parse(txtSoLuong.Text);
                sp.SoLuong = gt;
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu của số lượng k hợp lệ. Xin kiểm tra lai!", "Thông báo");
                txtSoLuong.Clear();
                txtSoLuong.Focus();
                return;
            };
            try
            {
                int gt = Int32.Parse(txtDonGia.Text);
                sp.DonGia = gt;
            }
            catch
            {
                MessageBox.Show("Kiểu dữ liệu của đơn giá k hợp lệ. Xin kiểm tra lai!", "Thông báo");
                txtDonGia.Clear();
                txtDonGia.Focus();
                return;
            };

            sp.MaDanhMuc = maDM;
            sp.MaNCC = maNCC;
            if (spBUL.CapNhatSanPham(sp))
            {
                dgvSanPham.DataSource = spBUL.TimTheoTenSanPham(sp.TenSanPham);
                txtMaSanPham.Text = "";
                txtTenSanPham.Text = "";
                txtDungTich.Text = "";
                txtNongDo.Text = "";
                txtSoLuong.Text = "";
                txtDonGia.Text = "";
                cmbDanhMuc.SelectedIndex = -1;
                cmbNhaCungCap.SelectedIndex = -1;
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvSanPham.CurrentCell.RowIndex;
            txtMaSanPham.Text = dgvSanPham.Rows[index].Cells[0].Value.ToString();
            txtTenSanPham.Text = dgvSanPham.Rows[index].Cells[1].Value.ToString();
            txtDungTich.Text = dgvSanPham.Rows[index].Cells[2].Value.ToString();
            txtNongDo.Text = dgvSanPham.Rows[index].Cells[3].Value.ToString();
            txtSoLuong.Text = dgvSanPham.Rows[index].Cells[4].Value.ToString();
            txtDonGia.Text = dgvSanPham.Rows[index].Cells[5].Value.ToString();
            string mdm = dgvSanPham.Rows[index].Cells[6].Value.ToString();
            string mncc = dgvSanPham.Rows[index].Cells[7].Value.ToString();
            List<DanhMucSanPham> list = new List<DanhMucSanPham>();
            list = dmBUL.LayDanhMuc();
            foreach (DanhMucSanPham ele in list)
            {
                if (ele.MaDanhMuc == mdm)
                {
                    cmbDanhMuc.SelectedItem = ele.TenDanhMuc;
                }
            }

            List<NhaCungCap> list2 = new List<NhaCungCap>();
            list2 = nccBUL.LayNhaCungCap();
            foreach (NhaCungCap ele in list2)
            {
                if (ele.MaNCC == mncc)
                {
                    cmbNhaCungCap.SelectedItem = ele.TenNCC;
                }
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSanPham.Text;
            string tenSP = txtTenSanPham.Text;
            if (txtMaSanPham.Text == "" && txtTenSanPham.Text == "") {
                
                    MessageBox.Show("Nhập Tên Sản Phẩm Hoặc Mã Sản Phẫm Để Xóa");
                    return;
                
            }
            if (spBUL.XoaSanPham(maSP, tenSP))
            {
                txtMaSanPham.Text = "";
                txtTenSanPham.Text = "";
                txtDungTich.Text = "";
                txtNongDo.Text = "";
                txtSoLuong.Text = "";
                txtDonGia.Text = "";
                cmbDanhMuc.SelectedIndex = -1;
                cmbNhaCungCap.SelectedIndex = -1;
                dgvSanPham.DataSource = spBUL.LaySanPham();
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (trangHienTai > 1)
                trangHienTai--;
            List<SanPham> list = new List<SanPham>();
            list = spBUL.LaySanPham();
            List<SanPham> listSP = new List<SanPham>();
            for (int i = 6 * (trangHienTai - 1); i < 6 * trangHienTai; i++)
            {
                if (i < list.Count)
                {
                    listSP.Add(list[i]);
                }
            }
            dgvSanPham.DataSource = listSP;
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            List<SanPham> list = new List<SanPham>();
            list = spBUL.LaySanPham();
            List<SanPham> listSP = new List<SanPham>();

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
            dgvSanPham.DataSource = listSP;
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            List<SanPham> list = new List<SanPham>();
            for (int i = 0; i < 6 * trangHienTai; i++)
            {
                if (i < spBUL.LaySanPham().Count)
                    list.Add(spBUL.LaySanPham()[i]);
            }
            dgvSanPham.DataSource = list;
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtDungTich.Text = "";
            txtNongDo.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            cmbDanhMuc.SelectedIndex = -1;
            cmbNhaCungCap.SelectedIndex = -1;
        }
    }
}
