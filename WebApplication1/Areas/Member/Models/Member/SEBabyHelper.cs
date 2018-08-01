using com.telexpress.Data.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Member.Models.Member
{
    public class SEBabyHelper
    {
        public static List<SEBabyMoudle> GetData()
        {
            List<SEBabyMoudle> obj = new List<SEBabyMoudle>();
            List<SqlParameter> param = new List<SqlParameter>();
            DataAccess da = new DataAccess();
            DataTable dt = new DataTable();
            
            try
            {
                dt = da.RunQuery("GetSE_Baby", param.ToArray());
                if (dt.Rows.Count > 0)
                {
                    obj = (
                        //以下為LINQ的語法
                        from p in dt.Select()
                        select new SEBabyMoudle
                        {
                            strBabyID = p["strBabyID"].ToString(),
                            strGDBabyID= p["strGDBabyID"].ToString(),
                            strMemberID= p["strMemberID"].ToString(),
                            strBabyName= p["strBabyName"].ToString(),
                            intBirthOrder= p["intBirthOrder"].ToString(),
                            dtmBabyBirth= p["dtmBabyBirth"].ToString(),
                            strBabyGender= p["strBabyGender"].ToString(),
                            strZipCode= p["strZipCode"].ToString(),
                            strCompanyID= p["strCompanyID"].ToString(),
                            strOtherCompany= p["strOtherCompany"].ToString(),
                            strAuditStatus= p["strAuditStatus"].ToString(),
                            strAuditDoc= p["strAuditDoc"].ToString(),
                            strDocName= p["strDocName"].ToString(),
                            strAuditWay= p["strAuditWay"].ToString(),
                            dtmCreate= p["dtmCreate"].ToString(),
                            strWHO= p["strWHO"].ToString(),
                            dtmUpdate= p["dtmUpdate"].ToString(),
                            intSeqNo= p["intSeqNo"].ToString(),
                            strKOLTypeID= p["strKOLTypeID"].ToString()
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