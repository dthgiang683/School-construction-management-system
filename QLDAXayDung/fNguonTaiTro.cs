using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDAXayDung
{
    public partial class fNguonTaiTro : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;

        public fNguonTaiTro()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fNguonTaiTro_Load(object sender, EventArgs e)
        {
            Load_TaiTro();
        }
        private void Load_TaiTro()
        {
            string connectionString = Program.connectionString;
            string query = "select MaTaiTro, NgayChungTu,NoiDung,NhaTaiTro,SoTienTT from TaiTro";
            table_taitro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connection = new SqlConnection(connectionString);
            connection.Open();  
            using (adapter = new SqlDataAdapter(query, connection))
            {
                table = new DataTable();
                adapter.Fill(table);
                table_taitro.DataSource = table;
            }
            connection.Close(); 
        }

        private void table_ngansach_SelectionChanged(object sender, EventArgs e)
        {
            if(table_taitro.SelectedRows.Count > 0)
            {
                int index = Convert.ToInt32(table_taitro.SelectedRows[0].Cells["MaTaiTro"].Value);
                connection.Open();
                string query = "select DuAn.MaDA, DuAn.TenDA from TaiTro inner join DuAn on DuAn.MaDA = TaiTro.MaDA where MaTaiTro = " + index;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                   

                    while(reader.Read())
                    {
                        this.TenDA_taitro.Text = reader["MaDA"].ToString();
                        this.MaDA_taitro.Text = reader["TenDA"].ToString();
                       
                    }
                }
                connection.Close() ;
            }
           
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Load_TaiTro();
        }

        private void then_taitro_Click(object sender, EventArgs e)
        {
            fAddTaiTro fAddTaiTro = new fAddTaiTro();
            fAddTaiTro.ShowDialog();
            Load_TaiTro();
        }

        private void suataitro_Click(object sender, EventArgs e)
        {
            if (table_taitro.SelectedRows.Count > 0)
            {
                int index = Convert.ToInt32(table_taitro.SelectedRows[0].Cells["MaTaiTro"].Value);
                fSuaTaiTro suaTaiTro = new fSuaTaiTro(index);
                suaTaiTro.ShowDialog();
                Load_TaiTro();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 tài trợ muốn sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void xoataitro_Click(object sender, EventArgs e)
        {
            if(table_taitro.SelectedRows.Count>0) {
                int index = Convert.ToInt32( table_taitro.SelectedRows[0].Cells["MaTaiTro"].Value);
                connection.Open();
                string query = "delete TaiTro where MaTaiTro = "+index;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                connection.Close();
                Load_TaiTro() ;

            }
            else
            {
                MessageBox.Show("Vui lòng chọn mục tài trợ muốn xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fQuanLiNganSach fQuanLiNganSach = new fQuanLiNganSach();    
            fQuanLiNganSach.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fChiPhi fChiPhi = new fChiPhi();
            fChiPhi.ShowDialog();   
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
