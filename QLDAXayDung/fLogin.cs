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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = this.tenDangNhap.Text;
            string matKhau = this.mk.Text;

            // Kiểm tra xem có nhập đủ thông tin không
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực hiện kiểm tra tài khoản trong cơ sở dữ liệu
            string connectionString = Program.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", matKhau);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Kiểm tra xem có dữ liệu trả về hay không
                        if (reader.Read())
                        {
                            // Lấy giá trị cột "TrangThai" và "Quyen"
                            string trangThai = reader["TrangThai"].ToString();
                            string quyen = reader["Quyen"].ToString();
                            int matk = Convert.ToInt32(reader["MaTK"].ToString());
                            // Kiểm tra TrangThai và Quyen
                            if (trangThai == "Mở")
                            {
                                switch (quyen)
                                {
                                    case "Admin":
                                        // Chuyển qua form fTableManager
                                        fTableManager formTableManager = new fTableManager();
                                        Program.password = matKhau;
                                        Program.maTK = matk;
                                        this.Hide();
                                        formTableManager.ShowDialog();
                                       

                                        break;

                                    case "Employee":
                                        // Chuyển qua form fEmployee
                                        fEmployee formEmployee = new fEmployee();
                                        Program.password = matKhau;
                                        Program.maTK = matk;
                                        this.Hide();
                                        formEmployee.ShowDialog();
                                       


                                        break;

                                    default:
                                        this.Close();
                                        MessageBox.Show("Quyền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản của bạn đã bị khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sai Tên đăng nhập hoặc Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
               
                connection.Close();
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            fDangky formDangKy = new fDangky();
            
            formDangKy.ShowDialog();
        }

        

        private void linkQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            fQuenMK quenMK = new fQuenMK();
            quenMK.ShowDialog();
            this.Close();

        }

        private void cbNhoMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(hienthimk.Checked)
            {
                mk.UseSystemPasswordChar = false;
            }
            else
            {
                mk.UseSystemPasswordChar =true;
            }
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void fLogin_Load_1(object sender, EventArgs e)
        {
            
        }
    }
}
