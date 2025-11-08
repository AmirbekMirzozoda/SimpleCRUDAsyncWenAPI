using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Responses;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/Companies/")]
    public class CompanyController(ICompanyService companyService) : ControllerBase
    {
        [HttpGet]
        public async Task<List<Company>> GetCompaniesAsync()
        {
            return await companyService.GetCompaniesAsync();
        }
        
        [HttpGet("{companyId:int}")]
        public async Task<Response<Company?>> GetCompanyByIdAsync(int companyId)
        {
            return await companyService.GetCompanyByIdAsync(companyId);
        }
        [HttpPost]
        public async Task<Response<string>> AddAsync(Company model)
        {
            return await companyService.AddAsync(model);
        }
        [HttpPut]
        public async Task<Response<string>> UpdateAsync(Company model)
        {
            return await companyService.UpdateAsync(model);
        }
        [HttpDelete("{companyId:int}")]
        public async Task<Response<string>> DeleteAsync(int companyId)
        {
            return await companyService.DeleteAsync(companyId);
        }
    }
}
