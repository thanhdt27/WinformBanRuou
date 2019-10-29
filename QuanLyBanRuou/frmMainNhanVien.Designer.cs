namespace QuanLyBanRuou
{
    partial class frmMainNhanVien
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tmiTrangChu = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLapHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiXemHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiTrangChu,
            this.tmiLapHoaDon,
            this.tmiXemHoaDon,
            this.tmiDangXuat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 40);
            this.menuStrip1.TabIndex = 0;
            // 
            // tmiTrangChu
            // 
            this.tmiTrangChu.ForeColor = System.Drawing.Color.OrangeRed;
            this.tmiTrangChu.Name = "tmiTrangChu";
            this.tmiTrangChu.Size = new System.Drawing.Size(136, 36);
            this.tmiTrangChu.Text = "Trang Chủ";
            this.tmiTrangChu.Click += new System.EventHandler(this.tmiTrangChu_Click);
            // 
            // tmiLapHoaDon
            // 
            this.tmiLapHoaDon.ForeColor = System.Drawing.Color.OrangeRed;
            this.tmiLapHoaDon.Name = "tmiLapHoaDon";
            this.tmiLapHoaDon.Size = new System.Drawing.Size(166, 36);
            this.tmiLapHoaDon.Text = "Lập Hóa Đơn";
            this.tmiLapHoaDon.Click += new System.EventHandler(this.tmiLapHoaDon_Click);
            // 
            // tmiXemHoaDon
            // 
            this.tmiXemHoaDon.ForeColor = System.Drawing.Color.OrangeRed;
            this.tmiXemHoaDon.Name = "tmiXemHoaDon";
            this.tmiXemHoaDon.Size = new System.Drawing.Size(177, 36);
            this.tmiXemHoaDon.Text = "Xem Hóa Đơn";
            this.tmiXemHoaDon.Click += new System.EventHandler(this.tmiXemHoaDon_Click);
            // 
            // tmiDangXuat
            // 
            this.tmiDangXuat.ForeColor = System.Drawing.Color.OrangeRed;
            this.tmiDangXuat.Name = "tmiDangXuat";
            this.tmiDangXuat.Size = new System.Drawing.Size(139, 36);
            this.tmiDangXuat.Text = "Đăng Xuất";
            this.tmiDangXuat.Click += new System.EventHandler(this.tmiDangXuat_Click);
            // 
            // frmMainNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 651);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMainNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMainAdmin";
            this.Load += new System.EventHandler(this.frmMainAdmin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tmiTrangChu;
        private System.Windows.Forms.ToolStripMenuItem tmiLapHoaDon;
        private System.Windows.Forms.ToolStripMenuItem tmiXemHoaDon;
        private System.Windows.Forms.ToolStripMenuItem tmiDangXuat;

    }
}