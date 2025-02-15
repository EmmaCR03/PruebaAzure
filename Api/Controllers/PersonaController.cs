using Abstracciones.Interfaces.Api;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase, IPersonaController
    {
        private IPersonaFlujo _personaFlujo;
        private ILogger<PersonaController> _logger;

        public PersonaController(IPersonaFlujo personaFlujo, ILogger<PersonaController> logger)
        {
            _personaFlujo = personaFlujo;
            _logger = logger;
        }
        [HttpPost]
        public Task<IActionResult> Agregar(PersonaRequest persona)
        {
            throw new NotImplementedException();
        }
        [HttpPut("{IdVehiculo}")]
        public Task<IActionResult> Editar(Guid Id, PersonaRequest vehiculo)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{IdVehiculo}")]
        public Task<IActionResult> Eliminar(Guid Id)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public Task<IActionResult> Obtener()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{IdVehiculo}")]
        public Task<IActionResult> Obtener(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
