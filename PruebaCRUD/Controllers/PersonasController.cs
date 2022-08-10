using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaCRUD.Models;
using PruebaCRUD.Services;

namespace PruebaCRUD.Controllers
{
    public class PersonasController :Controller
    {      
        private readonly IPersonaService _personaService;
        public PersonasController(IPersonaService personaService)
        {
            this._personaService = personaService;
        }       

        public IActionResult Index()
        {
            try
            {
                var personas = _personaService.GetPersonas();
                ViewBag.Personas = personas;
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
                var result = _personaService.CreatePersona(persona);
                return Ok(result);
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
                var result = _personaService.RemovePersona(Id);
                return Ok(result);
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
                var result = _personaService.UpdatePersona(persona);
                return Ok(result);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
                string inner = (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(500, "Message ===> " + msg + " stack ===> " + stack + " ////// inner ===> " + inner);
            }
        }

        [HttpGet("DetailsPersona/{Id}")]
        public IActionResult DetailsPersona(int Id)
        {
            try
            {
                var result = _personaService.DetailsPersona(Id);
                return Ok(result);
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
