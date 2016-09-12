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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddField(int x, int y, bool flagBordered)
        {
            Field myField;
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
            Field myField;
            myField = (Field)Session["mySession"];
            myField.Clear();
            Session["mySession"] = myField;
            return SuccessJsonResponse(myField);
        }

        [HttpGet]
        public JsonResult GetPlaner()
        {
            Field myField;
            myField = (Field)Session["mySession"];
            if (myField.width < 3 || myField.height < 3)
            {
                return FailJsonResponse("Поле слишком маленькое :(");
            }
            myField.SetPlaner();
            Session["mySession"] = myField;
            return SuccessJsonResponse(myField);
        }

        [HttpPost]
        public JsonResult ChangeCell(int x, int y)
        {
            Field myField;
            myField = (Field) Session["mySession"];
            myField.ChangeCell(x, y);
            Session["mySession"] = myField;
            return SuccessJsonResponse();
        }

        [HttpGet]
        public JsonResult GetCurrentField()
        {
            Field myField;
            myField = (Field) Session["mySession"];
            return SuccessJsonResponse(myField);
        }
        
        [HttpGet]
        public JsonResult MakeMove()
        {
            Field myField;
            myField = (Field)Session["mySession"];
            myField.MakeMove();
            Session["mySession"] = myField;
            return SuccessJsonResponse(myField);
        }
    }
}