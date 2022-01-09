using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyQuanNet;
using System.Data;
using System.Data.SqlClient;

namespace BUS_QuanLiQuanNet
{
    public class BUS_PhongMay
    {
        DAL_PhongMay pm = new DAL_PhongMay();
        public DataTable DuLieuPhongMay()
        {
            return pm.DuLieuPhongMay();
        }
        public void OnChange(OnChangeEventHandler onChange) { pm.onChange(onChange); }
        public bool ThayDoiTrangThai(string tt, int sophut, string tenmay)
        {
            return pm.ThayDoiTrangThai(tt, sophut, tenmay);
        }

        public DataTable MayOnline()
        {
            return pm.TrangThaiOnline();
        }
    }
}
