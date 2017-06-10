using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Dominio.Entidades;
using Dominio.Repositorio;

namespace Web_Examen_03.Controllers
{
    public class NegociosController : Controller
    {


        HerramientaBL herramientaBL = new HerramientaBL();
        ProveedorBL proveedorBL = new ProveedorBL();

        // GET: Negocios
        public ActionResult Index()
        {
            return View(herramientaBL.listaHerramienta());
        }
        public ActionResult RegistrarHerramienta() {

            ViewBag.proveedor = new SelectList(proveedorBL.listaProveedor(),"idprov","nomprov");


            return View(new tb_Herramienta());

        }

        [HttpPost]
        public ActionResult RegistrarHerramienta(tb_Herramienta reg)
        {

            ViewBag.proveedor = new SelectList(proveedorBL.listaProveedor(), "idprov", "nomprov",reg.idprov);

            ViewBag.mensaje = herramientaBL.AgregarHerramienta(reg);

            return View(reg);

        }

        public ActionResult EliminarHerramienta(string id) {

            var reg = herramientaBL.listaHerramienta().Where(x => x.idHer == id);


            ViewBag.mensaje = herramientaBL.EliminarHerramienta(id);

            return RedirectToAction("Index");
        }






    }
}