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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLDAXayDung
{
    public partial class fChiPhi : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;
        public fChiPhi()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fChiPhi_Load(object sender, EventArgs e)
        {
            string connectionString = Program.connectionString;
            string query = "select [MaChiPhi],[NgayChungTu],[NoiDung],[NguoiSudung],[SoTienCP] from ChiPhi";
            table_chiphi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connection = new SqlConnection(connectionString);
            connection.Open();
            adapter = new SqlDataAdapter(query, connection);
            table = new DataTable();    
            adapter.Fill(table);
            table_chiphi.DataSource = table;
            connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tenDuAn_TextChanged(object sender, EventArgs e)
        {

        }

        private void table_chiphi_SelectionChanged(object sender, EventArgs e)
        {
            if (table_chiphi.SelectedRows.Count > 0)
            {
                int index1 = Convert.ToInt32(table_chiphi.SelectedRows[0].Cells["MaChiPhi"].Value);
                string query = "select DuAn.MaDA, DuAn.TenDA from ChiPhi inner join DuAn on DuAn.MaDA = ChiPhi.MaDA where MaChiPhi = " + index1;
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                string tenDuAn = "";
                string maDuAn = "";
            
                if (reader.Read())
                {
                    tenDuAn = reader["TenDA"].ToString();
                    maDuAn = reader["MaDA"].ToString();
                    
                }
                this.maDuAn.Text = maDuAn;
                this.tenDuAn.Text = tenDuAn;
                
                connection.Close();
            }
        }

        private void them_chiphi_Click(object sender, EventArgs e)
        {
            fAddChiPhi fAddChiPhi = new fAddChiPhi();
            fAddChiPhi.ShowDialog();
            Refresh_table();
        }

        private void sua_chiphi_Click(object sender, EventArgs e)
        {
            if (table_chiphi.SelectedRows.Count > 0)
            {
                int index = Convert.ToInt32(table_chiphi.SelectedRows[0].Cells["MaChiPhi"].Value);
                fSuaChiPhi fSuaChiPhi = new fSuaChiPhi(index);
                fSuaChiPhi.ShowDialog();
                Refresh_table();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn chi phí muốn sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Refresh_table();
        }
        private void Refresh_table()
        {
            string connectionString = Program.connectionString;
            string query = "select [MaChiPhi],[NgayChungTu],[NoiDung],[NguoiSudung],[SoTienCP] from ChiPhi";
            table_chiphi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connection = new SqlConnection(connectionString);
            connection.Open();
            adapter = new SqlDataAdapter(query, connection);
            table = new DataTable();
            adapter.Fill(table);
            table_chiphi.DataSource = table;
            connection.Close();
        }
        private void xoa_chiphi_Click(object sender, EventArgs e)
        {
            if (table_chiphi.SelectedRows.Count > 0)
            {
                int index =Convert.ToInt32( table_chiphi.SelectedRows[0].Cells["MaChiPhi"].Value);
                connection.Open();
                string query = "delete ChiPhi where MaChiPhi = " + index;
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh_table();
                }


            }
            else
            {
                MessageBox.Show("Bạn chưa chọn chi phí muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fQuanLiNganSach fQuanLiNganSach = new fQuanLiNganSach();
            fQuanLiNganSach.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fNguonTaiTro fNguonTaiTro = new fNguonTaiTro();
            fNguonTaiTro.ShowDialog();
        }
    }
}
