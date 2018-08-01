using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Example.Models.Exercise;

namespace WebApplication1.Areas.Example.Controllers
{
    public class DAExampleController : Controller
    {
        // GET: Example/DAExample
        public ActionResult Index()
        {
            List<ExerciseModel> Data = ExerciseHelper.GetData();
            return View(Data);
        }
    }
}