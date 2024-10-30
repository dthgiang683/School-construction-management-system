using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDAXayDung
{
    public partial class fChiTietDA : Form
    {
        private int maDuAn;
        public fChiTietDA()
        {
            InitializeComponent();
        }
        public fChiTietDA(int maDuAn)
        {
            this.maDuAn = maDuAn;
        }
        public void HienThiThongTinDuAn(int maDuAn)
        {
            // Lưu mã dự án để sử dụng trong phần LoadData hoặc các phương thức khác cần thông tin dự án
            this.maDuAn = maDuAn;

            // Gọi phương thức để load thông tin dự án
            LoadData();
        }

        private void LoadData()
        {
            // Thực hiện truy vấn để lấy thông tin chi tiết dự án dựa trên mã dự án
            string connectionString = Program.connectionString;
            string query = "SELECT * FROM DuAn WHERE MaDA = @MaDA";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDA", maDuAn);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Hiển thị thông tin chi tiết dự án lên các Label
                            lbTenDuAn.Text = "Tên dự án: " + reader["TenDA"].ToString();
                            lbNgayBatDau.Text = "Ngày bắt đầu: " + reader["NgayBatDau"].ToString();
                            lbNgayKetThuc.Text = "Ngày kết thúc: " + reader["NgayKetThuc"].ToString();
                            lbTrangThai.Text = "Trạng thái: " + reader["TrangThai"].ToString();
                            lbTinhTrang.Text = "Tình trạng: " + reader["TinhTrang"].ToString();
                            lbDoUuTien.Text = "Độ ưu tiên: " + reader["DoUuTien"].ToString();
                            lbNoiDung.Text = "Nội dung: " + reader["NoiDung"].ToString();
                            
                        }
                    }
                }

                // Kiểm tra xem có dữ liệu nào trong bảng NhanSu_DuAN có MaDA trùng với maDuAn hay không
                string nhanSuQuery = "SELECT NS.* FROM NhanSu NS JOIN NhanSu_DuAN NSDA ON NS.MaNhanSu = NSDA.MaNhanSu WHERE NSDA.MaDA = @MaDA";

                using (SqlCommand nhanSuCommand = new SqlCommand(nhanSuQuery, connection))
                {
                    nhanSuCommand.Parameters.AddWithValue("@MaDA", maDuAn);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(nhanSuCommand))
                    {
                        DataTable nhanSuTable = new DataTable();
                        adapter.Fill(nhanSuTable);

                        // Hiển thị thông tin nhân sự lên DataGridView dgvDSNS
                        dgvDSNS.DataSource = nhanSuTable;
                    }
                }
                string ngansachQuery = "  select * from NganSach where MaDA = "+this.maDuAn;
                using (SqlCommand ngansachCommand = new SqlCommand(ngansachQuery, connection))
                {
                    ngansachCommand.Parameters.AddWithValue("@MaDA", maDuAn);
                    using(SqlDataAdapter adapter = new SqlDataAdapter(ngansachCommand))
                    {
                        DataTable ngansachtb = new DataTable();
                        adapter.Fill(ngansachtb);
                        dgvTongQuanNS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        dgvTongQuanNS.DataSource = ngansachtb;
                    }
                }
                connection.Close();
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fChiTietDA_Load(object sender, EventArgs e)
        {
            // Gọi LoadData tại đây để đảm bảo thông tin được hiển thị khi form được load
            LoadData();
        }

        private void dgvDSNS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void xemchitie_ngansach_Click(object sender, EventArgs e)
        {
            fQuanLiNganSach fQuanLiNganSach = new fQuanLiNganSach();
            fQuanLiNganSach.ShowDialog();
        }

        private void btnDSNS_Click(object sender, EventArgs e)
        {
            fQuanLyNhanSu formAddDA = new fQuanLyNhanSu();
            formAddDA.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái của dự án trước khi mở form sửa
            string trangThaiDuAn = lbTrangThai.Text.Replace("Trạng thái: ", ""); // Lấy giá trị trạng thái từ Label

            // Kiểm tra nếu trạng thái là "Khóa" thì không cho sửa
            if (trangThaiDuAn.Trim().ToLower() == "khóa")
            {
                MessageBox.Show("Dự án đang ở trạng thái khóa. Không thể sửa đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Khởi tạo form fSuaDA và truyền mã dự án
            fSuaDA formSuaDA = new fSuaDA(maDuAn);

            // Hiển thị form fSuaDA
            formSuaDA.ShowDialog();
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái hiện tại của dự án
            string trangThaiDuAn = lbTrangThai.Text.Replace("Trạng thái: ", ""); // Lấy giá trị trạng thái từ Label

            // Kiểm tra nếu trạng thái là "Khóa" thì thông báo và không thực hiện chuyển trạng thái
            if (trangThaiDuAn.Trim().ToLower() == "khóa")
            {
                MessageBox.Show("Dự án đã ở trạng thái khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Chuyển trạng thái của dự án thành "Khóa"
            if (ChuyenTrangThaiDuAn(maDuAn, "Khóa"))
            {
                MessageBox.Show("Chuyển trạng thái thành khóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi chuyển trạng thái thành công, cập nhật lại dữ liệu
                LoadData();
            }
            else
            {
                MessageBox.Show("Lỗi khi chuyển trạng thái thành khóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức để chuyển trạng thái của dự án
        private bool ChuyenTrangThaiDuAn(int maDuAn, string trangThaiMoi)
        {
            try
            {
                string connectionString = Program.connectionString;
                string query = "UPDATE DuAn SET TrangThai = @TrangThaiMoi WHERE MaDA = @MaDA";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDA", maDuAn);
                        command.Parameters.AddWithValue("@TrangThaiMoi", trangThaiMoi);

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần thiết
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExportFile exportfile = new ExportFile(maDuAn);
            exportfile.ShowDialog();

        }
    }
}
