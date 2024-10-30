namespace QLDAXayDung
{
    partial class ExportFile
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
            this.components = new System.ComponentModel.Container();
            this.test = new System.Windows.Forms.Label();
            this.nganSachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nganSachTableAdapter = new QLDAXayDung.TTCSNDataSetTableAdapters.NganSachTableAdapter();
            this.nhanSuTableAdapter = new QLDAXayDung.TTCSNDataSetTableAdapters.NhanSuTableAdapter();
            this.duAnTableAdapter = new QLDAXayDung.TTCSNDataSetTableAdapters.DuAnTableAdapter();
            this.nhanSuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.duAnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tTCSNDataSet = new QLDAXayDung.TTCSNDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.nganSachBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanSuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duAnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTCSNDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.AutoSize = true;
            this.test.Location = new System.Drawing.Point(655, 88);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(36, 20);
            this.test.TabIndex = 1;
            this.test.Text = "test";
            // 
            // nganSachBindingSource
            // 
            this.nganSachBindingSource.DataMember = "NganSach";
            // 
            // nganSachTableAdapter
            // 
            this.nganSachTableAdapter.ClearBeforeFill = true;
            // 
            // nhanSuTableAdapter
            // 
            this.nhanSuTableAdapter.ClearBeforeFill = true;
            // 
            // duAnTableAdapter
            // 
            this.duAnTableAdapter.ClearBeforeFill = true;
            // 
            // nhanSuBindingSource
            // 
            this.nhanSuBindingSource.DataMember = "NhanSu";
            // 
            // duAnBindingSource
            // 
            this.duAnBindingSource.DataMember = "DuAn";
            // 
            // tTCSNDataSet
            // 
            this.tTCSNDataSet.DataSetName = "TTCSNDataSet";
            this.tTCSNDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLDAXayDung.Report_DuAn.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, -1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1301, 806);
            this.reportViewer1.TabIndex = 2;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load_1);
            // 
            // ExportFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 817);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.test);
            this.Name = "ExportFile";
            this.Text = "ExportFile";
            this.Load += new System.EventHandler(this.ExportFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nganSachBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanSuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duAnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTCSNDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label test;
        private System.Windows.Forms.BindingSource nganSachBindingSource;
        private TTCSNDataSetTableAdapters.NganSachTableAdapter nganSachTableAdapter;
        private TTCSNDataSetTableAdapters.NhanSuTableAdapter nhanSuTableAdapter;
        private TTCSNDataSetTableAdapters.DuAnTableAdapter duAnTableAdapter;
        private System.Windows.Forms.BindingSource nhanSuBindingSource;
        private System.Windows.Forms.BindingSource duAnBindingSource;
        private TTCSNDataSet tTCSNDataSet;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}