namespace QLDAXayDung
{
    partial class fQuenMK
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Mail = new System.Windows.Forms.TextBox();
            this.otp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Resend_otp = new System.Windows.Forms.Button();
            this.get_pass = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.xacThuc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tenDangNhap = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-22, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 81);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(396, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUÊN MẬT KHẨU";
            // 
            // Mail
            // 
            this.Mail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mail.Location = new System.Drawing.Point(147, 238);
            this.Mail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Mail.Multiline = true;
            this.Mail.Name = "Mail";
            this.Mail.Size = new System.Drawing.Size(637, 73);
            this.Mail.TabIndex = 2;
            // 
            // otp
            // 
            this.otp.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otp.Location = new System.Drawing.Point(147, 389);
            this.otp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.otp.Multiline = true;
            this.otp.Name = "otp";
            this.otp.Size = new System.Drawing.Size(396, 62);
            this.otp.TabIndex = 3;
            this.otp.TextChanged += new System.EventHandler(this.otp_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(143, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhập mã xác nhận:";
            // 
            // Resend_otp
            // 
            this.Resend_otp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Resend_otp.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resend_otp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Resend_otp.Location = new System.Drawing.Point(587, 389);
            this.Resend_otp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Resend_otp.Name = "Resend_otp";
            this.Resend_otp.Size = new System.Drawing.Size(168, 62);
            this.Resend_otp.TabIndex = 5;
            this.Resend_otp.Text = "Gửi lại mã xác nhận";
            this.Resend_otp.UseVisualStyleBackColor = false;
            this.Resend_otp.Click += new System.EventHandler(this.Resend_otp_Click);
            // 
            // get_pass
            // 
            this.get_pass.BackColor = System.Drawing.Color.LightSkyBlue;
            this.get_pass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.get_pass.Location = new System.Drawing.Point(327, 509);
            this.get_pass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.get_pass.Name = "get_pass";
            this.get_pass.Size = new System.Drawing.Size(338, 46);
            this.get_pass.TabIndex = 6;
            this.get_pass.Text = "Lấy lại mật khẩu";
            this.get_pass.UseVisualStyleBackColor = false;
            this.get_pass.Click += new System.EventHandler(this.get_pass_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel1.Location = new System.Drawing.Point(429, 569);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(169, 23);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quay lại đăng nhập";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // xacThuc
            // 
            this.xacThuc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.xacThuc.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xacThuc.ForeColor = System.Drawing.Color.DodgerBlue;
            this.xacThuc.Location = new System.Drawing.Point(816, 250);
            this.xacThuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xacThuc.Name = "xacThuc";
            this.xacThuc.Size = new System.Drawing.Size(123, 44);
            this.xacThuc.TabIndex = 8;
            this.xacThuc.Text = "Xác thực";
            this.xacThuc.UseVisualStyleBackColor = false;
            this.xacThuc.Click += new System.EventHandler(this.xacThuc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(143, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên Đăng Nhập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label6.Location = new System.Drawing.Point(143, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(476, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Nhập mail của bạn để nhận mã xác nhận lấy lại mật khẩu\r\n";
            // 
            // tenDangNhap
            // 
            this.tenDangNhap.Location = new System.Drawing.Point(299, 116);
            this.tenDangNhap.Name = "tenDangNhap";
            this.tenDangNhap.Size = new System.Drawing.Size(265, 38);
            this.tenDangNhap.TabIndex = 9;
            this.tenDangNhap.Text = "";
            // 
            // fQuenMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 601);
            this.Controls.Add(this.tenDangNhap);
            this.Controls.Add(this.xacThuc);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.get_pass);
            this.Controls.Add(this.Resend_otp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.otp);
            this.Controls.Add(this.Mail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fQuenMK";
            this.Text = "fQuenMK";
            this.Load += new System.EventHandler(this.fQuenMK_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Mail;
        private System.Windows.Forms.TextBox otp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Resend_otp;
        private System.Windows.Forms.Button get_pass;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button xacThuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox tenDangNhap;
    }
}