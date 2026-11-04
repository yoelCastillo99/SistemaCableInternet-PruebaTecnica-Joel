
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Interfaces
{
    public interface IContratoRepository
    {
        // Consultar todos los contratos y aplicar filtros
        Task<List<Contrato>> ListarAsync(
            string? buscar = null,
            string? estado = null
        );

        // Consultar un contrato por su identificador
        Task<Contrato?> ObtenerPorIdAsync(int contratoId);

        // Registrar un nuevo contrato
        Task<int> InsertarAsync(Contrato contrato);

        // Actualizar un contrato existente
        Task ActualizarAsync(Contrato contrato);

        // Cambiar el estado del contrato
        Task CambiarEstadoAsync(int contratoId, string estado);
    }
}

