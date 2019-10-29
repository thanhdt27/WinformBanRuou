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
using BUL;
using DTO;
using Microsoft.Reporting.WinForms;

namespace QuanLyBanRuou
{
    public partial class frmBaoCaoDoanhThu : Form
    {
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }
        ChiTietHoaDonBUL cthdBUL = new ChiTietHoaDonBUL();
        private void frmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void setParameterTuNgay(string tungay)
        {
            ReportParameter rp = new ReportParameter("TuNgay");

            rp.Values.Add(tungay);
            reportViewer1.LocalReport.SetParameters(rp);
        }
        private void setParameterDenNgay(string denngay)
        {
            ReportParameter rp = new ReportParameter("DenNgay");

            rp.Values.Add(denngay);
            reportViewer1.LocalReport.SetParameters(rp);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string tungay = dtpTuNgay.Value.Year.ToString() + "-"
                + dtpTuNgay.Value.Month.ToString() + "-" + dtpTuNgay.Value.Day.ToString();
            string denngay = dtpDenNgay.Value.Year.ToString() + "-"
                + dtpDenNgay.Value.Month.ToString() + "-" + dtpDenNgay.Value.Day.ToString();
            ds = cthdBUL.BaoCaoDoanhThu(tungay, denngay);

            setParameterTuNgay(tungay);
            reportViewer1.RefreshReport();

            setParameterDenNgay(denngay);
            reportViewer1.RefreshReport();

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.ReportBaoCaoDoanhThu.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet2";
            rds.Value = ds.Tables[0];

            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
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
    }
}
