using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDAXayDung
{
    public partial class fDangky : Form
    {
        private string connectionString = Program.connectionString;
        public static bool Check_lap_gia_tri(string field, string table,string name_check)
        {
            string connectionString = Program.connectionString;
            List<string> resultList = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT " + field + " FROM " + table; // Thay thế columnName và tableName bằng tên cột và bảng thực tế của bạn

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string value = reader.GetString(0); // 0 là chỉ số cột, thay đổi nếu bạn có nhiều cột
                            resultList.Add(value);
                        }
                    }
                }
            }
            return Program.KiemTraGiaTri(name_check, resultList);
        }
        public fDangky()
        {
            InitializeComponent();
        }

        private void fDangky_Load(object sender, EventArgs e)
        {
            // Load dữ liệu vào ComboBox cbbNhanSu
            LoadNhanSuData();
        }

        private void LoadNhanSuData()
        {
            // Tạo câu lệnh SQL để lấy danh sách Tên nhân sự
         

                // Đóng kết nối
          
            
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem tất cả các trường đã được nhập chưa
            if (string.IsNullOrEmpty(txtTenDangNhap.Text) || string.IsNullOrEmpty(txtTenNguoiDung.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy mã nhân sự từ ComboBox cbbNhanSu
           

            // Lấy các giá trị từ các controls khác
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string tenNguoiDung = txtTenNguoiDung.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string mail = this.Mail.Text.Trim();
            // Quyền mặc định là "Employee"
            string quyen = "Employee";

            // Thực hiện câu lệnh SQL INSERT để thêm tài khoản mới
            if (Check_lap_gia_tri("TenDangNhap", "TaiKhoan", tenDangNhap) && Check_lap_gia_tri("Mail","TaiKhoan",mail))
            {
               

                string insertQuery = "INSERT INTO TaiKhoan (TenDangNhap, TenNguoiDung, MatKhau, Quyen, TrangThai, Mail) " +
                     "VALUES (@TenDangNhap, @TenNguoiDung, @MatKhau, @Quyen, @TrangThai,@Mail)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        command.Parameters.AddWithValue("@TenNguoiDung", tenNguoiDung);
                        command.Parameters.AddWithValue("@MatKhau", matKhau);
                        command.Parameters.AddWithValue("@Quyen", quyen);
                        command.Parameters.AddWithValue("@Mail", mail);
                      
                        command.Parameters.AddWithValue("@TrangThai", "Mở"); // Bạn có thể thay đổi giá trị trạng thái mặc định tại đây

                        // Thực hiện câu lệnh SQL INSERT
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                // Hiển thị thông báo tạo tài khoản thành công
                MessageBox.Show("Đã tạo tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa nội dung trong các controls sau khi tạo thành công (nếu muốn)
                // txtTenDangNhap.Text = "";
                // txtTenNguoiDung.Text = "";
                // txtMatKhau.Text = "";
                // cbbNhanSu.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mail đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
            }
        }


        // Class để lưu trữ thông tin nhân sự cho ComboBox
        private class NhanSuItem
        {
            public int MaNhanSu { get; }
            public string TenNhanSu { get; }

            public NhanSuItem(int maNhanSu, string tenNhanSu)
            {
                MaNhanSu = maNhanSu;
                TenNhanSu = tenNhanSu;
            }

            public override string ToString()
            {
                return TenNhanSu;
            }
        }
    }
}
