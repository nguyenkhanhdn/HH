using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HH.Models;

namespace HH.Controllers
{
    public class ContributorsController : Controller
    {
        private HHDbContext db = new HHDbContext();

        // GET: Contributors
        public ActionResult Index()
        {
            var contributors = db.Contributors.Include(c => c.Project);
            return View(contributors.ToList());
        }

        // GET: Contributors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contributor contributor = db.Contributors.Find(id);
            if (contributor == null)
            {
                return HttpNotFound();
            }
            return View(contributor);
        }

        // GET: Contributors/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Address");
            return View();
        }

        // POST: Contributors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProjectId,Fullname,Email,Phone,Contribution,DoC")] Contributor contributor)
        {
            if (ModelState.IsValid)
            {
                db.Contributors.Add(contributor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Address", contributor.ProjectId);
            return View(contributor);
        }

        // GET: Contributors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contributor contributor = db.Contributors.Find(id);
            if (contributor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Address", contributor.ProjectId);
            return View(contributor);
        }

        // POST: Contributors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProjectId,Fullname,Email,Phone,Contribution,DoC")] Contributor contributor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contributor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Address", contributor.ProjectId);
            return View(contributor);
        }

        // GET: Contributors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contributor contributor = db.Contributors.Find(id);
            if (contributor == null)
            {
                return HttpNotFound();
            }
            return View(contributor);
        }

        // POST: Contributors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contributor contributor = db.Contributors.Find(id);
            db.Contributors.Remove(contributor);
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
