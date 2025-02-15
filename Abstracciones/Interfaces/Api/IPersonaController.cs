using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Api
{
    public interface IPersonaController
    {
        Task<IActionResult> Agregar(PersonaRequest persona);
        Task<IActionResult> Editar(Guid Id, PersonaRequest vehiculo);
        Task<IActionResult> Eliminar(Guid Id);

        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);

    }
}
