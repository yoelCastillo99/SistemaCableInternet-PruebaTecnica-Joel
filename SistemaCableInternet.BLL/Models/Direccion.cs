using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaCableInternet.BLL.Models
{
    public class Direccion
    {
        public int DireccionId { get; set; }

        public int ContratoId { get; set; }

        public int ZonaId { get; set; }

        public string DireccionTexto { get; set; } = string.Empty;

        public string? Zona { get; set; }

        public string? EstadoContrato { get; set; }
    }
}

