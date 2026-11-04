using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaCableInternet.BLL.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Codigo { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public DateTime FechaAlta { get; set; }

        public string Direccion { get; set; } = string.Empty;

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public bool Activo { get; set; }
    }
}

