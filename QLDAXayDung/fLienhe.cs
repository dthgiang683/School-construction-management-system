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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLDAXayDung
{
    public partial class fLienhe : Form
    {

        private string connectionString = Program.connectionString;
        public fLienhe()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fLienhe_Load(object sender, EventArgs e)
        {

        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các controls
            string hoTen = txtHoTen.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tinNhan = txtTinNhan.Text.Trim();
            DateTime date = DateTime.Now; // Lấy thời gian hiện tại

            // Kiểm tra xem có đủ thông tin hay không
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(tinNhan))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thực hiện kết nối và thêm dữ liệu vào cơ sở dữ liệu
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO LienHe (HoTen, Email, TinNhan, Date) " +
                                   "VALUES (@HoTen, @Email, @TinNhan, @Date)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@HoTen", hoTen);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@TinNhan", tinNhan);
                        command.Parameters.AddWithValue("@Date", date);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Gửi tin nhắn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
