using System;
using System.Collections.Generic;

namespace REGISTRAR.Models
{
    public partial class Persona
    {
        public string Documentoidentidad { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateTime Fechadenacimiento { get; set; }
        public string? Telefono1 { get; set; }
        public string? Telefono2 { get; set; }
        public string? Correoelectronico { get; set; }
        public string? Correoelectronico2 { get; set; }
        public string? Direccionfisica1 { get; set; }
        public string? Direccionfisica2 { get; set; }
    }
}
