using System.Net;
using Dapper;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Responses;
using WebAPI.Responses;

namespace WebAPI.Services;

public class CompanyService(ApplicationDbContext dbContext) : ICompanyService
{
    public async Task<Response<string>> AddAsync(Company model)
    {
        try
        {
            using var context = dbContext.Connection();

            var query = "Insert into Companies(Name,Description) " +
                        "values(@Name,@Description)";

            var result = await context.ExecuteAsync(query,
                new
                {
                    model.Name,
                    model.Description
                });

            return result == 0
                ? new Response<string>(HttpStatusCode.InternalServerError, "Company data not added !")
                : new Response<string>(HttpStatusCode.OK, "Company data successfully added !");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public Response<string> Delete(int companyId)
    {
        try
        {
            using var context = dbContext.Connection();

            var query = "Delete from Companies " +
                        "where id = @Id";

            var result = context.Execute(query,
                new
                {
                    Id = companyId
                });

            return result == 0
                ? new Response<string>(HttpStatusCode.InternalServerError, "Company data not deleted !")
                : new Response<string>(HttpStatusCode.OK, "Company data successfully deleted !");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public async Task<List<Company>> GetCompaniesAsync()
    {
        using var context = dbContext.Connection();

        var query = "Select * from Companies";

        var companies = await context.QueryAsync<Company>(query);

        return companies.ToList();
    }

    public async Task<Response<Company?>> GetCompanyByIdAsync(int companyId)
    {
        try
        {
            await using var context = dbContext.Connection();

            var query = "Select * from Companies " +
                        "where id = @Id";

            var company = await context.QueryFirstOrDefaultAsync<Company>(query,
                new
                {
                    Id = companyId
                });

            return company == null
                ? new Response<Company?>(HttpStatusCode.NotFound, "Company not found !")
                : new Response<Company?>(HttpStatusCode.OK, "Company found !", company);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return new Response<Company?>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public async Task<Response<string>> UpdateAsync(Company model)
    {
        try
        {
            using var context = dbContext.Connection();

            var query = "Update Companies " +
                        "SET Name = @Name,Description = @Description " +
                        "WHERE id = @Id";

            var result = await context.ExecuteAsync(query, model);

            return result == 0
                ? new Response<string>(HttpStatusCode.InternalServerError, "Company data not updated !")
                : new Response<string>(HttpStatusCode.OK, "Company data successfully updated !");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public Task<Response<string>> DeleteAsync(int companyId)
    {
        throw new NotImplementedException();
    }
}