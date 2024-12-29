using FishToolsStoreECommerceApp.Areas.ManagerPanel.Filters;
using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Areas.ManagerPanel.Controllers
{
    [ManagerAuthorizationFilter]
    public class OrderController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();

        public ActionResult Index()
        {
            List<Order> orders = db.Orders.Where(p => p.IsCancelled == false).ToList();
            return View(orders);
        }

        public ActionResult AllIndex()
        {
            return View(db.Orders.ToList());
        }

        // GET: ManagerPanel/Product/Details/5
        public ActionResult OrderDetails(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Order");
            }
            ViewBag.id = id;
            List<OrderDetail> od = db.OrdersDetails.Where(x => x.Order_ID == id).ToList();
            if (od.Count == 0)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }
            return View(od);
        }
    }
}