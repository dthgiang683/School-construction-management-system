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
    public partial class fAddTaiTro : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;
        public fAddTaiTro()
        {
            InitializeComponent();
        }

        private void Them_chiphi_Click(object sender, EventArgs e)
        {
                if (string.IsNullOrWhiteSpace(this.nhaTaiTro.Text) || string.IsNullOrWhiteSpace(this.NoiDung.Text) || string.IsNullOrWhiteSpace(this.soTienTT.Text)||fAddChiPhi.check_chua_so(this.soTienTT.Text) == false)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    connection = new SqlConnection(Program.connectionString);
                    connection.Open();
                    string query = "insert into TaiTro (NgayChungTu,NoiDung,NhaTaiTro,SoTienTT,MaDA)values(@NgayChungTu,@NoiDung,@NhaTaiTro,@SoTienTT,@MaDA);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NgayChungTu", this.ngaychungtu.Value);
                        command.Parameters.AddWithValue("@NoiDung", this.NoiDung.Text);
                        command.Parameters.AddWithValue("@NhaTaiTro", this.nhaTaiTro.Text);
                        command.Parameters.AddWithValue("@SoTienTT", Convert.ToDecimal(this.soTienTT.Text));
                        command.Parameters.AddWithValue("@MaDA", Convert.ToInt32(this.maDA.Text));
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm tài trợ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                        this.Close();
                    }
                }
            
        }

        private void fAddTaiTro_Load(object sender, EventArgs e)
        {
            string query = "select MaDA from DuAn";
            string connectionString = Program.connectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader(); 
                while(reader.Read())
                {
                    string maDA = reader["MaDA"].ToString();
                    this.maDA.Items.Add(maDA);
                }
            }
            connection.Close();
        }
    }
}
