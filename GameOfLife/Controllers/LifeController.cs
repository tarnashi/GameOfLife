using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameOfLife.GameClasses;

namespace GameOfLife.Controllers
{
    public class LifeController : BaseController
    {
        private Field myField;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddField(int x, int y, bool flagBordered)
        {
            if (flagBordered == true)
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
            //return this.Json(myField, JsonRequestBehavior.AllowGet);
            return JsonResponse(true, myField);
        }

        [HttpGet]
        public JsonResult GetPlaner()
        {
            myField = (Field)Session["mySession"];
            if (myField.width < 3 || myField.height < 3)
            {
                return JsonResponse(false, errorMessage: "Поле слишком маленькое :(");
            }
            myField.SetPlaner();
            Session["mySession"] = myField;
            //return this.Json(myField, JsonRequestBehavior.AllowGet);
            return JsonResponse(true, myField);
        }

        [HttpPost]
        public JsonResult ChangeCell(int x, int y)
        {
            myField = (Field) Session["mySession"];
            myField.ChangeCell(x, y);
            Session["mySession"] = myField;
            return JsonResponse(true);
        }

        [HttpGet]
        public JsonResult GetCurrentField()
        {
            myField = (Field) Session["mySession"];
            //return this.Json(myField, JsonRequestBehavior.AllowGet);
            return JsonResponse(true, myField);
        }

        [HttpGet]
        public JsonResult MakeMove()
        {
            myField = (Field)Session["mySession"];
            myField.MakeMove();
            Session["mySession"] = myField;
            //return this.Json(myField, JsonRequestBehavior.AllowGet);
            return JsonResponse(true, myField);
        }
    }
}