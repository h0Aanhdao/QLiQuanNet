using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyQuanNet;
using System.Data;

namespace BUS_QuanLiQuanNet
{

    public class BUS_NguoiDung
    {
        DAL_NguoiDung bs = new DAL_NguoiDung();

        public DataTable DuLieu()
        {
            return bs.DuLieu();
        }
    }
}
