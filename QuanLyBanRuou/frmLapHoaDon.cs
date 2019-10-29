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
    public partial class frmLapHoaDon : Form
    {
        SanPhamHoaDonBUL sphdBUL = new SanPhamHoaDonBUL();
        frmTrangChu ftc = new frmTrangChu();
        NhanVienBUL nvBUL = new NhanVienBUL();
        HoaDonBUL hdBUL = new HoaDonBUL();
        ChiTietHoaDonBUL cthdBUL = new ChiTietHoaDonBUL();
        SanPhamBUL spBUL = new SanPhamBUL();
        public frmLapHoaDon()
        {
            InitializeComponent();
        }

        private void frmLapHoaDon_Load(object sender, EventArgs e)
        {
            foreach (string ele in nvBUL.LayTenNhanVien())
            {
                cmbTenNhanVien.Items.Add(ele);
            }
            if (sphdBUL.LayGioHang() != null)
            {
                dgvListSanPhamMua.DataSource = sphdBUL.LayGioHang();
                txtThanhTien.Text = Convert.ToString(sphdBUL.ThanhTien());
            }
        }
        //public void Load()
        //{
        //    foreach (string ele in nvBUL.LayTenNhanVien())
        //    {
        //        cmbTenNhanVien.Items.Add(ele);
        //    }
        //}

        private void dgvListSanPhamMua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnLoadGioHang_Click(object sender, EventArgs e)
        {
            if (sphdBUL.LayGioHang() != null)
            {
                dgvListSanPhamMua.DataSource = sphdBUL.LayGioHang();
                txtThanhTien.Text = Convert.ToString(sphdBUL.ThanhTien());
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            

        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if (txtTenKhach.Text == "" || cmbTenNhanVien.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                return;
            }

            string tenKH = txtTenKhach.Text;
            string ngayLap = dtpNgayLap.Value.Year.ToString() + "-"
                + dtpNgayLap.Value.Month.ToString() + "-" + dtpNgayLap.Value.Day.ToString();
            int thanhTien=0;
            try
            {
                thanhTien = Int32.Parse(txtThanhTien.Text);
            }
            catch (Exception ea) { Console.WriteLine(ea.Message); }
             
            string maNV = "";
            if (cmbTenNhanVien.SelectedIndex != -1)
                maNV = nvBUL.TimMaNhanVien(cmbTenNhanVien.SelectedItem.ToString());

            HoaDon hd = new HoaDon();
            hd.MaHoaDon = 1;
            hd.TenKhachHang = tenKH;
            hd.Ngay = ngayLap;
            hd.ThanhTien = thanhTien;
            hd.MaNhanVien = maNV;

            hdBUL.ThemHoaDon(hd);
            int a = hdBUL.TimMaHoaDonCuoiCung();
            foreach (SanPhamHoaDon ele in sphdBUL.LayGioHang())
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.MaHoaDon = a;
                cthd.SoLuong = ele.SoLuongMua;
                cthd.MaSanPham = spBUL.TimMaSanPhamTheoTen(ele.TenSanPham);
                cthdBUL.ThemChiTietHoaDon(cthd);
            }
            frmInHoaDon f = new frmInHoaDon();
            f.Show();
            sphdBUL.XoaBangSanPhamHoaDon();
            
            txtTenKhach.Text = "";
            txtThanhTien.Text = "";
            cmbTenNhanVien.SelectedIndex = -1;
            dgvListSanPhamMua.DataSource = null;
            //MessageBox.Show("Thành công");
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
