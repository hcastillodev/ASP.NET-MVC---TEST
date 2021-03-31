using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project8_sqlserver_plantillasenlasvistas.Models;

namespace project8_sqlserver_plantillasenlasvistas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MantenimientoArticulo allData = new MantenimientoArticulo();
            return View(allData.RecuperarTodos());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {

            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = ma.Recuperar(id);
            return View(art);
          
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            /*    try
                {
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }*/


            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo articulo = new Articulo
            {
                codigo = int.Parse(collection["codigo"]),
                description = collection["description"],
                precio = collection["precio"]

            };

            ma.Alta(articulo);

            return RedirectToAction("Index");

        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo articulo = ma.Recuperar(id);
            return View(articulo);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo articulo = new Articulo
            {
                codigo = id,
                description = collection["description"],
                precio = collection["precio"],
            };

            ma.Modificar(articulo);
            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {

            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo articulo = ma.Recuperar(id);

            return View(articulo);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            /*       try
                   {
                       // TODO: Add delete logic here

                       return RedirectToAction("Index");
                   }
                   catch
                   {
                       return View();
                   }
               }*/
            MantenimientoArticulo ma = new MantenimientoArticulo();
            ma.Borrar(id);
            return RedirectToAction("Index");

        }
    }
}
