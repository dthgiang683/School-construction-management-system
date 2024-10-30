using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDAXayDung
{
    public partial class fSuaTaiTro : Form
    {
        private int index;
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;

        public fSuaTaiTro(int index)
        {
            this.index = index;
            InitializeComponent();
        }

        private void sua_taitro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.nhataitro.Text) || string.IsNullOrEmpty(this.noidung.Text) || string.IsNullOrEmpty(this.sotien.Text) || fAddChiPhi.check_chua_so(this.sotien.Text) == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                connection.Open();
                string query = "update TaiTro set NoiDung =@NoiDung, SoTienTT = @SoTienTT,NhaTaiTro = @NhaTaiTro, NgayChungTu = @NgayChungTu where MaTaiTro = " + this.mataitro.Text;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NoiDung", this.noidung.Text);
                    command.Parameters.AddWithValue("@SoTienTT", Convert.ToDecimal(this.sotien.Text));
                    command.Parameters.AddWithValue("@NhaTaiTro", this.nhataitro.Text);
                    command.Parameters.AddWithValue("@NgayChungTu", Convert.ToDateTime(this.ngaychungtu.Value));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Sửa tài trợ thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    connection.Close();
                }
                this.Close();
            }
           
        }

        private void fSuaTaiTro_Load(object sender, EventArgs e)
        {
            string connectionString = Program.connectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "select MaTaiTro, NgayChungTu,NoiDung,NhaTaiTro,SoTienTT from TaiTro where MaTaiTro = "+this.index;
            using(SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.ngaychungtu.Value = Convert.ToDateTime( reader["NgayChungTu"].ToString());
                    this.mataitro.Text = reader["MaTaiTro"].ToString();
                    this.noidung.Text = reader["NoiDung"].ToString() ;
                    this.sotien.Text = reader["SoTienTT"].ToString();
                    this.nhataitro.Text = reader["NhaTaiTro"].ToString();
                }
            }
            connection.Close();
        }
    }
}
