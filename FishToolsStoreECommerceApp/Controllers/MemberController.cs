using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            if (Session["member"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Member model = (Member)Session["member"];

            return View(model);
        }
    }
}