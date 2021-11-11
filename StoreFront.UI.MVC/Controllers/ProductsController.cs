﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA.EF;

namespace StoreFront.UI.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.BeerStyle).Include(p => p.Customer).Include(p => p.Employee).Include(p => p.Package).Include(p => p.Status);
            return View(products.ToList());
        }
        
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.BeerStyleID = new SelectList(db.BeerStyles, "BeerStyleID", "BeerStyle1");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustFName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EEFirstName");
            ViewBag.PkgID = new SelectList(db.Packages, "PkgID", "PkgID");
            ViewBag.ProductID = new SelectList(db.Statuses, "ProductID", "ProductStatus");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BeerID,BeerStyleID,BeerName,ABVID,DateSold,EmployeeID,ProductID,CustomerID,DirectReportID,PkgID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BeerStyleID = new SelectList(db.BeerStyles, "BeerStyleID", "BeerStyle1", product.BeerStyleID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustFName", product.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EEFirstName", product.EmployeeID);
            ViewBag.PkgID = new SelectList(db.Packages, "PkgID", "PkgID", product.PkgID);
            ViewBag.ProductID = new SelectList(db.Statuses, "ProductID", "ProductStatus", product.ProductID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BeerStyleID = new SelectList(db.BeerStyles, "BeerStyleID", "BeerStyle1", product.BeerStyleID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustFName", product.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EEFirstName", product.EmployeeID);
            ViewBag.PkgID = new SelectList(db.Packages, "PkgID", "PkgID", product.PkgID);
            ViewBag.ProductID = new SelectList(db.Statuses, "ProductID", "ProductStatus", product.ProductID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BeerID,BeerStyleID,BeerName,ABVID,DateSold,EmployeeID,ProductID,CustomerID,DirectReportID,PkgID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BeerStyleID = new SelectList(db.BeerStyles, "BeerStyleID", "BeerStyle1", product.BeerStyleID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustFName", product.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EEFirstName", product.EmployeeID);
            ViewBag.PkgID = new SelectList(db.Packages, "PkgID", "PkgID", product.PkgID);
            ViewBag.ProductID = new SelectList(db.Statuses, "ProductID", "ProductStatus", product.ProductID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
