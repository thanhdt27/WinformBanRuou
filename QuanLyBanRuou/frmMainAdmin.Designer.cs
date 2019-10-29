namespace QuanLyBanRuou
{
    partial class frmMainAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuAdmin = new System.Windows.Forms.MenuStrip();
            this.mniHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnQuanLyDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mntQuanLySanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnQuanLyNhaCungCap = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnQuanLyNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnBaoCaoDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuAdmin
            // 
            this.menuAdmin.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuAdmin.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.menuAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniHeThong,
            this.mniTaiKhoan});
            this.menuAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(884, 40);
            this.menuAdmin.TabIndex = 4;
            this.menuAdmin.Text = "menuStrip1";
            this.menuAdmin.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuAdmin_ItemClicked);
            // 
            // mniHeThong
            // 
            this.mniHeThong.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mniHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmnQuanLyDanhMuc,
            this.mntQuanLySanPham,
            this.tmnQuanLyNhaCungCap,
            this.tmnQuanLyNhanVien,
            this.tmnBaoCaoDoanhThu});
            this.mniHeThong.ForeColor = System.Drawing.Color.OrangeRed;
            this.mniHeThong.Name = "mniHeThong";
            this.mniHeThong.Size = new System.Drawing.Size(133, 36);
            this.mniHeThong.Text = "Hệ Thống";
            // 
            // tmnQuanLyDanhMuc
            // 
            this.tmnQuanLyDanhMuc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tmnQuanLyDanhMuc.Name = "tmnQuanLyDanhMuc";
            this.tmnQuanLyDanhMuc.Size = new System.Drawing.Size(247, 26);
            this.tmnQuanLyDanhMuc.Text = "Quản Lý Danh Mục";
            this.tmnQuanLyDanhMuc.Click += new System.EventHandler(this.tmnQuanLyDanhMuc_Click);
            // 
            // mntQuanLySanPham
            // 
            this.mntQuanLySanPham.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mntQuanLySanPham.Name = "mntQuanLySanPham";
            this.mntQuanLySanPham.Size = new System.Drawing.Size(247, 26);
            this.mntQuanLySanPham.Text = "Quản Lý Sản Phẩm";
            this.mntQuanLySanPham.Click += new System.EventHandler(this.mntQuanLySanPham_Click);
            // 
            // tmnQuanLyNhaCungCap
            // 
            this.tmnQuanLyNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tmnQuanLyNhaCungCap.Name = "tmnQuanLyNhaCungCap";
            this.tmnQuanLyNhaCungCap.Size = new System.Drawing.Size(247, 26);
            this.tmnQuanLyNhaCungCap.Text = "Quản Lý Nhà Cung Cấp";
            this.tmnQuanLyNhaCungCap.Click += new System.EventHandler(this.tmnQuanLyNhaCungCap_Click);
            // 
            // tmnQuanLyNhanVien
            // 
            this.tmnQuanLyNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tmnQuanLyNhanVien.Name = "tmnQuanLyNhanVien";
            this.tmnQuanLyNhanVien.Size = new System.Drawing.Size(247, 26);
            this.tmnQuanLyNhanVien.Text = "Quản Lý Nhân Viên";
            this.tmnQuanLyNhanVien.Click += new System.EventHandler(this.tmnQuanLyNhanVien_Click);
            // 
            // tmnBaoCaoDoanhThu
            // 
            this.tmnBaoCaoDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tmnBaoCaoDoanhThu.Name = "tmnBaoCaoDoanhThu";
            this.tmnBaoCaoDoanhThu.Size = new System.Drawing.Size(247, 26);
            this.tmnBaoCaoDoanhThu.Text = "Báo Cáo Doan Thu";
            this.tmnBaoCaoDoanhThu.Click += new System.EventHandler(this.tmnBaoCaoDoanhThu_Click);
            // 
            // mniTaiKhoan
            // 
            this.mniTaiKhoan.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mniTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmnDangXuat});
            this.mniTaiKhoan.ForeColor = System.Drawing.Color.OrangeRed;
            this.mniTaiKhoan.Name = "mniTaiKhoan";
            this.mniTaiKhoan.Size = new System.Drawing.Size(130, 36);
            this.mniTaiKhoan.Text = "Tài Khoản";
            // 
            // tmnDangXuat
            // 
            this.tmnDangXuat.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tmnDangXuat.Name = "tmnDangXuat";
            this.tmnDangXuat.Size = new System.Drawing.Size(157, 26);
            this.tmnDangXuat.Text = "Đăng Xuất";
            this.tmnDangXuat.Click += new System.EventHandler(this.tmnDangXuat_Click);
            // 
            // frmMainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 651);
            this.Controls.Add(this.menuAdmin);
            this.IsMdiContainer = true;
            this.Name = "frmMainAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMainAdmin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainAdmin_FormClosed);
            this.Load += new System.EventHandler(this.frmMainAdmin_Load);
            this.menuAdmin.ResumeLayout(false);
            this.menuAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem mniHeThong;
        private System.Windows.Forms.ToolStripMenuItem tmnQuanLyDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mntQuanLySanPham;
        private System.Windows.Forms.ToolStripMenuItem tmnQuanLyNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mniTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem tmnDangXuat;
        private System.Windows.Forms.ToolStripMenuItem tmnQuanLyNhaCungCap;
        private System.Windows.Forms.ToolStripMenuItem tmnBaoCaoDoanhThu;
    }
}