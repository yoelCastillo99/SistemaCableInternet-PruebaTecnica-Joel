using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaCableInternet.BLL.Models
{
    public class Zona
    {
        public int ZonaId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public bool Activo { get; set; }
    }
}

