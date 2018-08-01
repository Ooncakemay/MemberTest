using com.telexpress.Data.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Member.Models.SEMember
{
    public class SEMemberHelper
    {
        
        public static List<SEMemberMoudle> GetData(MemberSearchModle search)
        {
            List<SEMemberMoudle> obj = new List<SEMemberMoudle>();
            List<SqlParameter> param = new List<SqlParameter>();
            DataAccess da = new DataAccess();
            DataTable dt = new DataTable();
            param.Add(new SqlParameter("@strName",   search.strName ?? ""));
            param.Add(new SqlParameter("@strContactID", (search.strContactID != null) ? search.strContactID : ""));
            param.Add(new SqlParameter("@strEMail", (search.strEMail != null) ? search.strEMail : ""));
            param.Add(new SqlParameter("@strMobile", (search.strMobile != null) ? search.strMobile : ""));
            param.Add(new SqlParameter("@strPhone", (search.strPhone != null) ? search.strPhone : ""));
            param.Add(new SqlParameter("@strCity", (search.strCity != null) ? search.strCity : ""));
            try
            {


                dt = da.RunQuery("GetSEMemberData", param.ToArray());
                if (dt.Rows.Count > 0)
                {
                    obj = (
                        //以下為LINQ的語法
                        from p in dt.Select()
                        select new SEMemberMoudle
                        {
                            strMemberTypeName = p["strMemberTypeName"].ToString(),
                            strContactID = p["strContactID"].ToString(),
                            strEMail = p["strEMail"].ToString(),
                            strMobile = p["strMobile"].ToString(),
                            strName = p["strName"].ToString(),
                            strPhone = p["strPhone"].ToString(),
                            ysnActivate = p["ysnActivate"].ToString(),
                            ROWID = p["ROWID"].ToString(),
                           strCity = p["strCity"].ToString(),
                           dtmBirth = p["dtmBirth"].ToString(),
                           strMemberID = p["strMemberID"].ToString()
                        }).ToList();
                }//End if (dt.Rows.Count > 0)
            }//End try//對例外(錯誤)的處理
            catch (Exception e)
            {

                throw e;

            }//End catch

            return obj;

        }//End ShowGB()
    }
 

}