using EtkinlikTarih.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EtkinlikTarih.Controllers
{
    public class HomeController : Controller
    {
        etkinliktarihContext db = new etkinliktarihContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult EtkinlikKaydet()
        {
                var events = db.Etkinlik.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        [HttpPost]
        public JsonResult EtkinlikOlustur(Etkinlik e)
        {
            var status = false;
                if (e.Id > 0)
                {
                    var v = db.Etkinlik.Where(a => a.Id == e.Id).FirstOrDefault();
                    if (v != null)
                    {
                        v.Konu = e.Konu;
                        v.Baslangic = e.Baslangic;
                        v.Bitis = e.Bitis;
                        v.Tanim = e.Tanim;
                        v.Tumgun = e.Tumgun;
                        v.Renk = e.Renk;
                    }
                }
                else
                {
                    db.Etkinlik.Add(e);
                }
                db.SaveChanges();
                status = true;
            
            return new JsonResult { Data = new { status = status } };
        }
        [HttpPost]
        public JsonResult EtkinlikSil(int eventId)
        {
            var status = false;
           var v = db.Etkinlik.Where(a => a.Id == eventId).FirstOrDefault();
                if (v != null)
                {
                    db.Etkinlik.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
            
            return new JsonResult { Data = new { status = status } };
        }
    }
}