using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Collections;

namespace QLDAXayDung
{
    public partial class ExportFile : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;
        private int maDA;
        public ExportFile()
        {
            InitializeComponent();
            this.maDA = 1;
        }
        public ExportFile(int maDA)
        {
            this.maDA = maDA;
            InitializeComponent();
        }

        private void ExportFile_Load(object sender, EventArgs e)
        {
            this.test.Text = Convert.ToString(this.maDA);
            // TODO: This line of code loads data into the 'tTCSNDataSet.NganSach' table. You can move, or remove it, as needed.
            this.nganSachTableAdapter.Fill(this.tTCSNDataSet.NganSach);
            // TODO: This line of code loads data into the 'tTCSNDataSet.NhanSu' table. You can move, or remove it, as needed.
            this.nhanSuTableAdapter.Fill(this.tTCSNDataSet.NhanSu);
            // TODO: This line of code loads data into the 'tTCSNDataSet.DuAn' table. You can move, or remove it, as needed.
            this.duAnTableAdapter.Fill(this.tTCSNDataSet.DuAn);
            string connectionString = Program.connectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
            string queryNhanSu = "SELECT NS.* FROM NhanSu NS JOIN NhanSu_DuAN NSDA ON NS.MaNhanSu = NSDA.MaNhanSu WHERE NSDA.MaDA = " + this.maDA;
            string queryNganSach = " select * from NganSach where MaDA = " + this.maDA;
            string queryDuAn = "SELECT * FROM DuAn WHERE MaDA = " + this.maDA;
            SqlDataAdapter adapterNS = new SqlDataAdapter(queryNhanSu, connection);
            DataSet ds1 = new DataSet();
            adapterNS.Fill(ds1, "NhanSu");

            SqlDataAdapter adapterNSach = new SqlDataAdapter(queryNganSach, connection);
            DataSet ds2 = new DataSet();
            adapterNSach.Fill(ds2, "NganSach");

            SqlDataAdapter adapterDA = new SqlDataAdapter(queryDuAn, connection);
            DataSet ds3 = new DataSet();
            adapterDA.Fill(ds3, "DuAn");

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLDAXayDung.Report_DuAn.rdlc";

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "NhanSu";
            reportDataSource.Value = ds1.Tables["NhanSu"];
            ReportDataSource reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "NganSach";
            reportDataSource1.Value = ds2.Tables["NganSach"];
            ReportDataSource reportDataSource2 = new ReportDataSource();
            reportDataSource2.Name = "DuAn";
            reportDataSource2.Value = ds3.Tables["DuAn"];








            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);



            this.reportViewer1.RefreshReport();
            connection.Close();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void word_Click(object sender, EventArgs e)
        {
            
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
