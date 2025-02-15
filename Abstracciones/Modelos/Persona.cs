using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class PersonaBase
    {
        public string Nombre { get; set; }
        public int Apellido { get; set; }
        public int Correo { get; set; }

    }
    public class PersonaRequest : PersonaBase
    {
        public Guid Id { get; set; }
    }

    public class PersonaResponse : PersonaBase
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public int Correo { get; set; }

    }
}


