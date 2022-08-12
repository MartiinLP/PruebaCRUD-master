using PruebaCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaCRUD.Repository;

namespace PruebaCRUD.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        public PersonaService(IPersonaRepository personaRepository)
        {
            this._personaRepository = personaRepository;
        }
        public bool CreatePersona(Personas persona)
        {
                bool result = _personaRepository.CreatePersona(persona);
                return true;                                  
        }

        public Personas DetailsPersona(int Id)
        {
            Personas persona = _personaRepository.DetailsPersona(Id);
            return persona;
        }

        public List<Personas> GetPersonas()
        {
            List<Personas> personas = _personaRepository.GetPersonas();
            return personas;
        }

        public bool RemovePersona(int Id)
        {
            bool result = _personaRepository.RemovePersona(Id);
            return true;
        }

        public bool UpdatePersona(Personas persona)
        {
            bool result = _personaRepository.UpdatePersona(persona);
            return true;
        }
    }
}
