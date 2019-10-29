using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using DTO;
using BUL;

namespace QuanLyBanRuou
{
    public partial class frmInHoaDon : Form
    {
        public frmInHoaDon()
        {
            InitializeComponent();
        }
        ChiTietHoaDonBUL cthdBUL = new ChiTietHoaDonBUL();
        HoaDonBUL hdBUL = new HoaDonBUL();
        private void setParameterTenKhach(string tenkh)
        {
            ReportParameter rp = new ReportParameter("TenKhachHang");

            rp.Values.Add(tenkh);
            reportViewer1.LocalReport.SetParameters(rp);
        }

        private void setParameterThanhTien(int thanhtien)
        {
            ReportParameter rp = new ReportParameter("ThanhTien");

            rp.Values.Add(thanhtien.ToString());
            reportViewer1.LocalReport.SetParameters(rp);
        }
        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            int mahd = hdBUL.TimMaHoaDonCuoiCung();
            HoaDon hd = new HoaDon();
            hd = hdBUL.LayHoaDonCuoiCung(mahd);
            setParameterTenKhach(hd.TenKhachHang);
            reportViewer1.RefreshReport();
            setParameterThanhTien(hd.ThanhTien);
            reportViewer1.RefreshReport();

            ds = cthdBUL.LayDataSet(mahd);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.ReportHoaDonSanPham.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables[0];

            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.PrintDialog();
            }
            catch
            {
                MessageBox.Show("Cú pháp k hợp lệ. Xin kiểm tra lại !", "Error");
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
