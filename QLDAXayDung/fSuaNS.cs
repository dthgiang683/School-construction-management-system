using System.Data.SqlClient;
using System.Windows.Forms;
using System;

namespace QLDAXayDung
{
    public partial class fSuaNS : Form
    {
        private int maNhanSu;

        public fSuaNS(int maNhanSu)
        {
            InitializeComponent();
            this.maNhanSu = maNhanSu; 
        }

        public fSuaNS()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Đoạn code xử lý sự kiện click trên label3
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các controls
                string tenNhanSu = string.IsNullOrEmpty(txtTenNS.Text) ? null : txtTenNS.Text;
                DateTime? ngaySinh = string.IsNullOrEmpty(dtpkNgaySinh.Text) ? (DateTime?)null : dtpkNgaySinh.Value;
                string gioiTinh = cbbGioiTinh.SelectedItem?.ToString();
                string viTri = string.IsNullOrEmpty(txtViTri.Text) ? null : txtViTri.Text;
                string diaChi = string.IsNullOrEmpty(txtDiaChi.Text) ? null : txtDiaChi.Text;
                string dienThoai = string.IsNullOrEmpty(txtDienThoai.Text) ? null : txtDienThoai.Text;
                string duAnThucHien = cbbDuAnThucHien.SelectedItem?.ToString();

                // Cập nhật nhân sự trong cơ sở dữ liệu
                CapNhatNhanSu(maNhanSu, tenNhanSu, ngaySinh, gioiTinh, viTri, diaChi, dienThoai, duAnThucHien);

                // Hiển thị thông báo cập nhật thành công
                MessageBox.Show("Cập nhật nhân sự thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đóng form sau khi cập nhật
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật nhân sự: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Các phương thức và sự kiện khác không thay đổi

        private void CapNhatNhanSu(int maNhanSu, string tenNhanSu, DateTime? ngaySinh, string gioiTinh, string viTri, string diaChi, string dienThoai, string duAnThucHien)
        {
            // Thực hiện câu lệnh SQL để cập nhật nhân sự trong bảng NhanSu
            string connectionString = Program.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Lấy mã dự án tương ứng với tên dự án
                int maDuAn = GetMaDuAn(duAnThucHien, connection);

                // Cập nhật thông tin trong bảng NhanSu_DuAN
                string queryNhanSuDuAn = "UPDATE NhanSu_DuAN SET MaDA = @MaDuAn WHERE MaNhanSu = @MaNhanSu";
                using (SqlCommand commandNhanSuDuAn = new SqlCommand(queryNhanSuDuAn, connection))
                {
                    commandNhanSuDuAn.Parameters.AddWithValue("@MaDuAn", (object)maDuAn ?? DBNull.Value);
                    commandNhanSuDuAn.Parameters.AddWithValue("@MaNhanSu", maNhanSu);

                    commandNhanSuDuAn.ExecuteNonQuery();
                }

                // Cập nhật thông tin trong bảng NhanSu
                string queryNhanSu = "UPDATE NhanSu SET " +
                                      "TenNhanSu = ISNULL(@TenNhanSu, TenNhanSu), " +
                                      "NgaySinh = ISNULL(@NgaySinh, NgaySinh), " +
                                      "GioiTinh = ISNULL(@GioiTinh, GioiTinh), " +
                                      "ViTri = ISNULL(@ViTri, ViTri), " +
                                      "DiaChi = ISNULL(@DiaChi, DiaChi), " +
                                      "DienThoai = ISNULL(@DienThoai, DienThoai) " +
                                      "WHERE MaNhanSu = @MaNhanSu";

                using (SqlCommand commandNhanSu = new SqlCommand(queryNhanSu, connection))
                {
                    commandNhanSu.Parameters.AddWithValue("@MaNhanSu", maNhanSu);
                    commandNhanSu.Parameters.AddWithValue("@TenNhanSu", (object)tenNhanSu ?? DBNull.Value);
                    commandNhanSu.Parameters.AddWithValue("@NgaySinh", (object)ngaySinh ?? DBNull.Value);
                    commandNhanSu.Parameters.AddWithValue("@GioiTinh", (object)gioiTinh ?? DBNull.Value);
                    commandNhanSu.Parameters.AddWithValue("@ViTri", (object)viTri ?? DBNull.Value);
                    commandNhanSu.Parameters.AddWithValue("@DiaChi", (object)diaChi ?? DBNull.Value);
                    commandNhanSu.Parameters.AddWithValue("@DienThoai", (object)dienThoai ?? DBNull.Value);

                    commandNhanSu.ExecuteNonQuery();
                }

                connection.Close();
            }
        }


        // Các phương thức khác không thay đổi


        private void CapNhatNhanSuDuAn(int maNhanSu, int maDuAn, SqlConnection connection)
        {
            // Cập nhật thông tin trong bảng NhanSu_DuAN
            string queryNhanSuDuAn = "UPDATE NhanSu_DuAN SET MaDA = @MaDA WHERE MaNhanSu = @MaNhanSu";
            using (SqlCommand commandNhanSuDuAn = new SqlCommand(queryNhanSuDuAn, connection))
            {
                commandNhanSuDuAn.Parameters.AddWithValue("@MaDA", maDuAn);
                commandNhanSuDuAn.Parameters.AddWithValue("@MaNhanSu", maNhanSu);

                commandNhanSuDuAn.ExecuteNonQuery();
            }
        }

        private int GetMaDuAn(string tenDuAn, SqlConnection connection)
        {
            // Lấy mã dự án tương ứng với tên dự án
            string query = "SELECT MaDA FROM DuAn WHERE TenDA = @TenDA";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Đảm bảo rằng tham số đã được thiết lập giá trị
                command.Parameters.AddWithValue("@TenDA", tenDuAn ?? (object)DBNull.Value);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }



        private void fSuaNS_Load(object sender, EventArgs e)
        {
            // Hiển thị mã nhân sự trong label
            lbMaNhanSu.Text = "Mã NS: " + maNhanSu.ToString();
            string query = "select * from NhanSu where MaNhanSu = "+this.maNhanSu;
            SqlConnection connection = new SqlConnection(Program.connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    this.txtTenNS.Text = reader["TenNhanSU"].ToString();
                    this.dtpkNgaySinh.Text = reader["NgaySinh"].ToString();
                    this.cbbGioiTinh.Text = reader["GioiTinh"].ToString();
                    this.txtDienThoai.Text = reader["DienThoai"].ToString();
                    this.txtDiaChi.Text = reader["DiaChi"].ToString();
                    this.txtViTri.Text = reader["ViTri"].ToString();

                }
            }
            // Load danh sách dự án vào ComboBox
            LoadDuAnList();
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

    }
}
