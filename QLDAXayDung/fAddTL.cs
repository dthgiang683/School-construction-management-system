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
    public partial class fAddTL : Form
    {
        public fAddTL()
        {
            InitializeComponent();
        }

        private void fAddTL_Load(object sender, EventArgs e)
        {
            LoadDuAnList();
        }




        private void btnTao_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các controls
            string tenTL = txtTenTL.Text.Trim();
            string luuTru = txtLuuTru.Text.Trim();
            DateTime thoiGianTao = dtpkThoiGianTao.Value;
            string moTa = txtMoTa.Text.Trim();
            string trangThai = cbbTrangThai.SelectedItem?.ToString();
            string tenDuAn = cbbTenDuAn.SelectedItem?.ToString();

            // Kiểm tra xem các trường có giá trị không
            if (string.IsNullOrEmpty(tenTL) || string.IsNullOrEmpty(luuTru) || string.IsNullOrEmpty(moTa) || string.IsNullOrEmpty(trangThai) || string.IsNullOrEmpty(tenDuAn))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực hiện thêm tài liệu vào cơ sở dữ liệu
            ThemTaiLieu(tenTL, thoiGianTao, luuTru, moTa, tenDuAn, trangThai);

            // Hiển thị thông báo thành công
            MessageBox.Show("Thêm tài liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ThemTaiLieu(string tenTL, DateTime thoiGianTao, string luuTru, string moTa, string tenDuAn, string trangThai)
        {
            // Lấy MaDA từ TenDuAn
            string maDuAn = LayMaDuAn(tenDuAn);

            // Kiểm tra xem MaDA có hợp lệ không
            if (string.IsNullOrEmpty(maDuAn))
            {
                MessageBox.Show("Không thể xác định MaDA cho dự án được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực hiện câu lệnh SQL để thêm tài liệu vào bảng TaiLieu
            string connectionString = Program.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO TaiLieu (TenTL, ThoiGianTao, LuuTru, MoTa, TenDuAn, TrangThai) " +
                               "VALUES (@TenTL, @ThoiGianTao, @LuuTru, @MoTa, @TenDuAn, @TrangThai)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenTL", tenTL);
                    command.Parameters.AddWithValue("@ThoiGianTao", thoiGianTao);
                    command.Parameters.AddWithValue("@LuuTru", luuTru);
                    command.Parameters.AddWithValue("@MoTa", moTa);
                    command.Parameters.AddWithValue("@TenDuAn", tenDuAn);
                    command.Parameters.AddWithValue("@TrangThai", trangThai);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private string LayMaDuAn(string tenDuAn)
        {
            string maDuAn = string.Empty;

            // Thực hiện truy vấn để lấy MaDA từ TenDuAn
            string connectionString = Program.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MaDA FROM DuAn WHERE TenDA = @TenDA";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDA", tenDuAn);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            maDuAn = reader["MaDA"].ToString();
                        }
                    }
                }
            }

            return maDuAn;
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

        private void cbbTenDuAn_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }




    }
}
