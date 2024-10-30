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
    public partial class fSuaTL : Form
    {

        private int maTL;
        public fSuaTL()
        {
            InitializeComponent();
        }

        public fSuaTL(int maTL)
        {
            InitializeComponent();
            this.maTL = maTL;
        }

        private void LoadDuAnList()
        {
            // Load danh sách dự án vào ComboBox
            string connectionString = Program.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT TenDA FROM DuAn";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbbTenDuAn.Items.Add(reader["TenDA"].ToString());
                        }
                    }
                }
            }
        }

        private void LoadTaiLieuInfo(int maTL)
        {
            // Lấy thông tin tài liệu từ cơ sở dữ liệu
            string connectionString = Program.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM TaiLieu WHERE MaTL = @MaTL";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaTL", maTL);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTenTL.Text = reader["TenTL"].ToString();
                            txtLuuTru.Text = reader["LuuTru"].ToString();
                            cbbTenDuAn.SelectedItem = reader["TenDuAn"].ToString();
                            txtMoTa.Text = reader["MoTa"].ToString();
                            dtpThoiGianTao.Value = Convert.ToDateTime(reader["ThoiGianTao"]);
                            cbbTrangThai.SelectedItem = reader["TrangThai"].ToString();
                        }
                    }
                }
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void fSuaTL_Load(object sender, EventArgs e)
        {
            lbMaTL.Text = "Mã tài liệu: " + maTL.ToString();

            // Load danh sách dự án vào ComboBox
            LoadDuAnList();

            // Load thông tin tài liệu vào các controls
            LoadTaiLieuInfo(maTL);
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các controls
            string tenTL = txtTenTL.Text.Trim();
            string luuTru = txtLuuTru.Text.Trim();
            string tenDuAn = cbbTenDuAn.SelectedItem?.ToString();
            string moTa = txtMoTa.Text.Trim();
            DateTime thoiGianTao = dtpThoiGianTao.Value;
            string trangThai = cbbTrangThai.SelectedItem?.ToString();

            // Cập nhật thông tin tài liệu trong cơ sở dữ liệu
            CapNhatTaiLieu(maTL, tenTL, luuTru, tenDuAn, moTa, thoiGianTao, trangThai);
            this.Close();
            // Hiển thị thông báo cập nhật thành công
            MessageBox.Show("Cập nhật tài liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CapNhatTaiLieu(int maTL, string tenTL, string luuTru, string tenDuAn, string moTa, DateTime thoiGianTao, string trangThai)
        {
            // Thực hiện câu lệnh SQL để cập nhật tài liệu trong bảng TaiLieu
            string connectionString = Program.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE TaiLieu SET " +
                               "TenTL = @TenTL, " +
                               "LuuTru = @LuuTru, " +
                               "TenDuAn = @TenDuAn, " +
                               "MoTa = @MoTa, " +
                               "ThoiGianTao = @ThoiGianTao, " +
                               "TrangThai = @TrangThai " +
                               "WHERE MaTL = @MaTL";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaTL", maTL);
                    command.Parameters.AddWithValue("@TenTL", tenTL);
                    command.Parameters.AddWithValue("@LuuTru", luuTru);
                    command.Parameters.AddWithValue("@TenDuAn", tenDuAn);
                    command.Parameters.AddWithValue("@MoTa", moTa);
                    command.Parameters.AddWithValue("@ThoiGianTao", thoiGianTao);
                    command.Parameters.AddWithValue("@TrangThai", trangThai);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }


    }
}
