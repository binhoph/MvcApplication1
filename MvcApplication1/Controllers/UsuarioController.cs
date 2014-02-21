using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using MvcApplication1.ViewModels;

namespace MvcApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        private SistemaEntities2 db = new SistemaEntities2();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(x => x.Telefone);
            return View(usuario.ToList());
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            ViewBag.idSistema = new SelectList(db.Sistema, "Id", "Nome");

            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Endereco = usuario.Endereco,
                    Idade = usuario.Idade,

                };

                var telefone = new Telefone()
                {
                    idUsuario = user.Id,
                    Tipo = usuario.Tipo,
                    Numero = usuario.Numero
                };


                user.Telefone.Add(telefone);
                
             
            
                db.Usuario.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.idSistema = new SelectList(db.Sistema, "Id", "Nome", user.idSistema);
            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }
            //ViewBag.idSistema = new SelectList(db.Sistema, "Id", "Nome", usuario.idSistema);
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.idSistema = new SelectList(db.Sistema, "Id", "Nome", usuario.idSistema);
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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