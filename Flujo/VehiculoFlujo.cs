using Abstracciones.Interfaces.AccesoADatos;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

namespace Flujo
{
    public class VehiculoFlujo : IVehiculoFlujo
    {
        private readonly IVehiculoDA _vehiculoDA;
        private readonly IRegistroReglas _registroReglas;
        private readonly IRevisionReglas _revisionReglas;


        public VehiculoFlujo(IVehiculoDA vehiculoDA, IRegistroReglas registroReglas,
            IRevisionReglas revisionReglas) 
        {
            _vehiculoDA = vehiculoDA;
            _registroReglas = registroReglas;
            _revisionReglas = revisionReglas;
        }
        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        {
            return await _vehiculoDA.Agregar(vehiculo);  
                }

        public async Task<Guid> Editar(Guid IdVehiculo, VehiculoRequest vehiculo)
        {
            return await _vehiculoDA.Editar(IdVehiculo, vehiculo);
        }

        public async Task<Guid> Eliminar(Guid IdVehiculo)
        {
            return await _vehiculoDA.Eliminar(IdVehiculo);
        }

        public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
return      await  _vehiculoDA.Obtener();
                }

        public async Task<VehiculoDetalle?> Obtener(Guid IdVehiculo)
        {
            var vehiculo = await _vehiculoDA.Obtener(IdVehiculo);

           

            vehiculo.RegistroValido = await _registroReglas.VehiculoEstaRegistrado(vehiculo.Placa, vehiculo.CorreoPropietario);
            vehiculo.RevisionValida = await _revisionReglas.RevisionEsValida(vehiculo.Placa);

            return vehiculo;
        }
    }
}
