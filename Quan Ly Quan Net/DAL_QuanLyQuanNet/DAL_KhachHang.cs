using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Threading.Tasks;

namespace DAL_QuanLyQuanNet
{
    public class DAL_KhachHang : DBConection
    {
        public DataTable DuLieuKhacHang()
        {
            string str = @"select *from ThanhVien";
            return DBConection.TaiDuLieu(str);
        }

        public DataTable TimKiemTaiKhoan(string tk)
        {
            string str = @"select *from ThanhVien where TaiKhoan = '" + tk + "'";
            return DBConection.TaiDuLieu(str);
        }

        public bool NapTien(string taikhoan, int sophut)
        {
            string str = @"update ThanhVien set SoPhutConLai =" + sophut + " where TaiKhoan = '" + taikhoan + "'";
            return DBConection.XuLy(str);
        }

        public bool Them(string tk, string ten, int sophut, string mk)
        {
            string str = @"insert into ThanhVien(TaiKhoan, TenThanhVien, SoPhutConLai, MatKhau) values ('" + tk + "', N'" + ten + "', " + sophut + ", '"+mk+"')";
            return DBConection.XuLy(str);
        }

        public bool ThayDoiPhut(int SoPhut, string tk)
        {
            string str = @"update ThanhVien set  SoPhutConLai = " + SoPhut + " where TaiKhoan = '" + tk + "'";
            return DBConection.XuLy(str);
        }

        public bool SuaThanhVien(string tk, string mk, string ten)
        {
            string str = @"update ThanhVien set  MatKhau = '"+mk+"', TenThanhVien = N'"+ ten + "' where TaiKhoan = '" + tk + "'";

            return DBConection.XuLy(str);
        }

        public bool Xoa(string tk)
        {
            string str = @"delete ThanhVien where TaiKhoan = '" + tk + "'";
            return DBConection.XuLy(str);
        }
    }
}
