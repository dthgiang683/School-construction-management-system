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
    public partial class fSuaTK : Form
    {
        private string connectionString = Program.connectionString;

        private int maTK;
        public fSuaTK()
        {
            InitializeComponent();
        }

        public fSuaTK(int maTK)
        {
            this.maTK = maTK;
            InitializeComponent();
        }


        private void fSuaTK_Load(object sender, EventArgs e)
        {
            // Hiển thị mã dự án trong label lbMaDA
            lbMaTK.Text = "Mã tài khoản: " + maTK;
            SqlConnection conn = new SqlConnection(Program.connectionString);
            string query = "select * from TaiKhoan where MaTK = " + this.maTK;

            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            using (SqlDataReader read = cmd.ExecuteReader())
            {
                if (read.Read())
                {
                    this.textTenDangNhap.Text = read["TenDangNhap"].ToString();
                    this.txtTenNguoiDung.Text = read["TenNguoiDung"].ToString();
                    this.txtMatKhau.Text = read["MatKhau"].ToString();
                    this.Mail.Text = read["Mail"].ToString();
                    this.cbbQuyen.Text = read["Quyen"].ToString();
                    this.cbbTrangThai.Text = read["TrangThai"].ToString();
                }
            }

            // Load dữ liệu vào ComboBox
            LoadNhanSuData();
        }

        private void LoadNhanSuData()
        {
            // Tạo câu lệnh SQL để lấy danh sách Tên nhân sự
            string query = "SELECT * from TaiKhoan where MaTk =  "+this.maTK;

            // Mở kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thực hiện truy vấn SQL
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Đọc dữ liệu từ SqlDataReader
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        this.txtMatKhau.Text = reader["MatKhau"].ToString();
                        this.txtTenNguoiDung.Text = reader["TenNguoiDung"].ToString();
                        this.cbbTrangThai.Text = reader["TrangThai"].ToString();
                        this.cbbQuyen.Text = reader["Quyen"].ToString();
                        this.Mail.Text = reader["Mail"].ToString();
                        this.textTenDangNhap.Text = reader["TenDangNhap"].ToString();
                    }
                    
                }

                // Đóng kết nối
                connection.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy mã nhân sự từ ComboBox cbbNhanSu


            // Lấy các giá trị từ các controls khác
            string tenDangNhap = string.IsNullOrEmpty(textTenDangNhap.Text) ? null : textTenDangNhap.Text.Trim();
            string tenNguoiDung = string.IsNullOrEmpty(txtTenNguoiDung.Text) ? null : txtTenNguoiDung.Text.Trim();
            string matKhau = string.IsNullOrEmpty(txtMatKhau.Text) ? null : txtMatKhau.Text.Trim();
            string quyen = cbbQuyen.SelectedItem?.ToString();
            string trangThai = cbbTrangThai.SelectedItem?.ToString();
            string mail = this.Mail.Text.ToString();

            // Thực hiện câu lệnh SQL UPDATE
            if (string.IsNullOrEmpty(tenDangNhap)||string.IsNullOrEmpty(tenNguoiDung)||string.IsNullOrEmpty(matKhau)||string.IsNullOrEmpty(mail)||fDangky.Check_lap_gia_tri("TenDangNhap", "TaiKhoan", tenDangNhap) == false || fDangky.Check_lap_gia_tri("Mail", "TaiKhoan", mail)==false)
            {
                MessageBox.Show("Tên đăng nhập hoặc mail đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                string query = "UPDATE TaiKhoan SET " +
                           "TenDangNhap =@TenDangNhap," +
                           "TenNguoiDung = @TenNguoiDung," +
                           "MatKhau =@MatKhau," +
                           "Quyen = @Quyen ," +
                           "TrangThai = @TrangThai, " +
                           "Mail = @Mail" +
                           " WHERE MaTK = @MaTK";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaTK", maTK);
                        command.Parameters.AddWithValue("@TenDangNhap", string.IsNullOrEmpty(tenDangNhap) ? (object)DBNull.Value : tenDangNhap);
                        command.Parameters.AddWithValue("@TenNguoiDung", string.IsNullOrEmpty(tenNguoiDung) ? (object)DBNull.Value : tenNguoiDung);
                        command.Parameters.AddWithValue("@MatKhau", string.IsNullOrEmpty(matKhau) ? (object)DBNull.Value : matKhau);
                        command.Parameters.AddWithValue("@Quyen", string.IsNullOrEmpty(quyen) ? (object)DBNull.Value : quyen);
                        command.Parameters.AddWithValue("@TrangThai", string.IsNullOrEmpty(trangThai) ? (object)DBNull.Value : trangThai);
                        command.Parameters.AddWithValue("@Mail", mail);

                        // Thực hiện câu lệnh SQL UPDATE
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                // Hiển thị thông báo cập nhật thành công
                MessageBox.Show("Đã cập nhật tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi lại hàm LoadNhanSuData để refresh dữ liệu
                LoadNhanSuData();
                this.Close();
            }

        }
        private int? GetMaNhanSuFromComboBox(string tenNhanSu)
        {
            if (string.IsNullOrEmpty(tenNhanSu))
            {
                return null; // Trả về null nếu giá trị không được nhập
            }

            // Tạo câu lệnh SQL để lấy mã nhân sự từ tên nhân sự
            string query = "SELECT MaNhanSu FROM NhanSu WHERE TenNhanSu = @TenNhanSu";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Đảm bảo rằng tham số đã được thiết lập giá trị
                    command.Parameters.AddWithValue("@TenNhanSu", tenNhanSu);

                    // Thực hiện truy vấn SQL
                    object result = command.ExecuteScalar();

                    // Kiểm tra xem kết quả có phải là null hay không
                    if (result != null && result != DBNull.Value)
                    {
                        // Nếu không phải là null, thực hiện chuyển đổi và trả về giá trị
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return null; // Trả về null nếu không tìm thấy mã nhân sự
                    }
                }
            }
        }




        private void cbbNhanSu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Thêm xử lý sự kiện khi giá trị trong ComboBox thay đổi
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
