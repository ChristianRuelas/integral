using inmobiliaria.Dato;
using inmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.Mvc;


namespace inmobiliaria.Controllers
{
    public class CasaController : Controller
    {
        CasaAdmin admin = new CasaAdmin();
        
        // GET: Casa
        public ActionResult Index()
        {
            ViewBag.sesion = "1";
           
            IEnumerable<casa> Lista = admin.consultar();
            return View(Lista);
        }
        public ActionResult Guardar()
        {
            ViewBag.mensaje = "";
            return View();
        }
        public ActionResult Nuevo(casa modelo)
        {
            admin.guardar(modelo);
            ViewBag.mensaje="Propiedad guardada";
            return View("Guardar", modelo);
        }
        public ActionResult Detalle(int id=0)
        {
            casa modelo = admin.consultarDetalles(id);
            return View(modelo);

        }
        public ActionResult Modificar(int id=0)
        {
            ViewBag.mensaje = "";
            casa modelo = admin.consultarDetalles(id);
            return View(modelo);
            
        }
        public ActionResult Actualizar(casa modelo)
        {
            admin.modificar(modelo);
            ViewBag.mensaje = "Propiedad actualizada";
            return View("Modificar", modelo);
        }
        public ActionResult Eliminar(int id = 0)
        {
            casa modelo = new casa()
            {
                Idcasa = id
            };
            try
            {
                admin.Eliminar(modelo);
            }
            catch (Exception e)
            {
                throw e;

            }
          
            IEnumerable<casa> Lista = admin.consultar();
           
            ViewBag.mensaje = "Propiedad eliminada";

            return View("Index",Lista);
        }
        [HttpPost]
        public ActionResult login(string usuario1, string pass1)
        {
            try
            {
                using (PropiedadesDbEntities contexto = new PropiedadesDbEntities())
                {
                    var lst = from d in contexto.users
                              where d.usuario == usuario1 && d.pass == pass1
                              select d;
                    if (lst.Count()>0)
                    {
                        Session["user"] = lst.First();
                        IEnumerable<casa> Lista = admin.consultar();
                        return View("index",Lista);
                    }
                    else
                    {
                        return View("loginview");
                    }
                }
                
            }
            catch (Exception e)
            {
                return Content("Ocurrio un error" + e.Message);
            }

            //return View();
        
        }
        public ActionResult loginview()
        {

            return View();
        }
        public ActionResult cerrar()
        {
            Session["user"] = null;
            IEnumerable<casa> Lista = admin.consultar();
            return View("index", Lista);
        }
    }
}