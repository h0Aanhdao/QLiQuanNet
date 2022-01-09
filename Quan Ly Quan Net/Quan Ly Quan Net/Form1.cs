using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Quan_Net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Lock_Unloc(mySave.KT);
        }

        public void Lock_Unloc(bool x)
        {
            mnuDangNhap.Enabled = x;
            mnuDangXuat.Enabled = mnuThanhvien.Enabled = mnuKhach.Enabled = !x;
        }

        private void thànhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThanhVien frmThanhVien = new FormThanhVien();
            frmThanhVien.ShowDialog();
        }

        private void kháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhach frmKhach = new FormKhach();
            frmKhach.ShowDialog();
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            FormDangNhap frm = new FormDangNhap();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Lock_Unloc(mySave.KT);
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            mySave.KT = !mySave.KT;
            Lock_Unloc(mySave.KT);
        }
    }
}
