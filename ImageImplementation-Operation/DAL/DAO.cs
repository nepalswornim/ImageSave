using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DAL
{
  public static  class DAO
    {
       
	public static AppSettingsReader aps= new AppSettingsReader();
      public static string connstr="";
         static DAO()
         {

             connstr = aps.GetValue("myconnection", typeof(string)).ToString();
         
         
         }
         public static SqlConnection getConnection() {
             SqlConnection con = new SqlConnection(connstr);
             if (con.State!=ConnectionState.Open)
             {
                 con.Open();
             }
             return con;
         
         }
         public static int IDU (string sql,SqlParameter[] param)
         {
             using (SqlConnection con = getConnection())
             {
                 using (SqlCommand cmd=con.CreateCommand())
                 {
                     cmd.CommandText=sql;
                     if (param!=null)
                     {
                         cmd.Parameters.AddRange(param);
                     }
                     try
                     {
                         int i = cmd.ExecuteNonQuery();
                         return i;
                     }
                     catch (Exception ex)
                     {

                         throw ex;
                     }
                     
                 }
                 
             }
             
         }
      
      
      
      }
  
      
      
      
      }
		 
	


