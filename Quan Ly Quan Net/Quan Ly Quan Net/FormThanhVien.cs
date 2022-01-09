using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS_QuanLiQuanNet;

namespace Quan_Ly_Quan_Net
{
    public partial class FormThanhVien : Form
    {
        BUS_KhachHang kh = new BUS_KhachHang();
        public FormThanhVien()
        {
            InitializeComponent();
        }

        private void FormThanhVien_Load(object sender, EventArgs e)
        {
            dgvDanhSachThanhVien.DataSource = kh.DuLieuKhachHang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtTaiKhoan.Text == "" || txtSoTienNap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản hoặc số tiền cần nạp", "Thông báo");

            }
            else
            {

                // 5 nghàn 60 phút 1 ngàn 12 phút => 500 thì 6 phút
                int sophut = (int.Parse(txtSoTienNap.Text) / 500) * 6;
                int sophutcu = 0;
                bool check = false;
                DataTable x = kh.DuLieuKhachHang();
                int size = x.Rows.Count;
                for (int i = 0; i < size; i++)
                {
                    if(txtTaiKhoan.Text == x.Rows[i]["TaiKhoan"].ToString())
                    {
                        check = true;
                        sophutcu = int.Parse(x.Rows[i]["SoPhutConLai"].ToString());
                        break;
                    }    
                }

                if(check)
                {
                    int sophutmoi = sophutcu + sophut;
                    bool NapTien = kh.NapTien(txtTaiKhoan.Text, sophutmoi);

                    if (NapTien)
                    {
                        MessageBox.Show("Nạp thành công", "Thông báo", MessageBoxButtons.OK);
                        dgvDanhSachThanhVien.DataSource = kh.DuLieuKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 

    
            } 
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(txtTaiKhoan.Text == "")
            {
                dgvDanhSachThanhVien.DataSource = kh.DuLieuKhachHang();

            }
            else
            {
                dgvDanhSachThanhVien.DataSource = kh.TimKiemTaiKhoan(txtTaiKhoan.Text);
            } 
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtThemSoTienNap.Text== "" || txtThemTaiKhoan.Text == "" || txtThemThanhVien.Text == "" || txtMatKhauThem.Text == "")
            {
                MessageBox.Show("Bạn Chưa nhập đủ thông tin");
                    
            }
            else
            {
                int sophut = (int.Parse(txtThemSoTienNap.Text) / 500) * 6;
                bool Trung = kh.ThemThanhVien(txtThemTaiKhoan.Text, txtThemThanhVien.Text, sophut, txtMatKhauThem.Text);
                if (Trung)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    dgvDanhSachThanhVien.DataSource = kh.DuLieuKhachHang();
                    txtThemSoTienNap.Text = txtThemTaiKhoan.Text = txtThemThanhVien.Text =txtMatKhauThem.Text = "";
                } else
                {
                    MessageBox.Show("Tài khoản đã tồn tại", "Thông báo");
                }    
            } 
                

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txtTaiKhoanCanXoa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu");
            }
            else
            {
                if(MessageBox.Show("Bạn có chắc muốn xóa tài khoản này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool Xoa = kh.XoaThanhVien(txtTaiKhoanCanXoa.Text);
                    MessageBox.Show("Xóa Thành công");
                    dgvDanhSachThanhVien.DataSource = kh.DuLieuKhachHang();
                }
               
            } 
                
        }

        private void dgvDanhSachThanhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDanhSachThanhVien.Rows[e.RowIndex];
            txtTkSua.Text = row.Cells[0].Value.ToString();
            txtTenSua.Text = row.Cells[1].Value.ToString();
            txtMkSua.Text = row.Cells[3].Value.ToString();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(txtMkSua.Text == "" || txtTkSua.Text == ""|| txtTenSua.Text =="" || txtXnMkSua.Text == "" )
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin");
            } else if(txtXnMkSua.Text != txtMkSua.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận chưa đúng");
            }
            else
            {
                bool Sua = kh.suathanhvien(txtTkSua.Text, txtMkSua.Text, txtTenSua.Text);

                if(Sua)
                {
                    MessageBox.Show("Sửa thành công");
                    dgvDanhSachThanhVien.DataSource = kh.DuLieuKhachHang();
                }
                else
                {
                    MessageBox.Show("Tài khoàn không tồn tại");
                } 
                    

            } 
                
        }
    }
}
