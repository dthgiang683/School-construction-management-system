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
    public partial class fDoi_mk_khi_lay_mk : Form
    {
        private int maTk = 0;
        public fDoi_mk_khi_lay_mk()
        {
            InitializeComponent();
        }
        public fDoi_mk_khi_lay_mk(int matk)
        {
            this.maTk = matk;
            InitializeComponent();
        }

        private void fDoi_mk_khi_lay_mk_Load(object sender, EventArgs e)
        {
            nhapMK.UseSystemPasswordChar = true;
            nhapLaimk.UseSystemPasswordChar = true;
        }

        private void doimk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.nhapMK.Text) || string.IsNullOrEmpty(this.nhapLaimk.Text)){
                MessageBox.Show("Vui lòng nhập đủ thông tin  .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection connection = new SqlConnection(Program.connectionString);
                connection.Open();
                using (SqlCommand command = new SqlCommand("update TaiKhoan set MatKhau = @MatKhau where MaTK = " + this.maTk, connection))
                {
                    command.Parameters.AddWithValue("@MatKhau", this.nhapMK.Text);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                MessageBox.Show("Đổi mật khẩu thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fLogin fLogin = new fLogin();
                this.Close();
                fLogin.ShowDialog();    

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void hideOr_CheckedChanged(object sender, EventArgs e)
        {
            if(hideOr.Checked)
            {
                nhapMK.UseSystemPasswordChar = false;
                nhapLaimk.UseSystemPasswordChar = false;
            }
            else
            {
                nhapMK.UseSystemPasswordChar = true;
                nhapLaimk.UseSystemPasswordChar = true;
            }
        }
    }
}
