using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.AccesoADatos
{
    public interface IPersonaAD

    {
        Task<Guid> Agregar(PersonaRequest persona);
        Task<Guid> Editar(Guid Id, PersonaRequest persona);
        Task<Guid> Eliminar(Guid Id);
        Task<IEnumerable<PersonaResponse>> Obtener();
        Task<PersonaResponse> Obtener(Guid Id);


    }
}
