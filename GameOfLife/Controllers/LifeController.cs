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
        private Field myField; //подумать, зачем это надо?

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddField(int x, int y, bool flagBordered)
        {
            if (flagBordered)
            {
                myField = new BorderedField(x, y);
            }
            else
            {
                myField = new LoopbackField(x, y);
            }
            Session["mySession"] = myField;
            return RedirectToAction("Game", "Life");
        }

        public ActionResult Game()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ClearField()
        {
            myField = (Field)Session["mySession"];
            myField.Clear();
            Session["mySession"] = myField;
            return this.Json(myField, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPlaner()
        {
            myField = (Field)Session["mySession"];
            myField.Clear();
            myField.CurrentField[1, 0] = true;
            myField.CurrentField[2, 1] = true;
            myField.CurrentField[0, 2] = true;
            myField.CurrentField[1, 2] = true;
            myField.CurrentField[2, 2] = true;
            Session["mySession"] = myField;
            return this.Json(myField, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangeCell(int x, int y)
        {
            myField = (Field) Session["mySession"];
            myField.CurrentField[x, y] = !myField.CurrentField[x, y];
            Session["mySession"] = myField;
            return Json("");
        }

        [HttpGet]
        public JsonResult GetCurrentField()
        {
            myField = (Field) Session["mySession"];
            return this.Json(myField, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult MakeMove()
        {
            myField = (Field)Session["mySession"];
            myField.MakeMove();
            Session["mySession"] = myField;
            return this.Json(myField, JsonRequestBehavior.AllowGet);
        }
    }
}