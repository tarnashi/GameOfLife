using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameOfLife.Controllers
{
    public class BaseController : Controller
    {
        protected JsonResult JsonResponse(bool flagSuccess, object data = null, string errorMessage = "")
        {
            if (flagSuccess == true)
            {
                return SuccessJsonResponse(data);
            }
            else
            {
                return FailJsonResponse(errorMessage);
            }
        }

        protected JsonResult SuccessJsonResponse(object data)
        {
            var response = new { success = true, data = data };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult FailJsonResponse(string errorMessage)
        {
            var response = new { success = false, message = errorMessage };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}