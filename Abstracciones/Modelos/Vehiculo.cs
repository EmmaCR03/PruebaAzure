using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Abstracciones.Modelos
{
    public class VehiculoBase
    {
        [Required(ErrorMessage = "La propiedad placa es requerida")]
        [RegularExpression(@"[A-Za-z]{3}-[0-9]{3}", ErrorMessage = "El formato de la placa debe ser ###-000")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "La propiedad color es requerida")]
        [StringLength(40, ErrorMessage = "La propiedad color debe tener entre 4 y 40 caracteres", MinimumLength = 4)]
        public string Color { get; set; }

        [Required(ErrorMessage = "La propiedad Anio es requerida")]
        [Range(1900, 2099, ErrorMessage = "El año debe estar entre 1900 y 2099")]
        public int Anio { get; set; }
        [Required(ErrorMessage = "La propiedad precio es requerida")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "La propiedad correo es requerida")]
        [EmailAddress]
        public string CorreoPropietario { get; set; }

        [Required(ErrorMessage = "La propiedad teléfono es requerida")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener exactamente 8 dígitos")]
        public string TelfonoPropietario { get; set; }

    }
    public class VehiculoRequest : VehiculoBase 
    { 
     public Guid IdModelo { get; set; }
    }

    public class VehiculoResponse : VehiculoBase 
    {
        public Guid IdVehiculo { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }
    }
    public class VehiculoDetalle : VehiculoResponse

    {
        public bool RevisionValida { get; set; }

        public bool RegistroValido { get; set; }

    }
}
