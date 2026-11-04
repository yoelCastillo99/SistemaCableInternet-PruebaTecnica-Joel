using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaCableInternet.BLL.Models
{
    public class ContratoServicio
    {
        public int ContratoServicioId { get; set; }

        public int ContratoId { get; set; }

        public int ClienteId { get; set; }

        public string? CodigoCliente { get; set; }

        public string? NombreCliente { get; set; }

        public int PlanId { get; set; }

        public string? NombrePlan { get; set; }

        public int ServicioId { get; set; }

        public string? Servicio { get; set; }

        public int DireccionId { get; set; }

        public string? Direccion { get; set; }

        public int ZonaId { get; set; }

        public string? Zona { get; set; }

        public int TarifaId { get; set; }

        public decimal PrecioMensual { get; set; }

        public decimal PrecioPactado { get; set; }

        public short? VelocidadActualMbps { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime? FechaBaja { get; set; }

        public string Estado { get; set; } = "Activo";
    }
}

