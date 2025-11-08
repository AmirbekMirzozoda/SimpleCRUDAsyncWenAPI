using WebAPI.Entities;
using WebAPI.Responses;

namespace WebAPI.Services
{
    public interface ICompanyService
    {
        Task<List<Company>> GetCompaniesAsync();
        Task<Response<Company?>> GetCompanyByIdAsync(int companyId);
        Task<Response<string>> AddAsync(Company model);
        Task<Response<string>> UpdateAsync(Company model);
        Task<Response<string>> DeleteAsync(int companyId);
    }
}