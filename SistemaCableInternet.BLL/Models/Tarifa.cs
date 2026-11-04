using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaCableInternet.BLL.Models
{
    public class Tarifa
    {
        public int TarifaId { get; set; }

        public int PlanId { get; set; }

        public int ZonaId { get; set; }

        public decimal PrecioMensual { get; set; }

        public DateTime VigenciaDesde { get; set; }

        public DateTime? VigenciaHasta { get; set; }

        public string? NombrePlan { get; set; }

        public string? NombreZona { get; set; }
    }
}

