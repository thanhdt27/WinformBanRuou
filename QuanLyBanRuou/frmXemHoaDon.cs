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
    public partial class frmXemHoaDon : Form
    {
        HoaDonBUL hdBUL = new HoaDonBUL();
        ChiTietHoaDonBUL cthdBUL = new ChiTietHoaDonBUL();
        public frmXemHoaDon()
        {
            InitializeComponent();
        }

        private void frmXemHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = hdBUL.LayHoaDon();
        }

        private void btnTimTheoMa_Click(object sender, EventArgs e)
        {
            string tungay = dtpTuNgay.Value.Year.ToString() + "-"
                + dtpTuNgay.Value.Month.ToString() + "-" + dtpTuNgay.Value.Day.ToString();
            string denngay = dtpDenNgay.Value.Year.ToString() + "-"
                + dtpDenNgay.Value.Month.ToString() + "-" + dtpDenNgay.Value.Day.ToString();

            dgvHoaDon.DataSource=hdBUL.TimHoaDon(tungay,denngay);
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvHoaDon.CurrentCell.RowIndex;
            if (index > -1)
            {
                int mahd = Int32.Parse(dgvHoaDon.Rows[index].Cells[0].Value.ToString());
                dgvChiTietHoaDon.DataSource = cthdBUL.TimTheoMaHoaDon(mahd);
            }
        }
    }
}
