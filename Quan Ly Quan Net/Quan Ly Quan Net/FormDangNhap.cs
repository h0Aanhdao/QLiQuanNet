using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLiQuanNet;

namespace Quan_Ly_Quan_Net
{
    public partial class FormDangNhap : Form
    {
        BUS_NguoiDung bs = new BUS_NguoiDung();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dl = bs.DuLieu();
            for (int i = 0; i < dl.Rows.Count; i++)
            {
                if(dl.Rows[i]["TaiKhoan"].ToString() == txtTaiKhoan.Text && dl.Rows[i]["MatKhau"].ToString() == txtMatKhau.Text)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    mySave.KT = !mySave.KT;
                    
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Tài Khoản hoặc mật khẩu sai");
                    return;
                } 
                    
            }    
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
