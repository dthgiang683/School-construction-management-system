using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QLDAXayDung
{   
    public partial class fTableManager : Form
    {
      

        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;
        public fTableManager()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã nhập tên dự án hay chưa
            if (string.IsNullOrWhiteSpace(txtTenDA.Text))
            {
                MessageBox.Show("Vui lòng nhập tên dự án để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo câu lệnh SQL tìm kiếm với điều kiện LIKE
            string query = "SELECT * FROM DuAn WHERE TenDA LIKE '%' + @TenDA + '%'";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TenDA", txtTenDA.Text);

                // Tạo SqlDataAdapter và DataTable
                adapter = new SqlDataAdapter(command);
                table = new DataTable();

                // Đổ dữ liệu vào DataTable
                adapter.Fill(table);

                // Kiểm tra số dòng trong DataTable
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Hiển thị dữ liệu trong DataGridView
                dgvTableManager.DataSource = table;
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Khởi tạo form fQuanLyTaiLieu
            fQuanLyTaiLieu formQuanLyTaiLieu = new fQuanLyTaiLieu();

            // Hiển thị form fQuanLyTaiLieu
            formQuanLyTaiLieu.ShowDialog();
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {
            dgvTableManager.CellDoubleClick += dgvTableManager_CellDoubleClick;
            string connectionString = Program.connectionString;
           // string connectionString = "Data Source=NGUYEN-TRUONG-G\\SQLEXPRESS;Initial Catalog=TTCSN;Integrated Security=True"; // Thay thế bằng chuỗi kết nối của bạn

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
            string query = "SELECT * FROM DuAn";

            // Tạo SqlDataAdapter và DataTable
            adapter = new SqlDataAdapter(query, connection);
            table = new DataTable();
            // Đổ dữ liệu vào DataTable
            adapter.Fill(table);
            // Hiển thị dữ liệu trong DataGridView
            dgvTableManager.DataSource = table;
            // Đóng kết nối sau khi sử dụng
            connection.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Khởi tạo form fAddDA
            fAddDA formAddDA = new fAddDA();

            // Hiển thị form fAddDA
            formAddDA.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Mở lại kết nối
            connection.Open();

            // Hiển thị dữ liệu trong DataGridView
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn hay không
            if (dgvTableManager.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dự án để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy mã dự án từ dòng được chọn
            int maDuAn = Convert.ToInt32(dgvTableManager.SelectedRows[0].Cells["MaDA"].Value);

            // Kiểm tra trạng thái của dự án
            string trangThai = dgvTableManager.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            // Nếu trạng thái là "Khóa", thông báo và không mở form sửa
            if (trangThai == "Khóa")
            {
                MessageBox.Show("Dự án đang ở trạng thái khóa và không thể sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Khởi tạo form fSuaDA và truyền mã dự án
            fSuaDA formSuaDA = new fSuaDA(maDuAn);

            // Hiển thị form fSuaDA
            formSuaDA.ShowDialog();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn hay không
            if (dgvTableManager.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dự án để khoá dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy mã dự án từ dòng được chọn
            int maDuAn = Convert.ToInt32(dgvTableManager.SelectedRows[0].Cells["MaDA"].Value);

            // Chuyển trạng thái của dự án thành "Khóa"
            ChuyenTrangThaiDuAn(maDuAn, "Khóa");

            // Hiển thị lại dữ liệu trong DataGridView
            LoadData();
        }

        private void ChuyenTrangThaiDuAn(int maDuAn, string trangThaiMoi)
        {
            // Thực hiện câu lệnh SQL để cập nhật trạng thái của dự án trong bảng DuAn
            string connectionString = Program.connectionString;

           // string connectionString = "Data Source=NGUYEN-TRUONG-G\\SQLEXPRESS;Initial Catalog=TTCSN;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE DuAn SET TrangThai = @TrangThai WHERE MaDA = @MaDA";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDA", maDuAn);
                    command.Parameters.AddWithValue("@TrangThai", trangThaiMoi);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            fQuanLyNhanSu formAddDA = new fQuanLyNhanSu();
            formAddDA.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dgvTableManager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            fQuanLiNganSach formQuanLy = new fQuanLiNganSach();
            formQuanLy.ShowDialog();    
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fQuanLyTaiKhoan formNgansach = new fQuanLyTaiKhoan();
            formNgansach.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fLienhe fLienhe = new fLienhe();    
            fLienhe.ShowDialog();
        }

        private void duan_XemChiTiet_Click(object sender, EventArgs e)
        {
            fChiTietDA chiTietDA = new fChiTietDA();
            chiTietDA.ShowDialog();  //Chỉnh sửa đọan này nhé. T xem qua thấy thiếu

        }

        private void dgvTableManager_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn hay không
            if (e.RowIndex >= 0 && e.RowIndex < dgvTableManager.Rows.Count)
            {
                // Lấy mã dự án từ dòng được chọn
                int maDuAn = Convert.ToInt32(dgvTableManager.Rows[e.RowIndex].Cells["MaDA"].Value);

                // Mở form fChiTietDuAn và truyền mã dự án
                fChiTietDA formChiTietDA = new fChiTietDA();
                formChiTietDA.HienThiThongTinDuAn(maDuAn);

                // Hiển thị form fChiTietDuAn
                formChiTietDA.ShowDialog();
            }
        }

        private void dangxuat_Click(object sender, EventArgs e)
        {

            fLogin login = new fLogin();
            this.Close();
            login.ShowDialog();
           
            
        }

        private void doimatkhau_Click(object sender, EventArgs e)
        {
            fDoiMK doimk = new fDoiMK(Program.maTK);
            this.Close();
            doimk.ShowDialog();
        }
    }
}
