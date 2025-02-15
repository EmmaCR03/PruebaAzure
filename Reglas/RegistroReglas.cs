using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Microsoft.Extensions.Configuration;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class RegistroReglas : IRegistroReglas
    {
        private readonly IRegistroServicio _registroServicio;
        private readonly IConfiguracion _configuration;

        public RegistroReglas(IRegistroServicio registroServicio, IConfiguracion configuration)
        {
            _registroServicio = registroServicio;
            _configuration = configuration;
        }

        public async Task<bool> VehiculoEstaRegistrado(string placa, string email)
        {
            var resultadoRegistro = await _registroServicio.Obtener(placa);

            return resultadoRegistro != null && resultadoRegistro.Email == email;
        }
    }
}
