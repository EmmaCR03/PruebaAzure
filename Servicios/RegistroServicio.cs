using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Registro;
using Microsoft.Identity.Client;
using System.Net.Http;
using System.Text.Json;

namespace Servicios
{
    public class RegistroServicio : IRegistroServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _htttpClient;

        public RegistroServicio(IConfiguracion configuracion, IHttpClientFactory httpCliente)
        {
            _configuracion = configuracion;
            _htttpClient = httpCliente;
        }

        public async Task<Propietario> Obtener(string placa)
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsRegistro", "ObtenerRegistro");
            var servicioRegistro = _htttpClient.CreateClient("ServicioRegistro");
            var respuesta = await servicioRegistro.GetAsync(string.Format(endPoint,placa));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultadoDeserealizado = JsonSerializer.Deserialize<List<Propietario>>(resultado, opciones);
            return resultadoDeserealizado.FirstOrDefault();
        }
    }
}
