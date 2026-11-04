using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCableInternet.BLL.Models
{
    public class Plan
    {
        public int PlanId { get; set; }

        public int ServicioId { get; set; }

        public string? Servicio { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public int? VelocidadMbps { get; set; }

        public int? Canales { get; set; }

        public bool Activo { get; set; }
    }
}
