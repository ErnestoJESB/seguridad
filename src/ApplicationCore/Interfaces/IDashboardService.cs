using ApplicationCore.DTOs;
using ApplicationCore.DTOs.Logs;
using ApplicationCore.DTOs.Cliente;
using ApplicationCore.Wrappers;

namespace ApplicationCore.Interfaces
{
    public interface IDashboardService
    {
        Task<Response<object>> GetData();
        Task<Response<string>> GetIp();
        Task<Response<int>> CreateLog(LogsDto resquest);
        Task<Response<int>> ActualizarCliente(ClienteDto request);
        Task<Response<object>> GetDataPaginate();
    }
}
