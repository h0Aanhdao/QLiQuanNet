using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLyQuanNet
{
    public class DAL_PhongMay :DBConection
    {
        public DataTable DuLieuPhongMay()
        {
            return DBConection.Tai(@"select *from PhongMay");
        }

        public bool ThayDoiTrangThai(string tt, int sophut, string tenmay)
        {
            return DBConection.XuLy(@"update PhongMay set TinhTrang = '" + tt + "', SoPhutChoi = '" + sophut + "' where TenMay  ='" + tenmay + "'");
        }
        public void onChange(OnChangeEventHandler onChange)
        {
            DBConection.OnChange(onChange);
        }

        public DataTable TrangThaiOnline()
        {
            return DBConection.Tai(@"select *from PhongMay where TinhTrang = 'online'");
        }
    }
}
