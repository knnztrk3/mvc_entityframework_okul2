using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_entityframework_okul2.Models;

namespace mvc_entityframework_okul2.Controllers
{
    public class OgrencilerController : Controller
    {
        okul2Entities db = new okul2Entities();
        // GET: Ogrenciler
        public ActionResult tum_ogrencileri_goster()
        {
            okul2Entities db = new okul2Entities();
            var ogrenci_listem = db.Ogrenciler.ToList();
            return View(ogrenci_listem);
        }
        public ActionResult ogrenci_kaydet()
        {
            ViewBag.sinif_adi = new SelectList(db.siniflar, "sinif_adi", "sinif_adi");
            return View();
        }
        [HttpPost]
        public ActionResult ogrenci_kaydet(Ogrenciler yeni_ogr)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    db.Ogrenciler.Add(yeni_ogr);
                    db.SaveChanges();
                    ViewBag.sonuc = "Kayıt başarılı.";
                }
            }
            catch (Exception)
            {
                ViewBag.sonuc = "Aynı numara veya E-Mail tekrar kullanılamaz.";
            }
            ViewBag.sinif_adi = new SelectList(db.siniflar, "sinif_adi", "sinif_adi");
            return View();
        }

            public ActionResult ogrenci_sil(int id)
            {
                var silinecek_ogrenci = db.Ogrenciler.Find(id);
                db.Ogrenciler.Remove(silinecek_ogrenci);
                db.SaveChanges();
                return RedirectToAction("tum_ogrencileri_goster");
            }
        }
    }