using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPublic.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
            ucDangNhap1.GetChange_DN += UcDangNhap1_GetChange_DN;
        }

        private void UcDangNhap1_GetChange_DN(object sender, EventArgs e)
        {
            if(ucDangNhap1.Tt == true)
            {
                if(Program.mainForm == null || Program.mainForm.IsDisposed)
                {
                    Program.mainForm = new MainForm();
                }
                this.Visible = false;
                Program.mainForm.Show();
            }    
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ucDangNhap1.Cnn = Properties.Settings.Default.CNN;
        }
    }
}
