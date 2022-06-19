using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.Models;using System.Diagnostics;

namespace DotNetAppSqlDb.Controllers
{
    public class TodosController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: Index
        public ActionResult Index()
        {            
            Trace.WriteLine("GET /Index");
            return View(new Todo { CreatedDate = DateTime.Now });
        }

        // GET: /Details/5
        public ActionResult Details(int? id)
        {
            Trace.WriteLine("GET /Details/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // GET: /Create
        public ActionResult Create()
        {
            Trace.WriteLine("GET /Todos/Create");
            return View(new Todo { CreatedDate = DateTime.Now });
        }

        // POST: /Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Story,CreatedDate")] Todo todo)
        {
            Trace.WriteLine("POST /Create");
            if (ModelState.IsValid)
            {
                db.Todoes.Add(todo);
                db.SaveChanges();
                return RedirectToAction("SuccessStories");
            }

            return View(todo);
        }

        // GET: /Edit/5
        public ActionResult Edit(int? id)
        {
            Trace.WriteLine("GET /Edit/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: /Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Title,Story,CreatedDate")] Todo todo)
        {
            Trace.WriteLine("POST /Edit/" + todo.ID);
            if (ModelState.IsValid)
            {
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SuccessStories");
            }
            return View(todo);
        }

        // GET: /Delete/5
        public ActionResult Delete(int? id)
        {
            Trace.WriteLine("GET /Delete/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: /Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trace.WriteLine("POST  /Delete/" + id);
            Todo todo = db.Todoes.Find(id);
            db.Todoes.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("SuccessStories");
        }
        // GET: /KnowYourRights
        public ActionResult KnowYourRights()
        {
            Trace.WriteLine("GET /KnowYourRights");
            return View(new Todo { CreatedDate = DateTime.Now });
        }

        // GET: /SelfDefense
        public ActionResult SelfDefense()
        {
            Trace.WriteLine("GET /SelfDefense");
            return View(new Todo { CreatedDate = DateTime.Now });
        }

        // GET: Todos/KnowYourRights
        public ActionResult SuccessStories()
        {
            Trace.WriteLine("GET /SuccessStories");
            return View(db.Todoes.AsEnumerable());
        }
        // GET: /SelfLearning
        public ActionResult SelfLearning()
        {
            Trace.WriteLine("GET /SelfLearning");
            return View(new Todo { CreatedDate = DateTime.Now });
        } 
        // GET: /JobOpportunities
        public ActionResult JobOpportunities()
        {
            Trace.WriteLine("GET /JobOpportunities");
            return View(new Todo { CreatedDate = DateTime.Now });
        }
        // GET: /AboutUs
        public ActionResult AboutUs()
        {
            Trace.WriteLine("GET /AboutUs");
            return View(new Todo { CreatedDate = DateTime.Now });
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
