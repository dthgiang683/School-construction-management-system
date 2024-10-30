using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDAXayDung
{
    public partial class fQuanLiNganSach : Form
    {

        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;

        public fQuanLiNganSach()
        {
            InitializeComponent();
        }
        
        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void table_ngansach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fQuanLiNganSach_Load(object sender, EventArgs e)
        {
            string connectionString = Program.connectionString;
            table_ngansach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            connection = new SqlConnection(connectionString);
            connection.Open();
            LoadData();
          
            connection.Close();

        }
        private void LoadData()
        {
            // Tạo câu lệnh SQL
            string query = "SELECT MaNganSach ,TongTaiTro,NSHienCo,TongChi FROM NganSach";

            // Tạo SqlDataAdapter và DataTable
            adapter = new SqlDataAdapter(query, connection);
            table = new DataTable();
            // Đổ dữ liệu vào DataTable
            adapter.Fill(table);
            // Hiển thị dữ liệu trong DataGridView
            table_ngansach.DataSource = table;
            // Đóng kết nối sau khi sử dụng
           
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void table_ngansach_SelectionChanged(object sender, EventArgs e)
        {
            if(table_ngansach.SelectedRows.Count > 0)
            {
                int index1 = Convert.ToInt32(table_ngansach.SelectedRows[0].Cells["MaNganSach"].Value);
                string query = "select DuAn.MaDA, DuAn.TenDA from NganSach inner join DuAn on DuAn.MaDA = NganSach.MaDA where MaNganSach = " + index1;
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection); 
                SqlDataReader reader = command.ExecuteReader();
                string MaDA = "";
                string TenDA = "";
                if(reader.Read())
                {
                    MaDA = reader["MaDA"].ToString();
                    TenDA = reader["TenDA"].ToString() ;
                    
                }
                textBox1.Text = MaDA;
                this.TenDA_nganSach.Text = TenDA;
                connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fChiPhi fChiPhi = new fChiPhi();
            fChiPhi.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fNguonTaiTro fNguonTaiTro = new fNguonTaiTro();
            fNguonTaiTro.ShowDialog();
        }
    }
}
