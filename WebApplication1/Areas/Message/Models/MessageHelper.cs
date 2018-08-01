using com.telexpress.Data.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Areas.Message.Models;

namespace WebApplication1.Areas.Message.Controllers
{



    public class MessageHelper
    {

        public static List<MessageModel> showMessage()
        {
            List<MessageModel> obj = new List<MessageModel>();
            List<SqlParameter> param = new List<SqlParameter>();
            DataAccess da = new DataAccess();
            DataTable dt = new DataTable();
            try
            {


                dt = da.RunQuery("showMessage", param.ToArray());
                if (dt.Rows.Count > 0)
                {
                    obj = (
                        //以下為LINQ的語法
                        from p in dt.Select()
                        select new MessageModel
                        {
                            id = p["id"].ToString(),
                            Name = p["Name"].ToString(),
                            Content = p["Content"].ToString(),
                            CreateTime = p["CreateTime"].ToString(),
                            Title = p["Title"].ToString(),
                        }).ToList();
                }//End if (dt.Rows.Count > 0)
            }//End try//對例外(錯誤)的處理
            catch (Exception e)
            {

                throw e;

            }//End catch

            return obj;

        }//End ShowGB()
         //insertMessage
        public static Boolean insertMessage(MessageModel objMessageModel)
        {

            int ChangeData = 0;
            List<SqlParameter> param = new List<SqlParameter>();
            DataAccess da = new DataAccess();
            param.Add(new SqlParameter("@Title", objMessageModel.Title ?? ""));
            param.Add(new SqlParameter("@Content", objMessageModel.Content ?? ""));
            param.Add(new SqlParameter("@Name", objMessageModel.Name ?? ""));

            try
            {
                ChangeData = da.RunNonQuery("insertMessage", param.ToArray());
            }

            catch (Exception e)
            {
                throw e;
            }

            return ChangeData > 0;


        }//End InserMessage()
        //updateMessage
        public static Boolean updateMessage(MessageModel objMessageModel)
        {

            int ChangeData = 0;
            List<SqlParameter> param = new List<SqlParameter>();
            DataAccess da = new DataAccess();
            param.Add(new SqlParameter("@id", objMessageModel.id));
            param.Add(new SqlParameter("@Title", objMessageModel.Title ?? ""));
            param.Add(new SqlParameter("@Content", objMessageModel.Content ?? ""));
            param.Add(new SqlParameter("@Name", objMessageModel.Name ?? ""));

            try
            {
                ChangeData = da.RunNonQuery("updateMessage", param.ToArray());
            }

            catch (Exception e)
            {
                throw e;
            }

            return ChangeData > 0;


        }//End UpdateMessage()
         //deleteMessage
        public static Boolean deleteMessage(String id)
        {

            int ChangeData = 0;
            List<SqlParameter> param = new List<SqlParameter>();
            DataAccess da = new DataAccess();
            param.Add(new SqlParameter("@id", id));

            try
            {
                ChangeData = da.RunNonQuery("deleteMessage", param.ToArray());
            }

            catch (Exception e)
            {
                throw e;
            }

            return ChangeData > 0;


        }//End DeleteMessage()
    }
}