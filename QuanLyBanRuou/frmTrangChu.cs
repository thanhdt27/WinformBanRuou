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
    public partial class frmTrangChu : Form
    {
        SanPhamBUL spb = new SanPhamBUL();
        SanPhamHoaDonBUL sphdBUL = new SanPhamHoaDonBUL();
        DanhMucBUL dmBUL = new DanhMucBUL();
        //frmLapHoaDon flhd = new frmLapHoaDon();

        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int soHangTrongGio = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            string masanpham = spDuocChon.MaSanPham;
            if (masanpham == null)
            {
                MessageBox.Show("Xin mời lựa chọn sản phẩm");
                return;
            }
            
            int sl;
            try
            {
                sl = Int32.Parse(txtSoLuongMua.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                txtSoLuongMua.Text = "";
                return;
            }
            if (sl > spDuocChon.SoLuong)
            {
                MessageBox.Show("Số lượng trong kho không đủ");
                txtSoLuongMua.Text = "";
                return;
            }
            if (spb.CapNhatSoLuong(masanpham, sl))
            {
                soHangTrongGio++;
                lblGioHang.Text = Convert.ToString(soHangTrongGio);
                lblSLCon.Text = (spDuocChon.SoLuong - sl).ToString();

                SanPhamHoaDon sphd = new SanPhamHoaDon();

                sphd.TenSanPham = spDuocChon.TenSanPham;
                sphd.DungTich = spDuocChon.DungTich;
                sphd.NongDo = spDuocChon.NongDo;
                sphd.SoLuongMua = Int32.Parse(txtSoLuongMua.Text);
                sphd.DonGia = spDuocChon.DonGia;

                sphdBUL.ThemGioHang(sphd);
        
            }
            //dgvListSanPham.DataSource = spb.LaySanPham();
            txtSoLuongMua.Text = "";
        }
        int trangHienTai = 1;
        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            
        }

        SanPham spDuocChon = new SanPham();
        private void btn_click(object sender, EventArgs e)
        {
            spDuocChon = ((sender as Button).Tag as SanPham);
            SanPham sp = spb.TimSanPhamTheoMa(spDuocChon.MaSanPham);
            lblTenSP.Text = sp.TenSanPham;
            lblDungTich.Text = sp.DungTich.ToString();
            lblNongDo.Text = sp.NongDo.ToString();
            lblSLCon.Text = sp.SoLuong.ToString();
            lblDonGia.Text = sp.DonGia.ToString();
            if (sp.SoLuong <= 0)
            {
                txtSoLuongMua.Enabled = false;
                btnThemVaoGio.Enabled = false;
            }
            else
            {
                txtSoLuongMua.Enabled = true;
                btnThemVaoGio.Enabled = true;
            }
        }
        


        private void frmTrangChu_Load_1(object sender, EventArgs e)
        {
            //dgvListSanPham.DataSource = spb.LaySanPham();
            foreach (DanhMucSanPham ele in dmBUL.LayDanhMuc())
            {
                cmbDanhMuc.Items.Add(ele.TenDanhMuc);
            }
            if (sphdBUL.LayGioHang() != null)
            {
                sphdBUL.XoaBangSanPhamHoaDon();
            }
            List<SanPham> list = spb.LaySanPham();           
            flpDanhSachSanPham.Controls.Clear();
            for (int i = 0; i < 6 * trangHienTai; i++)
            {
                if (i < list.Count)
                {
                    Button btn = new Button();
                    btn.Text = list[i].TenSanPham.ToString() + "\n" + list[i].DonGia;
                    btn.Width = 120;
                    btn.Height = 110;
                    if (list[i].SoLuong > 0)
                        btn.BackColor = Color.Aqua;
                    else
                        btn.BackColor = Color.LightGray;
                    btn.Tag = list[i];
                    btn.Click += btn_click;
                    flpDanhSachSanPham.Controls.Add(btn);
                }
            }
        }

        private void dgvListSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int index = dgvListSanPham.CurrentCell.RowIndex;
            //SanPham sp = new SanPham();
            //sp.MaSanPham = dgvListSanPham.Rows[index].Cells[0].Value.ToString();
            //sp.TenSanPham = dgvListSanPham.Rows[index].Cells[1].Value.ToString();
            //sp.DungTich = Int32.Parse(dgvListSanPham.Rows[index].Cells[2].Value.ToString());
            //sp.NongDo = Int32.Parse(dgvListSanPham.Rows[index].Cells[3].Value.ToString());
            //sp.SoLuong = Int32.Parse(dgvListSanPham.Rows[index].Cells[4].Value.ToString());
            //sp.DonGia = Int32.Parse(dgvListSanPham.Rows[index].Cells[5].Value.ToString());
            //sp.MaDanhMuc = dgvListSanPham.Rows[index].Cells[6].Value.ToString();
            //sp.MaNCC = dgvListSanPham.Rows[index].Cells[7].Value.ToString();
            txtSoLuongMua.Focus();
            MessageBox.Show("Xin mời nhập số lượng sản phẩm");

        }
        

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            lblHienThiTimKiem.Text = "";
            DanhMucDuocChonTimKiem = false;
            TimKiemTenSanPham = false;
            cmbDanhMuc.SelectedIndex = -1;
            txtTimKiemTenSanPham.Text = "";
            List<SanPham> list = spb.LaySanPham();
            flpDanhSachSanPham.Controls.Clear();
            for (int i = 0; i < 6 * trangHienTai; i++)
            {
                if (i < list.Count)
                {
                    Button btn = new Button();
                    btn.Text = list[i].TenSanPham.ToString() + "\n" + list[i].DonGia;
                    btn.Width = 120;
                    btn.Height = 110;
                    if (list[i].SoLuong > 0)
                        btn.BackColor = Color.Aqua;
                    else
                        btn.BackColor = Color.LightGray;
                    btn.Tag = list[i];
                    btn.Click += btn_click;
                    flpDanhSachSanPham.Controls.Add(btn);
                }
            }
        }

        Boolean DanhMucDuocChonTimKiem = false;
        private void cmbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDanhMuc.SelectedIndex == -1)
                return;
            if (TimKiemTenSanPham == true)
                TimKiemTenSanPham = false;
            string danhmuc = cmbDanhMuc.SelectedItem.ToString();
            //dgvListSanPham.DataSource = spb.TimTheoDanhMuc(danhmuc);
            lblHienThiTimKiem.Text = cmbDanhMuc.SelectedItem.ToString();

            List<SanPham> list = spb.TimTheoDanhMuc(danhmuc);
            double d = list.Count / 6.0;
            int soTrang = (int)Math.Ceiling(d);
            flpDanhSachSanPham.Controls.Clear();

            for (int i = 0; i < 6 * trangHienTai; i++)
            {
                if (i < list.Count)
                {
                    Button btn = new Button();
                    btn.Text = list[i].TenSanPham.ToString() + "\n" + list[i].DonGia;
                    btn.Width = 120;
                    btn.Height = 110;
                    if (list[i].SoLuong > 0)
                        btn.BackColor = Color.Aqua;
                    else
                        btn.BackColor = Color.LightGray;
                    btn.Tag = list[i];
                    btn.Click += btn_click;
                    flpDanhSachSanPham.Controls.Add(btn);
                }
            }

            DanhMucDuocChonTimKiem = true;
            
        }

        Boolean TimKiemTenSanPham = false;
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (DanhMucDuocChonTimKiem == true)
                DanhMucDuocChonTimKiem = false;
            string tenSP = txtTimKiemTenSanPham.Text;
            //dgvListSanPham.DataSource = spb.TimTheoTenSanPham(tenSP);

            List<SanPham> list = spb.TimTheoTenSanPham(tenSP);
            double d = list.Count / 6.0;
            int soTrang = (int)Math.Ceiling(d);
            flpDanhSachSanPham.Controls.Clear();

            for (int i = 0; i < 6 * trangHienTai; i++)
            {
                if (i < list.Count)
                {
                    Button btn = new Button();
                    btn.Text = list[i].TenSanPham.ToString() + "\n" + list[i].DonGia;
                    btn.Width = 120;
                    btn.Height = 110;
                    if (list[i].SoLuong > 0)
                        btn.BackColor = Color.Aqua;
                    else
                        btn.BackColor = Color.LightGray;
                    btn.Tag = list[i];
                    btn.Click += btn_click;
                    flpDanhSachSanPham.Controls.Add(btn);
                }
            }
            
            lblHienThiTimKiem.Text = txtTimKiemTenSanPham.Text;
            TimKiemTenSanPham = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            List<SanPhamHoaDon> list = new List<SanPhamHoaDon>();
            list= sphdBUL.LayGioHang();
            if(list.Count>0)
            foreach (SanPhamHoaDon ele in list)
            {
                string maSP = spb.TimMaSanPhamTheoTen(ele.TenSanPham);
                spb.CapNhatSoLuong(maSP, -ele.SoLuongMua);
            }
            sphdBUL.XoaBangSanPhamHoaDon();
            lblGioHang.Text = "0";
            soHangTrongGio = 0;
            lblTenSP.Text = "";
            lblDungTich.Text = "";
            lblNongDo.Text = "";
            lblSLCon.Text = "";
            lblDonGia.Text = "";

            txtSoLuongMua.Text = "";
        }

        private void btTruoc_Click(object sender, EventArgs e)
        {
            flpDanhSachSanPham.Controls.Clear();
            if (trangHienTai > 1)
                trangHienTai--;
            List<SanPham> list = new List<SanPham>();
            if (DanhMucDuocChonTimKiem == true)
            {
                list = spb.TimTheoDanhMuc(cmbDanhMuc.SelectedItem.ToString());
            }
            else if (TimKiemTenSanPham == true)
            {
                list = spb.TimTheoTenSanPham(txtTimKiemTenSanPham.Text);
            }
            else
            {
                list = spb.LaySanPham();
            }
            
            for (int i = 6 * (trangHienTai - 1); i < 6 * trangHienTai; i++)
            {
                if (i < list.Count)
                {
                    Button btn = new Button();
                    btn.Text = list[i].TenSanPham.ToString() + "\n" + list[i].DonGia;
                    btn.Width = 120;
                    btn.Height = 110;
                    if (list[i].SoLuong > 0)
                        btn.BackColor = Color.Aqua;
                    else
                        btn.BackColor = Color.LightGray;
                    btn.Tag = list[i];
                    btn.Click += btn_click;
                    flpDanhSachSanPham.Controls.Add(btn);
                }
            }
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            flpDanhSachSanPham.Controls.Clear();

            List<SanPham> list = new List<SanPham>();
            if (DanhMucDuocChonTimKiem == true)
            {
                list = spb.TimTheoDanhMuc(cmbDanhMuc.SelectedItem.ToString());
            }
            else if (TimKiemTenSanPham == true)
            {
                list = spb.TimTheoTenSanPham(txtTimKiemTenSanPham.Text);
            }
            else
            {
                list = spb.LaySanPham();
            }
            double d = list.Count / 6.0;
            int soTrang = (int)Math.Ceiling(d);
            if (trangHienTai < soTrang)
                trangHienTai++;
      
            for (int i = 6 * (trangHienTai - 1); i < 6 * trangHienTai; i++)
            {
                if (i < list.Count)
                {
                    Button btn = new Button();
                    btn.Text = list[i].TenSanPham.ToString() + "\n" + list[i].DonGia;
                    btn.Width = 120;
                    btn.Height = 110;
                    if (list[i].SoLuong > 0)
                        btn.BackColor = Color.Aqua;
                    else
                        btn.BackColor = Color.LightGray;
                    btn.Tag = list[i];
                    btn.Click += btn_click;
                    flpDanhSachSanPham.Controls.Add(btn);
                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmLapHoaDon fLHD = new frmLapHoaDon();
            fLHD.TopLevel = false;
            fLHD.MdiParent = this.MdiParent;
            fLHD.Show();
            
            //this.Show();
        }

        private void btnXemGioHang_Click(object sender, EventArgs e)
        {
            frmGioHang f = new frmGioHang();
            f.Show();
        }

        private void txtSoLuongMua_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
