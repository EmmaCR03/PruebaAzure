using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Api
{
    public interface IVehiculoController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid IdVehiculo);
        Task<IActionResult> Agregar(VehiculoRequest vehiculo);
        Task<IActionResult> Editar(Guid IdVehiculo, VehiculoRequest vehiculo);
        Task<IActionResult> Eliminar(Guid IdVehiculo);
    }
}
