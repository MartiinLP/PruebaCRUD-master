using PruebaCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCRUD.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private TestCRUDContext _context;

        public PersonaRepository(TestCRUDContext context)
        {
            this._context = context;
        }

        public bool CreatePersona(Personas persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
            return true;
        }

        public Personas DetailsPersona(int Id)
        {
            var persona = _context.Personas.Where(x => x.Id == Id).First();
            return persona;
        }

        public List<Personas> GetPersonas()
        {
            var personas = _context.Personas.ToList();
            return personas;
        }

        public bool RemovePersona(int Id)
        {
            var persona = _context.Personas.Where(x => x.Id == Id).First();
            _context.Personas.Remove(persona);
            _context.SaveChanges();
            return true;
        }

        public bool UpdatePersona(Personas persona)
        {
            var _persona = _context.Personas.Where(x => x.Id == persona.Id).First();
            _context.Personas.Attach(_persona);
            _persona.Nombre = persona.Nombre;
            _persona.Correo = persona.Correo;
            _persona.Edad = persona.Edad;
            _context.SaveChanges();
            return true;
        }
    }
}
