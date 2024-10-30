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
using System.Linq;
namespace QLDAXayDung
{
    public partial class fAddChiPhi : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;
        public fAddChiPhi()
        {
            InitializeComponent();
        }
        public static bool check_chua_so(string input)
        {
            decimal d;
       
            if(decimal.TryParse(input, out d))
            {
                return true;
            }
            else
            { return false; }   
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(this.nguoisudung.Text) || string.IsNullOrEmpty(this.noidung.Text) || string.IsNullOrEmpty(this.sotien.Text) || this.listdsDA.SelectedItem ==null||check_chua_so(this.sotien.Text)==false)
            {
                MessageBox.Show("Vui lòng điền đầy đủ và nhập đúng định dạng thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                string nguoisudung = this.nguoisudung.Text;
                DateTime dateTime = this.ngay_chiphi.Value;
                string noidung = this.noidung.Text;
                int maDuAn = int.Parse(this.listdsDA.SelectedItem.ToString());
                decimal tien = decimal.Parse(this.sotien.Text);
                if (string.IsNullOrEmpty(nguoisudung) || string.IsNullOrEmpty(noidung) || tien <= 0 || maDuAn <= 0)
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    connection = new SqlConnection(Program.connectionString);
                    connection.Open();
                    string query = "insert into ChiPhi (NgayChungTu, NoiDung,NguoiSudung,SoTienCP,MaDA) values (@dateTime,@noidung,@nguoisudung,@tien,@maDuAn)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dateTime", dateTime);
                        command.Parameters.AddWithValue("@noidung", noidung);
                        command.Parameters.AddWithValue("@nguoisudung", nguoisudung);
                        command.Parameters.AddWithValue("@tien", tien);
                        command.Parameters.AddWithValue("@maDuAn", maDuAn);
                        command.ExecuteNonQuery();

                    }
                    MessageBox.Show("Thêm chi phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }


        }

        private void fAddChiPhi_Load(object sender, EventArgs e)
        {
            string connectionString = Program.connectionString;
            string query = "select MaDA from DuAn";
            connection = new SqlConnection(connectionString);
            connection.Open();
            using(SqlCommand  cmd = new SqlCommand(query, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string maDA = reader["MaDA"].ToString();
                        this.listdsDA.Items.Add(maDA);
                    }
                }
            }
        }
    }
}
