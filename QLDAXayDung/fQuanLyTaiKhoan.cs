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
    public partial class fQuanLyTaiKhoan : Form
    {
        private string connectionString = Program.connectionString;
        public fQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void fQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            // Tạo kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Tạo câu lệnh SQL
                    string query = "SELECT * FROM TaiKhoan";

                    // Tạo SqlDataAdapter và DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        // Đổ dữ liệu vào DataTable
                        adapter.Fill(table);

                        // Hiển thị dữ liệu trong DataGridView
                        dgvQuanLyTaiKhoan.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            // Lấy nội dung tìm kiếm từ TextBox
            string noiDungTimKiem = txtTim.Text.Trim();

            // Kiểm tra xem đã nhập thông tin tìm kiếm hay chưa
            if (string.IsNullOrEmpty(noiDungTimKiem))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản cần tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Tạo câu lệnh SQL với điều kiện tìm kiếm theo tên tài khoản
                    string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap LIKE @NoiDung";

                    // Tạo SqlDataAdapter và DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        // Thêm tham số cho câu lệnh SQL
                        adapter.SelectCommand.Parameters.AddWithValue("@NoiDung", "%" + noiDungTimKiem + "%");

                        // Đổ dữ liệu vào DataTable
                        adapter.Fill(table);

                        // Kiểm tra xem có kết quả tìm kiếm không
                        if (table.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy tài khoản nào có tên tương tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Hiển thị dữ liệu trong DataGridView
                        dgvQuanLyTaiKhoan.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Gọi lại hàm LoadData để refresh dữ liệu
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Tạo câu lệnh SQL
                    string query = "SELECT * FROM TaiKhoan";

                    // Tạo SqlDataAdapter và DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        // Đổ dữ liệu vào DataTable
                        adapter.Fill(table);

                        // Hiển thị dữ liệu trong DataGridView
                        dgvQuanLyTaiKhoan.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn một dòng trong DataGridView chưa
            if (dgvQuanLyTaiKhoan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để khóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy giá trị của cột TrangThai tương ứng với dòng được chọn
            string trangThai = dgvQuanLyTaiKhoan.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            // Kiểm tra xem tài khoản đã ở trạng thái khóa chưa
            if (trangThai == "Khóa")
            {
                MessageBox.Show("Tài khoản này đã ở trạng thái khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn khóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Lấy MaTK của tài khoản được chọn
                int maTK = Convert.ToInt32(dgvQuanLyTaiKhoan.SelectedRows[0].Cells["MaTK"].Value);

                // Thực hiện câu lệnh SQL để cập nhật TrangThai của tài khoản thành "Khóa"
                string query = "UPDATE TaiKhoan SET TrangThai = N'Khóa' WHERE MaTK = @MaTK";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaTK", maTK);

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                // Hiển thị thông báo cập nhật thành công
                MessageBox.Show("Đã khóa tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi lại hàm LoadData để refresh dữ liệu
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn hay không
            if (dgvQuanLyTaiKhoan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dự án để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy mã dự án từ dòng được chọn
            int maDuAn = Convert.ToInt32(dgvQuanLyTaiKhoan.SelectedRows[0].Cells["MaTK"].Value);

            // Kiểm tra trạng thái của dự án
            string trangThai = dgvQuanLyTaiKhoan.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            // Nếu trạng thái là "Khóa", thông báo và không mở form sửa
            if (trangThai == "Khóa")
            {
                MessageBox.Show("Tài khoản đang ở trạng thái khóa và không thể sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Khởi tạo form fSuaDA và truyền mã dự án
            fSuaTK formSuaTK = new fSuaTK(maDuAn);

            // Hiển thị form fSuaDA
            formSuaTK.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            fDangky formDangky = new fDangky();


            formDangky.ShowDialog();
        }
    }
}
