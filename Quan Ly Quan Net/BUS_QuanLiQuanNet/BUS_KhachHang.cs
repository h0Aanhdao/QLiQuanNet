using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyQuanNet;
using System.Data;

namespace BUS_QuanLiQuanNet
{
    public class BUS_KhachHang
    {
        DAL_KhachHang kh = new DAL_KhachHang();
        public DataTable DuLieuKhachHang()
        {
            return kh.DuLieuKhacHang();
        }


        public bool ThayDoiPhut(int SoPhut, string tk)
        {
        
            return kh.ThayDoiPhut(SoPhut, tk);
        }

        public DataTable TimKiemTaiKhoan(string tk)
        {
            return kh.TimKiemTaiKhoan(tk);
        }

        public bool NapTien(string tk, int sophut)
        {
            return kh.NapTien(tk, sophut);
        }

        public bool ThemThanhVien(string tk, string ten, int sophut, string mk)
        {
            return kh.Them(tk, ten, sophut, mk);
        }

        public bool XoaThanhVien(string tk)
        {
            return kh.Xoa(tk);
        }

        public bool suathanhvien(string tk, string mk , string ten)
        {
            return kh.SuaThanhVien(tk, mk, ten);
        }
            
    }
}
