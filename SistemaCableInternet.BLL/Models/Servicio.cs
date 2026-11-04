using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCableInternet.BLL.Models
{
    public class Servicio
    {
        public int ServicioId { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public bool Activo { get; set; }
    }
}
