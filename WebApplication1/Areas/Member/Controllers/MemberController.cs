using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Member.Models.SEMember;
using NLog;
using System.Reflection;
using MvcPaging;
using WebApplication1.Areas.Member.Models.Member;
using WebApplication1.Areas.Member.Models;
using System.IO;

namespace WebApplication1.Areas.Member.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member/Member
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult questionStrCity()
        {
            MemberSearchModle search = new MemberSearchModle();
            List<SEMemberMoudle> Data = SEMemberHelper.GetData(search);
            Data = (from S in Data
                    select new SEMemberMoudle
                    {
                        strCity = S.strCity
                    }).ToList();
            var comparer = new IgnoreCaseSensitive();
            //可以先把資料倒出來到List

            Data = Data.Distinct(comparer).ToList();
            return View(Data);
        }
        // comparer
        public class IgnoreCaseSensitive : IEqualityComparer<SEMemberMoudle>
        {
            public bool Equals(SEMemberMoudle s1, SEMemberMoudle s2)
            {
                return (s1.strCity.Equals(s2.strCity));
            }
            public int GetHashCode(SEMemberMoudle item)
            {
                if (item.strCity == "") { item.strCity = "未填"; }
                return item.strCity.GetHashCode();
            }
        }
        //end  comparer
        public ActionResult getMemberCity(string city, int? page)
        {
            try
            {
                MemberSearchModle search = new MemberSearchModle();
                List<SEMemberMoudle> Data = SEMemberHelper.GetData(search);

                Data = (from d in Data
                        where d.strCity == (city ?? "")
                        orderby d.dtmBirth ascending
                        select new SEMemberMoudle
                        {
                            strCity = d.strCity,
                            strName = d.strName,
                            dtmBirth = d.dtmBirth
                        }).ToList();

                /*Data = Data.Where(x => x.strCity == (city ?? ""))
                           .OrderByDescending(x => x.dtmBirth)
                           .Select(x => new SEMemberMoudle
                            { strCity = x.strCity,
                                strName = x.strName,
                                dtmBirth = x.dtmBirth
                            })
                            .ToList();*/
                int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
                int pageSize = 20;
                ViewBag.currentPage = currentPageIndex + 1;
                ViewBag.CommentPage = pageSize;
                return View(Data.ToPagedList(currentPageIndex, pageSize));
                //    return View(Data);

            }
            catch (Exception e)
            {
                logger.Error("{0 {1}", MethodInfo.GetCurrentMethod().Name, e.Message);
                throw e;
            }
        }

        public ActionResult questionMomBaby()
        {
            MemberSearchModle memberSearch = new MemberSearchModle();
            List<SEMemberMoudle> member = SEMemberHelper.GetData(memberSearch);
            List<SEBabyMoudle> baby = SEBabyHelper.GetData();
            List<MBMoudle> data = (from M in member
                                   join B in baby on M.strMemberID equals B.strMemberID
                                   where B.strBabyName != ""
                                   select new MBMoudle
                                   {
                                       momoName = M.strName,
                                       babyName = B.strBabyName
                                   }).ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult MemberList(MemberSearchModle memberSearchModle, int? page)
        {
            try
            {
                logger.Info("進入首頁，接到參數strName={0}, strContactID = {1},  strMobile = {2}, strPhone = {3}, strEMail  = {4}",
                    memberSearchModle.strName, memberSearchModle.strContactID, memberSearchModle.strMobile, memberSearchModle.strPhone, memberSearchModle.strEMail);
                List<SEMemberMoudle> Data = SEMemberHelper.GetData(memberSearchModle);
                int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
                int pageSize = 20;
                ViewBag.currentPage = currentPageIndex + 1;
                ViewBag.CommentPage = pageSize;
                return View(Data.ToPagedList(currentPageIndex, pageSize));
                //    return View(Data);

            }
            catch (Exception e)
            {
                logger.Error("{0 {1}", MethodInfo.GetCurrentMethod().Name, e.Message);
                throw e;
            }

        }
        public ActionResult Export(MemberSearchModle search)
        {
            List<SEMemberMoudle> Data = SEMemberHelper.GetData(search);

            MemoryStream ms = new MemoryStream();
            try
            {
                //創建Excel文件
                NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                //添加一個sheet
                NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
                //序號	客戶代碼	會籍	會員姓名	手機號碼	市話號碼	E-mail	重寄驗證信
                //給Sheet1添加第一行的表頭
                NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
                row1.CreateCell(0).SetCellValue("序號");
                row1.CreateCell(1).SetCellValue("客戶代碼");
                row1.CreateCell(2).SetCellValue("會籍");
                row1.CreateCell(3).SetCellValue("會員姓名");
                row1.CreateCell(4).SetCellValue("手機號碼");
                row1.CreateCell(5).SetCellValue("市話號碼");
                row1.CreateCell(6).SetCellValue(" E-mail信箱");
                row1.CreateCell(7).SetCellValue("重寄驗證信");


                //將Data逐步寫入sheet1各欄
                for (int i = 0; i < Data.Count; i++)
                {
                    NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                    rowtemp.CreateCell(0).SetCellValue(Data[i].ROWID.ToString());
                    rowtemp.CreateCell(1).SetCellValue(Data[i].strContactID.ToString());
                    rowtemp.CreateCell(2).SetCellValue(Data[i].strMemberTypeName.ToString());
                    rowtemp.CreateCell(3).SetCellValue(Data[i].strName.ToString());
                    rowtemp.CreateCell(4).SetCellValue(Data[i].strMobile.ToString());
                    rowtemp.CreateCell(5).SetCellValue(Data[i].strPhone.ToString());
                    rowtemp.CreateCell(6).SetCellValue(Data[i].strEMail.ToString());
                    rowtemp.CreateCell(7).SetCellValue((Data[i].ysnActivate.ToString() != "False" ? "" : "重寄驗證信"));


                }
                sheet1.AutoSizeColumn(0);
                sheet1.AutoSizeColumn(1);
                sheet1.AutoSizeColumn(2);
                sheet1.AutoSizeColumn(3);
                sheet1.AutoSizeColumn(4);
                sheet1.AutoSizeColumn(5);
                sheet1.AutoSizeColumn(6);
                sheet1.AutoSizeColumn(7);

                using (FileStream fileStream = new FileStream(@"c:\test.xls", FileMode.Create, FileAccess.Write))
                {
                    book.Write(fileStream);
                    fileStream.Close();
                }

                return Json(new { status = "True" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return Json(new { status = "False" });
            }
        }



    }
}