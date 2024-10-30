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
    public partial class fSuaDA : Form
    {
        private int maDuAn;

        public fSuaDA(int maDuAn)
        {
            InitializeComponent();
            this.maDuAn = maDuAn;
        }

        public fSuaDA()
        {
            InitializeComponent();
        }

        private void fSuaDA_Load(object sender, EventArgs e)
        {
            // Hiển thị mã dự án trong label lbMaDA
            lbMaDA.Text = "Mã dự án: " + maDuAn.ToString();
            SqlConnection conn = new SqlConnection(Program.connectionString);
            string query = "select * from DuAn where MaDA = "+maDuAn;

            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            using(SqlDataReader read = cmd.ExecuteReader())
            {
                if (read.Read())
                {
                    this.txtTenDuAn.Text = read["TenDA"].ToString();
                    this.txtNoiDung.Text = read["NoiDung"].ToString();
                    this.nrudDoUuTien.Value = Convert.ToInt32(read["DoUuTien"].ToString());
                    this.dtpNgayBatDau.Text = read["NgayBatDau"].ToString();
                    this.dtpNgayKetThuc.Text = read["NgayKetThuc"].ToString();
                    this.cbbTinhTrang.Text = read["TinhTrang"].ToString();
                    this.cbbTrangThai.Text = read["TrangThai"].ToString();
                }
            }

            // Các công việc khác khi form được tải
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các controls
            string tenDuAn = string.IsNullOrEmpty(txtTenDuAn.Text) ? null : txtTenDuAn.Text;
            string noiDung = string.IsNullOrEmpty(txtNoiDung.Text) ? null : txtNoiDung.Text;
            DateTime? ngayBatDau = string.IsNullOrEmpty(dtpNgayBatDau.Text) ? (DateTime?)null : dtpNgayBatDau.Value;
            DateTime? ngayKetThuc = string.IsNullOrEmpty(dtpNgayKetThuc.Text) ? (DateTime?)null : dtpNgayKetThuc.Value;
            string trangThai = cbbTrangThai.SelectedIndex == -1 ? null : cbbTrangThai.SelectedItem.ToString();
            string tinhTrang = cbbTinhTrang.SelectedIndex == -1 ? null : cbbTinhTrang.SelectedItem.ToString();
            int? doUuTien = (int)nrudDoUuTien.Value;

            // Cập nhật dự án trong cơ sở dữ liệu
            CapNhatDuAn(maDuAn, tenDuAn, noiDung, ngayBatDau, ngayKetThuc, trangThai, tinhTrang, doUuTien);

            // Hiển thị thông báo cập nhật thành công
            MessageBox.Show("Cập nhật dự án thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }



        private void CapNhatDuAn(int maDuAn, string tenDuAn, string noiDung, DateTime? ngayBatDau, DateTime? ngayKetThuc, string trangThai, string tinhTrang, int? doUuTien)
        {
            // Thực hiện câu lệnh SQL để cập nhật dự án trong bảng DuAn
            string connectionString = Program.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE DuAn SET " +
                               "TenDA = ISNULL(@TenDA, TenDA), " +
                               "NoiDung = ISNULL(@NoiDung, NoiDung), " +
                               "NgayBatDau = ISNULL(@NgayBatDau, NgayBatDau), " +
                               "NgayKetThuc = ISNULL(@NgayKetThuc, NgayKetThuc), " +
                               "TrangThai = ISNULL(@TrangThai, TrangThai), " +
                               "TinhTrang = ISNULL(@TinhTrang, TinhTrang), " +
                               "DoUuTien = ISNULL(@DoUuTien, DoUuTien) " +
                               "WHERE MaDA = @MaDA";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDA", maDuAn);
                    command.Parameters.AddWithValue("@TenDA", (object)tenDuAn ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NoiDung", (object)noiDung ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NgayBatDau", (object)ngayBatDau ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NgayKetThuc", (object)ngayKetThuc ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TrangThai", (object)trangThai ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TinhTrang", (object)tinhTrang ?? DBNull.Value);
                    command.Parameters.AddWithValue("@DoUuTien", (object)doUuTien ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }






    }
}
