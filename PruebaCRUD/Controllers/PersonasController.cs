using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaCRUD.Models;

namespace PruebaCRUD.Controllers
{
    public class PersonasController : Controller
    {
        private TestCRUDContext _context;
        public PersonasController(TestCRUDContext context)
        {
            this._context = context;
        }       

        public IActionResult Index()
        {
            try
            {
                ViewBag.Personas = _context.Personas.ToList();
                return View("Personas");
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
                string inner = (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(500, "Message ===> " + msg + " stack ===> " + stack + " ////// inner ===> " + inner);
            }

        }

        [HttpPost("CreatePersona")]
        public IActionResult CreatePersona(Personas persona)
        {
            try
            {                
                _context.Personas.Add(persona);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
                string inner = (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(500, "Message ===> " + msg + " stack ===> " + stack + " ////// inner ===> " + inner);
            }
        }

        [HttpPost("UpdatePersona")]
        public IActionResult UpdatePersona(Personas persona)
        {
            try
            {                
                var per = _context.Personas.Where(x => x.Id == persona.Id).First();
                _context.Personas.Attach(per);
                per.Nombre = persona.Nombre;
                per.Correo = persona.Correo;
                per.Edad = persona.Edad;               
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
                string inner = (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(500, "Message ===> " + msg + " stack ===> " + stack + " ////// inner ===> " + inner);
            }
        }


        [HttpGet("PersonaById/{Id}")]
        public IActionResult PersonaById(int Id)
        {
            try
            {
                var per = _context.Personas.Where(x => x.Id == Id).First();
                return Ok(per);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
                string inner = (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(500, "Message ===> " + msg + " stack ===> " + stack + " ////// inner ===> " + inner);
            }
        }

        [HttpPost("RemovePersona")]
        public IActionResult RemovePersona(int Id)
        {
            try
            {                
                var per = _context.Personas.Where(x => x.Id == Id).First();               
                _context.Personas.Remove(per);                
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
                string inner = (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(500, "Message ===> " + msg + " stack ===> " + stack + " ////// inner ===> " + inner);
            }
        }
    }
}
