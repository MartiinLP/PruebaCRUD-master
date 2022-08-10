using System;
using System.Collections.Generic;

namespace PruebaCRUD.Models
{
    public partial class Personas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Edad { get; set; }
    }
}
