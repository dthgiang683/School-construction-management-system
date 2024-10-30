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
    public partial class fSuaChiPhi : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;
        private int index;
        public fSuaChiPhi()
        {
            InitializeComponent();
        }
        public fSuaChiPhi(int index)
        {
            this.index = index;
            InitializeComponent();
        }
        
        private void fSuaChiPhi_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Program.connectionString);
            connection.Open();
            string query = "select [MaChiPhi],[NgayChungTu],[NoiDung],[NguoiSudung],[SoTienCP] from ChiPhi where MaChiPhi = "+this.index;
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.maChiphi.Text = reader["MaChiPhi"].ToString();
                    this.ngaychungtu.Value = Convert.ToDateTime(reader["NgayChungTu"].ToString());
                    this.noidung.Text = reader["Noidung"].ToString();
                    this.tien.Text = reader["SoTienCP"].ToString();
                    this.nguoisudung.Text = reader["NguoiSudung"].ToString();
                }
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.nguoisudung.Text) || string.IsNullOrEmpty(this.tien.Text) || string.IsNullOrEmpty(this.noidung.Text)||fAddChiPhi.check_chua_so(this.tien.Text)==false)
            {
                MessageBox.Show("Vui lòng sửa đầy đủ và đúng thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                connection = new SqlConnection(Program.connectionString);
                connection.Open();
                string nguoisudung = this.nguoisudung.Text;
                DateTime ngaychungtu = this.ngaychungtu.Value;
                string noidung = this.noidung.Text;
                decimal tien = decimal.Parse(this.tien.Text);
                string query = "update ChiPhi set NgayChungTu = @NgayChungTu, NoiDung = @NoiDung, NguoiSudung = @NguoiSudung, SoTienCP = @SoTienCP where MaChiPhi = " + this.index;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NgayChungTu", ngaychungtu);
                    command.Parameters.AddWithValue("@NoiDung", noidung);
                    command.Parameters.AddWithValue("@NguoiSudung", nguoisudung);
                    command.Parameters.AddWithValue("@SoTienCP", tien);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Sửa chi phí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                connection.Close();
            }
  
        }
    }
}
