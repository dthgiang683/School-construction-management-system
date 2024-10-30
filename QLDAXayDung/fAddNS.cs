using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLDAXayDung
{
    public partial class fAddNS : Form
    {
        public fAddNS()
        {
            InitializeComponent();
        }

        private void fAddNS_Load(object sender, EventArgs e)
        {
            // Load danh sách dự án vào ComboBox
            LoadDuAnList();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các controls
            string tenNhanSu = txtTenNS.Text;
            DateTime ngaySinh = dtpkNgaySinh.Value;
            string gioiTinh = cbbGioiTinh.SelectedItem?.ToString(); // Sử dụng ?. để tránh lỗi nếu selectedItem là null
            string viTri = txtViTri.Text;
            string diaChi = txtDiaChi.Text;
            string dienThoai = txtDienThoai.Text;
            string duAnThucHien = cbbDuAnThucHien.SelectedItem?.ToString(); // Sử dụng ?. để tránh lỗi nếu selectedItem là null

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(tenNhanSu) || string.IsNullOrWhiteSpace(viTri) || string.IsNullOrWhiteSpace(diaChi) ||
                string.IsNullOrWhiteSpace(dienThoai) || string.IsNullOrWhiteSpace(duAnThucHien) || gioiTinh == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra điện thoại chỉ chứa số
            if (!IsPhoneNumber(dienThoai))
            {
                MessageBox.Show("Điện thoại chỉ được nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem dự án tồn tại hay không
            if (!IsDuAnExists(duAnThucHien))
            {
                MessageBox.Show("Dự án không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực hiện thêm nhân sự vào cơ sở dữ liệu
            ThemNhanSu(tenNhanSu, ngaySinh, gioiTinh, viTri, diaChi, dienThoai, duAnThucHien);

            // Đóng form hiện tại sau khi thêm
            this.Close();

            MessageBox.Show("Thêm nhân sự thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private bool IsPhoneNumber(string input)
        {
            return input.All(char.IsDigit);
        }

        private bool IsDuAnExists(string duAnThucHien)
        {
            // Kiểm tra xem dự án có tồn tại trong bảng DuAn hay không
            string connectionString = Program.connectionString;;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM DuAn WHERE TenDA = @TenDA";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDA", duAnThucHien);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
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
                            cbbDuAnThucHien.Items.Add(reader["TenDA"].ToString());
                        }
                    }
                }
            }
        }


        private void ThemNhanSu(string tenNhanSu, DateTime ngaySinh, string gioiTinh, string viTri, string diaChi, string dienThoai, string duAnThucHien)
        {
            // Thực hiện câu lệnh SQL để thêm nhân sự vào bảng NhanSu
            string connectionString = Program.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Lấy mã dự án tương ứng với tên dự án
                int maDuAn = GetMaDuAn(duAnThucHien, connection);

                // Thêm nhân sự
                string queryNhanSu = "INSERT INTO NhanSu (TenNhanSu, NgaySinh, GioiTinh, ViTri, DienThoai, DiaChi) " +
                                     "VALUES (@TenNhanSu, @NgaySinh, @GioiTinh, @ViTri, @DienThoai, @DiaChi)";
                using (SqlCommand commandNhanSu = new SqlCommand(queryNhanSu, connection))
                {
                    commandNhanSu.Parameters.AddWithValue("@TenNhanSu", tenNhanSu);
                    commandNhanSu.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    commandNhanSu.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    commandNhanSu.Parameters.AddWithValue("@ViTri", viTri);
                    commandNhanSu.Parameters.AddWithValue("@DienThoai", dienThoai);
                    commandNhanSu.Parameters.AddWithValue("@DiaChi", diaChi);

                    commandNhanSu.ExecuteNonQuery();
                }

                // Lấy mã nhân sự vừa thêm
                int maNhanSu = GetMaNhanSu(tenNhanSu, connection);

                // Thêm vào bảng NhanSu_DuAN
                string queryNhanSuDuAn = "INSERT INTO NhanSu_DuAN (MaDA, MaNhanSu, DuAnThucHien) VALUES (@MaDA, @MaNhanSu, @DuAnThucHien)";
                using (SqlCommand commandNhanSuDuAn = new SqlCommand(queryNhanSuDuAn, connection))
                {
                    commandNhanSuDuAn.Parameters.AddWithValue("@MaDA", maDuAn);
                    commandNhanSuDuAn.Parameters.AddWithValue("@MaNhanSu", maNhanSu);
                    commandNhanSuDuAn.Parameters.AddWithValue("@DuAnThucHien", duAnThucHien);

                    commandNhanSuDuAn.ExecuteNonQuery();
                }

                connection.Close();
            }
        }



        private int GetMaDuAn(string tenDuAn, SqlConnection connection)
        {
            // Lấy mã dự án tương ứng với tên dự án
            string query = "SELECT MaDA FROM DuAn WHERE TenDA = @TenDA";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TenDA", tenDuAn);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private int GetMaNhanSu(string tenNhanSu, SqlConnection connection)
        {
            // Lấy mã nhân sự tương ứng với tên nhân sự
            string query = "SELECT MaNhanSu FROM NhanSu WHERE TenNhanSu = @TenNhanSu";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TenNhanSu", tenNhanSu);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }


        private void cbbDuAnThucHien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
