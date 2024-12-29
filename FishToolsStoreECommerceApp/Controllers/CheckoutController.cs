using FishToolsStoreECommerceApp.Data.ViewModels;
using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;


namespace FishToolsStoreECommerceApp.Controllers
{
    public class CheckoutController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();

        // GET: Checkout
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Months = new SelectList(Enumerable.Range(1, 12));
            ViewBag.Years = new SelectList(Enumerable.Range(DateTime.Now.Year, 20));

            return View();
        }

        [HttpPost]
        public ActionResult Payment(PaymentViewModel model)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            int id = ((Member)Session["user"]).ID;
            List<ShoppingCart> cart = db.ShoppingCarts.Where(x => x.Member_ID == id).ToList();
            TempData["cart"] = cart;
            ViewBag.Months = new SelectList(Enumerable.Range(1, 12));
            ViewBag.Years = new SelectList(Enumerable.Range(DateTime.Now.Year, 20));

            if (!ModelState.IsValid)
            {
               
                return View("Index", model);
            }
            else
            {
                double toplam = cart.Sum(x => x.Product.Price * x.Quantity);
                string fiyatstr = toplam.ToString().Replace(",", ".");
                string merchantID = "159753654";
                string merchantPass = "1234";
                //string apiurl = $"https://localhost:44342/API/PAY?kartNo={model.CardNumber}&ay={model.ExpirationMonth}&yil={model.ExpirationYear}&cvv={model.CVV}&bakiye={toplam}&merchantID={merchantID}&merchantPass={merchantPass}";
                string apiurl = "http://localhost:62970/API/PAY?kartNo="+model.CardNumber+"&ay="+model.ExpirationMonth+"&yil="+model.ExpirationYear+"&cvv="+model.CVV+"&bakiye="+fiyatstr+"&merchantID="+merchantID+"&merchantPass="+merchantPass;
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(apiurl).Result;
                var stringResp = response.Content.ReadAsStringAsync();
                if (stringResp.Result == "\"201\"")
                {
                    foreach (ShoppingCart item in cart)
                    {
                        db.ShoppingCarts.Remove(item);
                    }

                    db.SaveChanges();
                    return RedirectToAction("PaymentSuccess");
                }
                if (stringResp.Result == "\"801\"")
                {
                    ViewBag.Mesaj = "CVV Hatalı";
                }
                if (stringResp.Result == "\"901\"")
                {
                    ViewBag.Mesaj = "Kart Bulunamadı";
                }
                if (stringResp.Result == "\"701\"")
                {
                    ViewBag.Mesaj = "Satıcı Sistem hatası";
                }
                if (stringResp.Result == "\"601\"")
                {
                    ViewBag.Mesaj = "Satıcı Aktif Değil";
                }
                if (stringResp.Result == "\"501\"")
                {
                    ViewBag.Mesaj = "Son Kullanma Tarihi Geçersiz";
                }
                if (stringResp.Result == "\"401\"")
                {
                    ViewBag.Mesaj = "Kart Kullanıma Kapalı";
                }
                if (stringResp.Result == "\"301\"")
                {
                    ViewBag.Mesaj = "Bakiye Yetersiz";
                }

                return View("Index");
            }
        }
    }
}