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
    public partial class fDoiMK : Form
    {
        private int matk = 0;
        public fDoiMK()
        {
            InitializeComponent();
        }
        public fDoiMK(int matk)
        {
            this.matk = matk;
            InitializeComponent();
        }

        private void huy_Click(object sender, EventArgs e)
        {
            fTableManager fTableManager = new fTableManager();
            fTableManager.ShowDialog();
            this.Close();
        }

        private void fDoiMK_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.mkCu.Text) || string.IsNullOrEmpty(this.mkMoi.Text) || string.IsNullOrEmpty(this.nhapMkMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin  .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(mkMoi.Text == nhapMkMoi.Text && mkCu.Text == Program.password)
            {
                SqlConnection connection = new SqlConnection(Program.connectionString);
                connection.Open();
                using (SqlCommand command = new SqlCommand("update TaiKhoan set MatKhau = @MatKhau where MaTK = " + this.matk, connection))
                {
                    command.Parameters.AddWithValue("@MatKhau",mkMoi.Text);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                MessageBox.Show("Đổi mật khẩu thành công   .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                fLogin login = new fLogin();
                login.ShowDialog();
            }
        }
    }
}
