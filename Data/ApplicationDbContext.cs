using Npgsql;

namespace WebAPI.Data
{
    public class ApplicationDbContext
    {
        private readonly string _connectionString ="Host=localhost;Port=5432;Database=mini_shop;User Id=postgres;Password=postgres;";
        public NpgsqlConnection Connection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
