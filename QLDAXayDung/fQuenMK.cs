using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
namespace QLDAXayDung
{
    public partial class fQuenMK : Form
    {
        private Random ran;
        private int mail_otp = 0;
        private bool check_da_nhap_thong_tin = false;
        private int matk;
        public fQuenMK()
        {
            InitializeComponent();
        }

        private void xacThuc_Click(object sender, EventArgs e)
        {
            ran = new Random();
            mail_otp = ran.Next(100000, 1000000);//Tao ma otp
            Send_mail_otp();
            check_da_nhap_thong_tin = true;
        }
        private void Send_mail_otp()
        {
            if (string.IsNullOrEmpty(this.tenDangNhap.Text) || string.IsNullOrEmpty(this.Mail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin .", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (isCheckgmail(this.Mail.Text))
                {
                    if(fDangky.Check_lap_gia_tri("TenDangNhap","TaiKhoan",this.tenDangNhap.Text)==false && fDangky.Check_lap_gia_tri("Mail","TaiKhoan",this.Mail.Text)==false)
                    {
                        SqlConnection connection = new SqlConnection(Program.connectionString);
                        connection.Open();
                        string query = @"select MaTK, TenDangNhap,Mail from TaiKhoan where TenDangNhap = '"+this.tenDangNhap.Text+"'";
                        SqlCommand command = new SqlCommand(query, connection);

                        SqlDataReader reader = command.ExecuteReader();
                        string tenDn = "";
                        string maTk1 = "";
                        string mail = "";
                        if (reader.Read())
                        {
                            tenDn = reader["TenDangNhap"].ToString();
                            maTk1 = reader["MaTK"].ToString();
                            mail = reader["Mail"].ToString();
                            
                        }
                        if (this.Mail.Text == mail)
                        {
                            this.matk = Convert.ToInt32(maTk1);
                            //thiết lập cấu hình gưi mail
                            string Mail_send = "ddooxgiapspro@gmail.com";
                            string Mail_recive = this.Mail.Text.ToString();
                            string pass_mail_send = "xjyesxpruuqgpdnp";
                            string content = "Your otp is :" + mail_otp;

                            MailMessage mail_temp = new MailMessage();
                            mail_temp.To.Add(Mail_recive);
                            mail_temp.From = new MailAddress(Mail_send);
                            mail_temp.Subject = "Nhóm 5 sended otp ";
                            mail_temp.Body = content;

                            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                            smtp.EnableSsl = true;
                            smtp.Port = 587;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                            smtp.Credentials = new NetworkCredential(Mail_send, pass_mail_send);

                            try
                            {
                                smtp.Send(mail_temp);
                                MessageBox.Show("Đã gửi mã otp .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            MessageBox.Show(mail +" - 1 - "+this.Mail.Text +" "+maTk1, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mail không đúng!.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    MessageBox.Show("Mail bạn nhập không đúng định dạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        private bool isCheckgmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void fQuenMK_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            fLogin login = new fLogin();
            login.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Resend_otp_Click(object sender, EventArgs e)
        {
            ran = new Random();
            mail_otp = ran.Next(100000, 1000000);//Tao ma otp
            Send_mail_otp();
        }

        private void otp_TextChanged(object sender, EventArgs e)
        {

        }

        private void get_pass_Click(object sender, EventArgs e)
        {
            if(check_da_nhap_thong_tin ==false)
            {
                MessageBox.Show("Vui lòng nhập thông tin .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(string.IsNullOrEmpty(this.otp.Text))
            {
                MessageBox.Show("Vui lòng nhập mã otp .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(Convert.ToInt32(this.otp.Text) != mail_otp)
            {
                MessageBox.Show("Mã otp không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(Convert.ToInt32(this.otp.Text) == mail_otp)
            {
                fDoi_mk_khi_lay_mk doimk = new fDoi_mk_khi_lay_mk(Convert.ToInt32(this.matk));
                doimk.ShowDialog();
                this.Close();
                
            }
        }
    }
}
