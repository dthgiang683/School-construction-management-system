namespace QLDAXayDung
{
    partial class fDoi_mk_khi_lay_mk
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.doimk = new System.Windows.Forms.Button();
            this.hideOr = new System.Windows.Forms.CheckBox();
            this.nhapLaimk = new System.Windows.Forms.TextBox();
            this.nhapMK = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(65, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập mật khẩu mới : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(65, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhập lại mật khẩu: ";
            // 
            // doimk
            // 
            this.doimk.ForeColor = System.Drawing.SystemColors.Highlight;
            this.doimk.Location = new System.Drawing.Point(316, 333);
            this.doimk.Name = "doimk";
            this.doimk.Size = new System.Drawing.Size(145, 47);
            this.doimk.TabIndex = 2;
            this.doimk.Text = "Đổi Mật Khẩu";
            this.doimk.UseVisualStyleBackColor = true;
            this.doimk.Click += new System.EventHandler(this.doimk_Click);
            // 
            // hideOr
            // 
            this.hideOr.AutoSize = true;
            this.hideOr.Location = new System.Drawing.Point(130, 281);
            this.hideOr.Name = "hideOr";
            this.hideOr.Size = new System.Drawing.Size(159, 24);
            this.hideOr.TabIndex = 3;
            this.hideOr.Text = "Hiển thị mật khẩu";
            this.hideOr.UseVisualStyleBackColor = true;
            this.hideOr.CheckedChanged += new System.EventHandler(this.hideOr_CheckedChanged);
            // 
            // nhapLaimk
            // 
            this.nhapLaimk.Location = new System.Drawing.Point(234, 204);
            this.nhapLaimk.Name = "nhapLaimk";
            this.nhapLaimk.Size = new System.Drawing.Size(348, 26);
            this.nhapLaimk.TabIndex = 4;
            this.nhapLaimk.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // nhapMK
            // 
            this.nhapMK.Location = new System.Drawing.Point(237, 108);
            this.nhapMK.Name = "nhapMK";
            this.nhapMK.Size = new System.Drawing.Size(348, 26);
            this.nhapMK.TabIndex = 4;
            this.nhapMK.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // fDoi_mk_khi_lay_mk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nhapMK);
            this.Controls.Add(this.nhapLaimk);
            this.Controls.Add(this.hideOr);
            this.Controls.Add(this.doimk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fDoi_mk_khi_lay_mk";
            this.Text = "fDoi_mk_khi_lay_mk";
            this.Load += new System.EventHandler(this.fDoi_mk_khi_lay_mk_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button doimk;
        private System.Windows.Forms.CheckBox hideOr;
        private System.Windows.Forms.TextBox nhapLaimk;
        private System.Windows.Forms.TextBox nhapMK;
    }
}