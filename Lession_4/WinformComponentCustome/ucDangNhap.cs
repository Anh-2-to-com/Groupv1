using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformComponentCustome
{
    public partial class ucDangNhap : UserControl
    {
        QL_NguoiDung CauHinh = new QL_NguoiDung();
        string cnn;
        public event EventHandler GetChange_DN;
        bool tt;

        public string Cnn { get => cnn; set => cnn = value; }
        public bool Tt { get => tt; set => tt = value; }

        public ucDangNhap()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống" + lblUserName.Text.ToLower());
                this.txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show("Không được bỏ trống" + lblPassword.Text.ToLower());
                this.txtPassword.Focus();
                return;
            }
            int kq = CauHinh.Check_Config(cnn); //hàm Check_Config() thuộc Class QL_NguoiDung
            if (kq == 0)
            {
                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");// Xử lý cấu hình
                //ProcessConfig();
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");// Xử lý cấu hình
                //ProcessConfig();
            }
        }

        public void ProcessLogin()
        {
            Tt = false;
            LoginResult result;
            result = CauHinh.Check_User(txtUserName.Text, txtPassword.Text, cnn); //Check_User viết trong Class QL_NguoiDung
            // Wrong username or pass
            if (result == LoginResult.Invalid)
            {
                MessageBox.Show("Sai " + lblUserName.Text + " Hoặc " + lblPassword.Text);
                return;
            }
            // Account had been disabled
            else if (result == LoginResult.Disabled)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            MessageBox.Show("Đăng nhập thành công");

            Tt = true;
            GetChange_DN.Invoke(this, EventArgs.Empty);
        }
    }

    public enum LoginResult
    {
        /// <summary>
        /// Wrong username or password
        /// </summary>
        Invalid,
        /// <summary>
        /// User had been disabled
        /// </summary>
        Disabled,
        /// <summary>
        /// Loging success
        /// </summary>
        Success
    }
}
