using Laureado_Ejercicio.Data;
using Laureado_Ejercicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laureado_Ejercicio.Controllers
{
    public class HomeController : Controller
    {
        PersonaAdmin admin = new PersonaAdmin();
        // GET Persona
        public ActionResult Index()
        {
            IEnumerable<Persona> list = admin.GetPersonas();
            ViewBag.message = "";
            ViewBag.error = "";
            return View(list);
        }

        public ActionResult Submit()
        {
            ViewBag.message = "";
            ViewBag.error = "";
            return View();
        }

        public ActionResult New(Persona model)
        {
            try
            {
                admin.SubmitPersona(model);
                ViewBag.message = "Persona registrada";
                ViewBag.error = "";
                return View("Submit", model);
            }
            catch(Exception ex)
            {
                ViewBag.message = "";
                ViewBag.error = "No se pudo registrar la persona";
                return View("Submit", model);
            }
           
        }

        public ActionResult Update(int id=0)
        {
            try
            {
                Persona model = admin.GetPersonaDetail(id);

                if (model == null)
                {
                    throw new Exception();
                }

                ViewBag.message = "";
                ViewBag.error = "";

                return View(model);
            }
            catch(Exception ex)
            {
                IEnumerable<Persona> list = admin.GetPersonas();
                ViewBag.message = "";
                ViewBag.error = "No se encontró el registro en la base de datos.";
                return View("Index", list);
            }
        }

        public ActionResult SubmitUpdate(Persona model)
        {
            try
            {         
                admin.Update(model);
                ViewBag.message = "Persona modificada";
                ViewBag.error = "";
                return View("Update", model);
            }
            catch(Exception ex)
            {
                ViewBag.message = "";
                ViewBag.error = "No se pudo modificar la persona";
                return View("Update", model);
            }
        }

        public ActionResult Delete(int id = 0)
        {
            try
            {
                Persona model = new Persona()
                {
                    ID = id
                };
                admin.Delete(model);
                IEnumerable<Persona> list = admin.GetPersonas();
                ViewBag.message = "Persona eliminada";
                ViewBag.error = "";
                return View("Index", list);
            }
            catch (Exception ex)
            {
                IEnumerable<Persona> list = admin.GetPersonas();
                ViewBag.message = "";
                ViewBag.error = "No se pudo eliminar a la persona";
                return View("Index", list);
            }     
        }
    }
}