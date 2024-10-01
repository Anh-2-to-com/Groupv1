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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormClosed += MainForm_FormClosed;
            this.qlPhanQuyen.Click += QlPhanQuyen_Click;
        }

        private void QlPhanQuyen_Click(object sender, EventArgs e)
        {
            PhanQuyenForm frm = new PhanQuyenForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.loginForm.Show();
        }
    }
}
