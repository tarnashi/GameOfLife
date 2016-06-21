using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameOfLife.GameClasses;

namespace GameOfLife.Controllers
{
    public class LifeController : Controller
    {
        private Field F; //подумать, зачем это надо?

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddField(int x, int y, bool f)
        {
            if (f)
            {
                F = new BorderedField(x, y);
            }
            else
            {
                F = new LoopbackField(x, y);
            }
            Session["F"] = F;
            return RedirectToAction("Game", "Life");
        }

        public ActionResult Game()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ClearField()
        {
            var CurF = (Field)Session["F"];
            CurF.Clear();
            Session["F"] = CurF;
            return this.Json(CurF, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPlaner()
        {
            var CurF = (Field)Session["F"];
            CurF.Clear();
            CurF.ArrayCurrent[1, 0] = true;
            CurF.ArrayCurrent[2, 1] = true;
            CurF.ArrayCurrent[0, 2] = true;
            CurF.ArrayCurrent[1, 2] = true;
            CurF.ArrayCurrent[2, 2] = true;
            Session["F"] = CurF;
            return this.Json(CurF, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangeCell(int x, int y)
        {
            var CurF = (Field) Session["F"];
            CurF.ArrayCurrent[x, y] = !CurF.ArrayCurrent[x, y];
            Session["F"] = CurF;
            return Json("");
        }

        [HttpGet]
        public JsonResult GetCurrentField()
        {
            var CurF = (Field) Session["F"];
            return this.Json(CurF, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult MakeMove()
        {
            var CurF = (Field)Session["F"];
            CurF.MakeMove();
            Session["F"] = CurF;
            return this.Json(CurF, JsonRequestBehavior.AllowGet);
        }
    }
}