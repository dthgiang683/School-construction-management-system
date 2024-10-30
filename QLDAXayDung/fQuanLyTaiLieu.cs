using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml.Style;


namespace QLDAXayDung
{
    public partial class fQuanLyTaiLieu : Form
    {
        private string connectionString = Program.connectionString;
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;
        public fQuanLyTaiLieu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Khởi tạo form fAddTL
            fAddTL formAddTL = new fAddTL();

            // Hiển thị form fAddTL
            formAddTL.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Lấy nội dung tìm kiếm từ TextBox
            string noiDungTimKiem = txtTim.Text.Trim();

            // Kiểm tra xem đã nhập thông tin tìm kiếm hay chưa
            if (string.IsNullOrEmpty(noiDungTimKiem))
            {
                MessageBox.Show("Vui lòng nhập tên tài liệu để tìm kiếm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo câu lệnh SQL với điều kiện tìm kiếm theo tên tài liệu
            string query = "SELECT * FROM TaiLieu WHERE TenTL LIKE @NoiDung";

            // Tạo SqlDataAdapter và DataTable
            adapter = new SqlDataAdapter(query, connection);
            table = new DataTable();

            // Thêm tham số cho câu lệnh SQL
            adapter.SelectCommand.Parameters.AddWithValue("@NoiDung", "%" + noiDungTimKiem + "%");

            // Đổ dữ liệu vào DataTable
            adapter.Fill(table);

            // Kiểm tra xem có kết quả tìm kiếm không
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Hiển thị dữ liệu trong DataGridView
            dgvQuanLyTaiLieu.DataSource = table;
        }


        private void label5_Click(object sender, EventArgs e)
        {
                    }

        private void fQuanLyTaiLieu_Load(object sender, EventArgs e)
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
            // Tạo câu lệnh SQL
            string query = "SELECT * FROM TaiLieu";

            // Tạo SqlDataAdapter và DataTable
            adapter = new SqlDataAdapter(query, connection);
            table = new DataTable();

            // Đổ dữ liệu vào DataTable
            adapter.Fill(table);

            // Hiển thị dữ liệu trong DataGridView
            dgvQuanLyTaiLieu.DataSource = table;

            // Đóng kết nối sau khi sử dụng
            connection.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Gọi lại hàm LoadData để refresh dữ liệu
            LoadData();

        }

        private void btnKhoaDuLieu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn một dòng trong DataGridView chưa
            if (dgvQuanLyTaiLieu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài liệu để khoá dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy MaTL và TrangThai của tài liệu được chọn
            int maTL = Convert.ToInt32(dgvQuanLyTaiLieu.SelectedRows[0].Cells["MaTL"].Value);
            string trangThai = dgvQuanLyTaiLieu.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            // Kiểm tra xem tài liệu đã bị khóa trước đó hay không
            if (trangThai == "Khóa")
            {
                MessageBox.Show("Tài liệu này đã bị khóa trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Thực hiện câu lệnh SQL để cập nhật TrangThai của tài liệu thành "Khóa"
            string query = "UPDATE TaiLieu SET TrangThai = N'Khóa' WHERE MaTL = @MaTL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaTL", maTL);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            // Hiển thị thông báo cập nhật thành công
            MessageBox.Show("Đã khoá dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Gọi lại hàm LoadData để refresh dữ liệu
            LoadData();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvQuanLyTaiLieu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is not a header and has a value
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvQuanLyTaiLieu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                // Lấy MaTL từ dòng được chọn
                int maTL = Convert.ToInt32(dgvQuanLyTaiLieu.Rows[e.RowIndex].Cells["MaTL"].Value);

                // Chuyển sang form fSuaTL với MaTL đã chọn
                fSuaTL formSuaTL = new fSuaTL(maTL);
                formSuaTL.ShowDialog();

                // Cập nhật lại DataGridView sau khi form fSuaTL đóng (nếu có thay đổi)
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng được chọn trong DataGridView không
            if (dgvQuanLyTaiLieu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài liệu để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy MaTL và TrangThai từ dòng được chọn
            int maTL = Convert.ToInt32(dgvQuanLyTaiLieu.SelectedRows[0].Cells["MaTL"].Value);
            string trangThai = dgvQuanLyTaiLieu.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            // Kiểm tra xem TrangThai có phải là "Khóa" không
            if (trangThai == "Khóa")
            {
                MessageBox.Show("Tài liệu này đã bị khóa và không thể sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Chuyển sang form fSuaTL với MaTL đã chọn
            fSuaTL formSuaTL = new fSuaTL(maTL);
            formSuaTL.ShowDialog();  // Sử dụng ShowDialog để chặn form hiện tại cho đến khi form fSuaTL đóng

            // Cập nhật lại DataGridView sau khi form fSuaTL đóng (nếu có thay đổi)
            // Ví dụ: Reload lại dữ liệu từ cơ sở dữ liệu hoặc cập nhật dữ liệu theo MaTL nếu cần
            LoadData();
        }

        private void btnTaiVe_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dữ liệu trong DataGridView không
            if (dgvQuanLyTaiLieu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để tải về.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tạo một đối tượng ExcelPackage
            using (var excelPackage = new ExcelPackage())
            {
                // Tạo một worksheet
                var worksheet = excelPackage.Workbook.Worksheets.Add("TaiLieu");

                // Đặt tên cột
                for (int i = 1; i <= dgvQuanLyTaiLieu.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = dgvQuanLyTaiLieu.Columns[i - 1].HeaderText;
                    worksheet.Cells[1, i].Style.Font.Bold = true;
                }

                // Đổ dữ liệu từ DataGridView vào worksheet
                for (int i = 0; i < dgvQuanLyTaiLieu.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvQuanLyTaiLieu.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dgvQuanLyTaiLieu.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // Lưu file Excel
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog.FileName = "DanhSachTaiLieu.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        excelPackage.SaveAs(excelFile);
                        MessageBox.Show("Tải về thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        }

    


}
