using PruebaCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCRUD.Services
{
    public interface IPersonaService
    {
         List<Personas> GetPersonas();
         bool CreatePersona(Personas persona);
         bool RemovePersona(int Id);
         bool UpdatePersona(Personas persona);
         Personas DetailsPersona(int Id);

    }
}
