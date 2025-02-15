using Abstracciones.Interfaces.AccesoADatos;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class PersonaFlujo : IPersonaFlujo
    {
        IPersonaAD _persona;

        public PersonaFlujo(IPersonaAD persona)
        {
            _persona = persona;
        }
        public Task<Guid> Agregar(PersonaRequest persona)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Editar(Guid Id, PersonaRequest persona)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Eliminar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonaResponse>> Obtener()
        {
            throw new NotImplementedException();
        }

        public Task<PersonaResponse> Obtener(Guid persona)
        {
            throw new NotImplementedException();
        }
    }
}