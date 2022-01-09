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
using BUS_QuanLiQuanNet;

namespace Quan_Ly_Quan_Net
{
    public partial class FormKhach : Form
    {
        BUS_PhongMay pm = new BUS_PhongMay();
        BUS_KhachHang kh = new BUS_KhachHang();
        public FormKhach()
        {
            InitializeComponent();
        }

        private void FormKhach_Load(object sender, EventArgs e)
        {
            timer1.Start();
            dgvDanhSachMay.DataSource = pm.DuLieuPhongMay();

        }

        private void FormKhach_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer1.Stop();
        }

        DataGridViewRow row = null;
        private void dgvDanhSachMay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = dgvDanhSachMay.Rows[e.RowIndex];
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (row == null)
            {
                MessageBox.Show("Bạn Chưa Chọn Máy");
            }
            else
            {
                DataTable x = pm.DuLieuPhongMay();

                int size = x.Rows.Count;
                if (row.Cells[0].Value == null) return;
                string TenMay = row.Cells[0].Value.ToString();
                for (int i = 0; i < size; i++)
                {
                    if (x.Rows[i]["TenMay"].ToString() == TenMay)
                    {
                        if (x.Rows[i]["TinhTrang"].ToString() == "online")
                        {
                            MessageBox.Show("Máy Đã Có Người Chơi");
                            break;
                        }
                        else
                        {
                            pm.ThayDoiTrangThai("online", 999, x.Rows[i]["TenMay"].ToString());
                            dgvDanhSachMay.DataSource = pm.DuLieuPhongMay();
                            break;
                        }

                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (row == null)
            {
                MessageBox.Show("Bạn Chưa Chọn Máy");
            }
            else
            {
                DataTable dulieu = new DataTable();
                if (row.Cells[1].Value?.ToString() == "offline")
                {
                    MessageBox.Show("Máy đang offline");
                }
                else
                {
                    if (row.Cells[3].Value?.ToString() != "")
                    {
                        if(row != null)
                        {
                            /*DataTable dlKhach = kh.DuLieuKhachHang();
                            int count = dlKhach.Rows.Count;
                            //MessageBox.Show(row.Cells[3].Value.ToString());
                            for (int i = 0; i < count; i++)
                            {
                                if(row.Cells[3].Value.ToString() == dlKhach.Rows[i]["TaiKhoan"].ToString())
                                {
                                    int SoPhutKhachCo = int.Parse(dlKhach.Rows[i]["SoPhutConLai"].ToString());
                                    int SoPhutChoi = SoPhutKhachCo - int.Parse(row.Cells[2].Value.ToString());
                                    double gia = (SoPhutChoi / 60.0) * 5000;
                                    MessageBox.Show("Tổng tiền là " + gia.ToString());
                                    pm.ThayDoiTrangThai("offline", 0, row.Cells[0].Value.ToString());
                                    kh.ThayDoiPhut(int.Parse(row.Cells[2].Value.ToString()), dlKhach.Rows[i]["TaiKhoan"].ToString());
                                    dgvDanhSachMay.DataSource = pm.DuLieuPhongMay();
                                    break;
                                }    
                            }    */
                        }    
                    }
                    else
                    {
                        int SoPhutChoi = 999 - int.Parse(row.Cells[2].Value.ToString());
                        double gia = (5000 / 60) * SoPhutChoi;
                        MessageBox.Show("Số Tiền cấn thanh Toán là " + gia.ToString(), "Thanh Toán", MessageBoxButtons.OK);
                        pm.ThayDoiTrangThai("offline", 0, row.Cells[0].Value?.ToString());

                        dgvDanhSachMay.DataSource = pm.DuLieuPhongMay();
                    }

                }

            }
        }

        private void btnTatMay_Click(object sender, EventArgs e)
        {
            if (row == null)
            {
                MessageBox.Show("Bạn Chưa Chọn Máy");
            }
            else
            {
                DataTable dulieu = new DataTable();
                if (row.Cells[1].Value!=null)
                {
                    if (row.Cells[1].Value.ToString() == "offline")
                    {
                        var tenmay = row.Cells[0].Value.ToString();
                        pm.ThayDoiTrangThai("offline", 0, tenmay);
                        var lst = pm.DuLieuPhongMay();
                        for (int i = lst.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow dr = lst.Rows[i];
                            if (dr["TenMay"]?.ToString() == tenmay)
                            {
                                dr.Delete();
                                break;
                            }
                        }
                        lst.AcceptChanges();

                        dgvDanhSachMay.DataSource = lst;
                        MessageBox.Show("Tắt máy thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Máy đang online");
                    }
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {           
            dgvDanhSachMay.DataSource = pm.DuLieuPhongMay();
            //Console.WriteLine("update");
        }
    }
}
