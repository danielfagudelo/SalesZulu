using Sales.Shared.Responces;

namespace Sales.API.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
    }
}