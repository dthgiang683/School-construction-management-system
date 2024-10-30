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
    public partial class fAddDA : Form
    {
        public fAddDA()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fAddDA_Load(object sender, EventArgs e)
        {

        }



        private void btnTao_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các controls
            string tenDuAn = txtTenDuAn.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();
            DateTime ngayBatDau = dtpNgayBatDau.Value;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value;
            string trangThai = cbbTrangThai.SelectedItem?.ToString();
            string tinhTrang = cbbTinhTrang.SelectedItem?.ToString();
            int doUuTien;

            // Kiểm tra xem các trường có giá trị không
            if (string.IsNullOrEmpty(tenDuAn) || string.IsNullOrEmpty(noiDung) || string.IsNullOrEmpty(trangThai) || string.IsNullOrEmpty(tinhTrang))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin dự án.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra độ ưu tiên có lớn hơn hoặc bằng 1 không
            if (!int.TryParse(nrudDoUuTien.Text, out doUuTien) || doUuTien < 1)
            {
                MessageBox.Show("Độ ưu tiên phải là số nguyên lớn hơn hoặc bằng 1.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực hiện thêm dự án vào cơ sở dữ liệu
            ThemDuAn(tenDuAn, noiDung, ngayBatDau, ngayKetThuc, trangThai, tinhTrang, doUuTien);

            // Hiển thị thông báo thành công
            MessageBox.Show("Thêm dự án thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ThemDuAn(string tenDuAn, string noiDung, DateTime ngayBatDau, DateTime ngayKetThuc, string trangThai, string tinhTrang, int doUuTien)
        {
            // Thực hiện câu lệnh SQL để thêm dự án vào bảng DuAn
            // string connectionString = "Data Source=NGUYEN-TRUONG-G\\SQLEXPRESS;Initial Catalog=TTCSN;Integrated Security=True";
            string connectionString = Program.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO DuAn (TenDA, NoiDung, NgayBatDau, NgayKetThuc, TrangThai, TinhTrang, DoUuTien) " +
                               "VALUES (@TenDA, @NoiDung, @NgayBatDau, @NgayKetThuc, @TrangThai, @TinhTrang, @DoUuTien)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDA", tenDuAn);
                    command.Parameters.AddWithValue("@NoiDung", noiDung);
                    command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                    command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                    command.Parameters.AddWithValue("@TrangThai", trangThai);
                    command.Parameters.AddWithValue("@TinhTrang", tinhTrang);
                    command.Parameters.AddWithValue("@DoUuTien", doUuTien);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
