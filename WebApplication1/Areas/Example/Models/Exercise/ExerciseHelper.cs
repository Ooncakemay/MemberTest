using com.telexpress.Data.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Example.Models.Exercise
{
    public class ExerciseHelper
    {
        public static List<ExerciseModel> GetData()
        {
            List<ExerciseModel> obj = new List<ExerciseModel>();
            List<SqlParameter> param = new List<SqlParameter>();
            DataAccess da = new DataAccess();
            DataTable dt = new DataTable();


            param.Add(new SqlParameter("@key", "H"));
            //try{}  catch{} 為 C#語法
            try
            {
                dt = da.RunQuery("GetData", param.ToArray());
                if (dt.Rows.Count > 0)
                {
                    obj = (
                        //以下為LINQ的語法
                        from p in dt.Select()
                        select new ExerciseModel
                        {
                            First_nameM = p["First_name"].ToString(),
                            Last_NameM = p["Last_Name"].ToString(),
                            AddressM = p["Address"].ToString(),
                            EmailM = p["Email"].ToString()
                        }).ToList();
                }//End if (dt.Rows.Count > 0)
            }//End try
            //對例外(錯誤)的處理
            catch (Exception e)
            {

                throw e;

            }//End catch

            return obj;

        }//End ShowGB()






    }
}