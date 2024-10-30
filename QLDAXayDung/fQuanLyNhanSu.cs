using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;

namespace QLDAXayDung
{
    public partial class fQuanLyNhanSu : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;

        public fQuanLyNhanSu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện click trên label1
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện click trên label3
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện click trên label2
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có nhân sự được chọn không
            if (dgvQuanLyNhanSu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân sự để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy mã nhân sự từ DataGridView
            int maNhanSu = Convert.ToInt32(dgvQuanLyNhanSu.SelectedRows[0].Cells["MaNhanSu"].Value);

            // Xác nhận việc xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân sự này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Thực hiện câu lệnh SQL để xóa nhân sự
                XoaNhanSu(maNhanSu);

                // Hiển thị thông báo xóa thành công
                MessageBox.Show("Xóa nhân sự thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại DataGridView sau khi xóa
                LoadData();
            }
        }

        private void XoaNhanSu(int maNhanSu)
        {
            // Thực hiện câu lệnh SQL để xóa các dự án của nhân sự trong bảng NhanSu_DuAN
            string connectionString = Program.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryXoaDuAn = "DELETE FROM NhanSu_DuAN WHERE MaNhanSu = @MaNhanSu";

                using (SqlCommand commandXoaDuAn = new SqlCommand(queryXoaDuAn, connection))
                {
                    commandXoaDuAn.Parameters.AddWithValue("@MaNhanSu", maNhanSu);

                    commandXoaDuAn.ExecuteNonQuery();
                }

                // Sau đó, thực hiện câu lệnh SQL để xóa nhân sự trong bảng NhanSu
                string queryNhanSu = "DELETE FROM NhanSu WHERE MaNhanSu = @MaNhanSu";

                using (SqlCommand commandNhanSu = new SqlCommand(queryNhanSu, connection))
                {
                    commandNhanSu.Parameters.AddWithValue("@MaNhanSu", maNhanSu);

                    commandNhanSu.ExecuteNonQuery();
                }

                connection.Close();
            }
        }



        private void label8_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện click trên label8
        }

        private void fQuanLyNhanSu_Load(object sender, EventArgs e)
        {
            string connectionString = Program.connectionString;
            // Khởi tạo kết nối
            connection = new SqlConnection(connectionString);

            // Mở kết nối
            connection.Open();

            // Hiển thị dữ liệu trong DataGridView
            LoadData();
        }

        private void LoadData()
        {
            // Tạo câu lệnh SQL với INNER JOIN giữa NhanSu và NhanSu_DuAN
            string query = "SELECT NhanSu.*, NhanSu_DuAN.DuAnThucHien " +
                           "FROM NhanSu " +
                           "INNER JOIN NhanSu_DuAN ON NhanSu.MaNhanSu = NhanSu_DuAN.MaNhanSu";

            // Tạo SqlDataAdapter và DataTable
            adapter = new SqlDataAdapter(query, connection);
            table = new DataTable();

            // Đổ dữ liệu vào DataTable
            adapter.Fill(table);

            // Hiển thị dữ liệu trong DataGridView
            dgvQuanLyNhanSu.DataSource = table;

            // Đóng kết nối sau khi sử dụng
            connection.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Khởi tạo form fAddNS
            fAddNS formAddNS = new fAddNS();

            // Hiển thị form fAddNS
            formAddNS.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Gọi lại hàm LoadData để refresh dữ liệu
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có nhân sự được chọn không
            if (dgvQuanLyNhanSu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân sự để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy mã nhân sự từ DataGridView
            int maNhanSu = Convert.ToInt32(dgvQuanLyNhanSu.SelectedRows[0].Cells["MaNhanSu"].Value);

            // Mở form "Sửa" với mã nhân sự đã chọn
            fSuaNS formSuaNS = new fSuaNS(maNhanSu);
            formSuaNS.ShowDialog();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            // Lấy tên nhân sự từ TextBox
            string tenNhanSuTimKiem = txtTenNS.Text.Trim();

            // Kiểm tra xem đã nhập thông tin tìm kiếm chưa
            if (string.IsNullOrEmpty(tenNhanSuTimKiem))
            {
                MessageBox.Show("Vui lòng nhập tên nhân sự để tìm kiếm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo câu lệnh SQL với INNER JOIN giữa NhanSu và NhanSu_DuAN và điều kiện tìm kiếm
            string query = "SELECT NhanSu.*, NhanSu_DuAN.DuAnThucHien " +
                           "FROM NhanSu " +
                           "INNER JOIN NhanSu_DuAN ON NhanSu.MaNhanSu = NhanSu_DuAN.MaNhanSu " +
                           "WHERE TenNhanSu LIKE @TenNhanSu";

            // Tạo SqlDataAdapter và DataTable
            adapter = new SqlDataAdapter(query, connection);
            table = new DataTable();

            // Thêm tham số cho câu lệnh SQL
            adapter.SelectCommand.Parameters.AddWithValue("@TenNhanSu", "%" + tenNhanSuTimKiem + "%");

            // Đổ dữ liệu vào DataTable
            adapter.Fill(table);

            // Kiểm tra xem có kết quả tìm kiếm không
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Hiển thị dữ liệu trong DataGridView
            dgvQuanLyNhanSu.DataSource = table;
        }

        private void txtTenNS_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
