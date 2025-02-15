using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Revision;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public  class RevisionReglas : IRevisionReglas
    {
        private readonly IRevisionServicio _revisionServicio;
        private readonly IConfiguracion _configuration;

        public RevisionReglas(IRevisionServicio revisionServicio, IConfiguracion configuration)
        {
            _revisionServicio = revisionServicio;
            _configuration = configuration;
        }
        public async Task<bool> RevisionEsValida(string placa)
        {
            var resultadoRevision = await _revisionServicio.Obtener(placa);
            if (ValidarEstado(resultadoRevision)&&ValidarPeriodo(resultadoRevision.Periodo))
                return true;
            return false;
           

        }
        private bool ValidarEstado(Revision resultadoRevision)
        {
            string EstadoRevision = _configuration.ObtenerValor("EstadoRevisionSatisfactorio");
            return resultadoRevision.Resultado == EstadoRevision;
        }
        private static string ObtenerPeriodoActual() 
        {
            return $"{DateTime.Now.Month}-{DateTime.Now.Year}";
        }
        private static bool ValidarPeriodo(string periodo) 
        {
            var periodoActual = ObtenerPeriodoActual();
            return periodo == periodoActual;
        }
    }
}
