﻿using Abstracciones.Modelos;
using Abstracciones.Modelos.Servicios.Registro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Servicios
{
    public interface IRegistroServicio
    {
        //El parametro filtra por placa 
        Task<Propietario> Obtener(string placa);
    }
    
}
