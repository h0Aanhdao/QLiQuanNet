using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLyQuanNet
{
    public class DBConection
    {
        public static string chuoiketnoi = @"server = DESKTOP-TTBENK2\SQLEXPRESS; database = QuanLyQuanNet; uid =sa; pwd =1234";
        public static SqlConnection conn;


        public static DataTable TaiDuLieu(string s)
        {
            if(conn == null)
            {
                conn = new SqlConnection(chuoiketnoi);
            }    

            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            DataTable dt = new DataTable();
            SqlCommand cm = new SqlCommand(s, conn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);

            dt.Columns.Add("STT");

            int size = dt.Rows.Count;
            for (int i = 0; i < size;i++)
            {
                dt.Rows[i]["STT"] = (i + 1).ToString();
            }

            return dt;
        }


        public static DataTable Tai(string s)
        {
            if (conn == null)
            {
                conn = new SqlConnection(chuoiketnoi);
            }

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            DataTable dt = new DataTable();
            SqlCommand cm = new SqlCommand(s, conn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);

            

            return dt;
        }

        public static void OnChange(OnChangeEventHandler onChange)
        {
            if (conn == null)
            {
                conn = new SqlConnection(chuoiketnoi);
            }

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string s = "ALTER DATABASE PhongMay SET ENABLE_BROKER";
            DataTable dt = new DataTable();
            SqlCommand cm = new SqlCommand(s, conn);
            SqlDependency dependency = new SqlDependency(cm);

            dependency.OnChange += onChange;
        }



        public static bool XuLy(string s)
        {
            try
            {
                if(conn == null)
                {
                    conn = new SqlConnection(chuoiketnoi);
       
                }    

                if(conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cm = new SqlCommand(s, conn);
                cm.ExecuteNonQuery();

            } catch
            {
                return false;
            }

            return true;
        }
    }
}
