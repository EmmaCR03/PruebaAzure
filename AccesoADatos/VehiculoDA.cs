using Abstracciones.Interfaces.AccesoADatos;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class VehiculoDA : IVehiculoDA
    {

        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Contructor 
        public VehiculoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operacionees
        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        { //el arroba es para que sea literal texto
            string query = @"AgregarVehiculo";
            //ExecuteScalarAsync esto quiere decir que el procedimiento almacenado, nos va a devolver un valor, se le tiene que especificar
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new {
                IdVehiculo = Guid.NewGuid(), 
                IdModelo = vehiculo.IdModelo,
                Placa = vehiculo.Placa,
                Color = vehiculo.Color,
                Anio = vehiculo.Anio,
                Precio = vehiculo.Precio,
                CorreoPropietario = vehiculo.CorreoPropietario,             
                TelefonoPropietario = vehiculo.TelfonoPropietario
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid IdVehiculo, VehiculoRequest vehiculo)
        {

            await VerificarVehiculoExistencia(IdVehiculo);
            string query = @"EditarVehiculo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdVehiculo = IdVehiculo,
                IdModelo = vehiculo.IdModelo,
                Placa = vehiculo.Placa,
                Color = vehiculo.Color,
                Anio = vehiculo.Anio,
                Precio = vehiculo.Precio,
                CorreoPropietario = vehiculo.CorreoPropietario,
                TelefonoPropietario = vehiculo.TelfonoPropietario
            });
            return resultadoConsulta;
        }


        public async Task<Guid> Eliminar(Guid IdVehiculo)
        {

            await VerificarVehiculoExistencia(IdVehiculo);
            string query = @"EliminarVehiculo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdVehiculo = IdVehiculo


            });
            return resultadoConsulta;
        }

            public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
            string query = @"ObtenerVehiculos";
            //ya no es ExecuteScalarAsync ahora es QueryAsync porque el obtener no devuelve un dato no solo ID si no que ya manda varios datos a la vez
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoResponse>(query);
            return resultadoConsulta;
        }

        public async Task<VehiculoDetalle> Obtener(Guid IdVehiculo)
        {
            string query = @"ObtenerVehiculoPorId";
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoDetalle>(query, new { IdVehiculo = IdVehiculo});
            return resultadoConsulta.FirstOrDefault();
        }
        #endregion
        #region Helpers privados
        private async Task VerificarVehiculoExistencia(Guid IdVehiculo)
        {
            VehiculoResponse? resultadoConsultaVehiculo = await Obtener(IdVehiculo);
            if (resultadoConsultaVehiculo == null)
                throw new Exception("No se encontro el vehiculo");
        }
        #endregion
    }
}
