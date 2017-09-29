using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using appHarborApplication.Models;

namespace appHarborApplication.Controllers
{
    public class CountryManageController : Controller
    {
        private dbLocationEntities db = new dbLocationEntities();

        //
        // GET: /CountryManage/

        public ActionResult Index()
        {
            return View(db.tblCountries.ToList());
        }

        //
        // GET: /CountryManage/Details/5

        public ActionResult Details(int id = 0)
        {
            tblCountry tblcountry = db.tblCountries.Find(id);
            if (tblcountry == null)
            {
                return HttpNotFound();
            }
            return View(tblcountry);
        }

        //
        // GET: /CountryManage/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CountryManage/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblCountry tblcountry)
        {
            if (ModelState.IsValid)
            {
                db.tblCountries.Add(tblcountry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblcountry);
        }

        //
        // GET: /CountryManage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblCountry tblcountry = db.tblCountries.Find(id);
            if (tblcountry == null)
            {
                return HttpNotFound();
            }
            return View(tblcountry);
        }

        //
        // POST: /CountryManage/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblCountry tblcountry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcountry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblcountry);
        }

        //
        // GET: /CountryManage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblCountry tblcountry = db.tblCountries.Find(id);
            if (tblcountry == null)
            {
                return HttpNotFound();
            }
            return View(tblcountry);
        }

        //
        // POST: /CountryManage/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCountry tblcountry = db.tblCountries.Find(id);
            db.tblCountries.Remove(tblcountry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}