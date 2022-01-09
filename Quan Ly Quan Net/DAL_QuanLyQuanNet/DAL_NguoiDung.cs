using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL_QuanLyQuanNet
{
    public class DAL_NguoiDung : DBConection
    {
        public DataTable DuLieu()
        {
            return DBConection.Tai(@"Select *from QuanLi");
        }
    }
}
