namespace QLDAXayDung
{
    partial class fAddTaiTro
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
            this.nhaTaiTro = new System.Windows.Forms.TextBox();
            this.ngaychungtu = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Them_chiphi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.NoiDung = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.soTienTT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maDA = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nhaTaiTro
            // 
            this.nhaTaiTro.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhaTaiTro.Location = new System.Drawing.Point(252, 377);
            this.nhaTaiTro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nhaTaiTro.Multiline = true;
            this.nhaTaiTro.Name = "nhaTaiTro";
            this.nhaTaiTro.Size = new System.Drawing.Size(979, 68);
            this.nhaTaiTro.TabIndex = 89;
            // 
            // ngaychungtu
            // 
            this.ngaychungtu.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaychungtu.Location = new System.Drawing.Point(252, 283);
            this.ngaychungtu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ngaychungtu.Name = "ngaychungtu";
            this.ngaychungtu.Size = new System.Drawing.Size(456, 41);
            this.ngaychungtu.TabIndex = 86;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(502, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÊM NGUỒN TÀI TRỢ";
            // 
            // Them_chiphi
            // 
            this.Them_chiphi.BackColor = System.Drawing.Color.LightCoral;
            this.Them_chiphi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Them_chiphi.Location = new System.Drawing.Point(605, 807);
            this.Them_chiphi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Them_chiphi.Name = "Them_chiphi";
            this.Them_chiphi.Size = new System.Drawing.Size(128, 75);
            this.Them_chiphi.TabIndex = 82;
            this.Them_chiphi.Text = "Thêm";
            this.Them_chiphi.UseVisualStyleBackColor = false;
            this.Them_chiphi.Click += new System.EventHandler(this.Them_chiphi_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 395);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 33);
            this.label5.TabIndex = 79;
            this.label5.Text = "Nhà Tài trợ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 292);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 33);
            this.label4.TabIndex = 78;
            this.label4.Text = "Ngày chứng từ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(417, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 32);
            this.label2.TabIndex = 76;
            this.label2.Text = "Mã Tài trợ:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-57, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1444, 98);
            this.panel1.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 519);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 33);
            this.label3.TabIndex = 90;
            this.label3.Text = "Nội dung:";
            // 
            // NoiDung
            // 
            this.NoiDung.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoiDung.Location = new System.Drawing.Point(252, 495);
            this.NoiDung.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NoiDung.Multiline = true;
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Size = new System.Drawing.Size(979, 68);
            this.NoiDung.TabIndex = 91;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(63, 623);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 33);
            this.label6.TabIndex = 92;
            this.label6.Text = "Số tiền:";
            // 
            // soTienTT
            // 
            this.soTienTT.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soTienTT.Location = new System.Drawing.Point(252, 603);
            this.soTienTT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.soTienTT.Multiline = true;
            this.soTienTT.Name = "soTienTT";
            this.soTienTT.Size = new System.Drawing.Size(979, 68);
            this.soTienTT.TabIndex = 93;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(63, 715);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 33);
            this.label7.TabIndex = 92;
            this.label7.Text = "Mã Dự Án";
            // 
            // maDA
            // 
            this.maDA.FormattingEnabled = true;
            this.maDA.Location = new System.Drawing.Point(252, 718);
            this.maDA.Name = "maDA";
            this.maDA.Size = new System.Drawing.Size(147, 33);
            this.maDA.TabIndex = 94;
            // 
            // fAddTaiTro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1330, 925);
            this.Controls.Add(this.maDA);
            this.Controls.Add(this.soTienTT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NoiDung);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nhaTaiTro);
            this.Controls.Add(this.ngaychungtu);
            this.Controls.Add(this.Them_chiphi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fAddTaiTro";
            this.Text = "fAddTaiTro";
            this.Load += new System.EventHandler(this.fAddTaiTro_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nhaTaiTro;
        private System.Windows.Forms.DateTimePicker ngaychungtu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Them_chiphi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NoiDung;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox soTienTT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox maDA;
    }
}