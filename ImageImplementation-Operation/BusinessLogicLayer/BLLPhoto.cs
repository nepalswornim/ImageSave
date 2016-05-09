using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class BLLPhoto
    {

        public int InsertPicture(string fullname, byte[] photo) {

            string sql = "insert into tbl_Image values(@a,@b)";
            SqlParameter[] param = new SqlParameter[] {
            
            new SqlParameter("@a",fullname),
            new SqlParameter("@b", photo)
            
            };
            int i = DAO.IDU(sql, param);
            return i;
        
        }
    }
}
