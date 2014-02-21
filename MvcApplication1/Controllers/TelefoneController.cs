using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class TelefoneController : Controller
    {
        private SistemaEntities2 db = new SistemaEntities2();

        //
        // GET: /Telefone/

        public ActionResult Index()
        {
            var telefone = db.Telefone.Include(x => x.Usuario);
            return View(telefone.ToList());
        }

        //
        // GET: /Telefone/Details/5

        public ActionResult Details(int id = 0)
        {
            Telefone telefone = db.Telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        //
        // GET: /Telefone/Create

        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.Usuario, "Id", "Nome");
            return View();
        }

        //
        // POST: /Telefone/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Telefone.Add(telefone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.idUsuario = new SelectList(db.Usuario, "Id", "Nome", telefone.idUsuario);
            return View(telefone);
        }

        //
        // GET: /Telefone/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Telefone telefone = db.Telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.Usuario, "Id", "Nome", telefone.idUsuario);
            return View(telefone);
        }

        //
        // POST: /Telefone/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Usuario, "Id", "Nome", telefone.idUsuario);
            return View(telefone);
        }

        //
        // GET: /Telefone/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Telefone telefone = db.Telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        //
        // POST: /Telefone/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefone telefone = db.Telefone.Find(id);
            db.Telefone.Remove(telefone);
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