using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeopetsApplication.Controllers
{
    public class PetHomeController : Controller
    {
        // GET: PetHome
        public ActionResult Index()
        {
            return View();
        }
    }
}