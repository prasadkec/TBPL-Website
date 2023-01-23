using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Totalligent.Utility;

namespace Totalligent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(Contact objCCMaster)
        {
            string JParamVal = JsonConvert.SerializeObject(objCCMaster);
            ContactBAL objBAL = new ContactBAL();
            long res = (objBAL.DMLCCMaster(JParamVal));
            return View();
        }

    }
    public class Contact
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }
        public string Option { get; set; }
    }

}