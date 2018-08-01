using MvcPaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Message.Models;

namespace WebApplication1.Areas.Message.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message/Message
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MessageWrite(){
            return View();
        }


        public ActionResult getMessage(int? page) {
            List<MessageModel> obj = MessageHelper.showMessage();
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            int pageSize = 5;
            ViewBag.currentPage = currentPageIndex + 1;
            ViewBag.CommentPage = pageSize;

            return View(obj.ToPagedList(currentPageIndex,pageSize));
        }
        public ActionResult insertMessage(MessageModel objMessageModel) {
            bool Status = false;
            Status = MessageHelper.insertMessage(objMessageModel);
            return Json(new { status = Status }, JsonRequestBehavior.AllowGet);
          
        }
        public ActionResult updateMessage(MessageModel objMessageModel)
        {
            bool Status = false;
            Status = MessageHelper.updateMessage(objMessageModel);

            return Json(new { status = Status }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult deleteMessage(String id)
        {
            bool Status = false;
            Status = MessageHelper.deleteMessage(id);
            return Json(new { status = Status }, JsonRequestBehavior.AllowGet);
        }

    }
}