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
    public partial class PhanQuyenForm : Form
    {
        public PhanQuyenForm()
        {
            InitializeComponent();
        }

        private void qL_NhomNguoiDungBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.qL_NhomNguoiDungBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.module_DN);

        }

        private void PhanQuyenForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'module_DN.QL_NhomNguoiDung' table. You can move, or remove it, as needed.
            this.qL_NhomNguoiDungTableAdapter.Fill(this.module_DN.QL_NhomNguoiDung);
            this.qL_NhomNguoiDungDataGridView.CellClick += QL_NhomNguoiDungDataGridView_CellClick;
        }

        private void QL_NhomNguoiDungDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaNhomNguoiDung = qL_NhomNguoiDungDataGridView.CurrentRow.Cells[0].Value.ToString();
            this.custom_PhanQuyenTableAdapter.Fill(this.module_DN.Custom_PhanQuyen, MaNhomNguoiDung);
        }
    }
}
