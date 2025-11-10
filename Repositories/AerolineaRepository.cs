using reservas_api.Contracts;
using reservas_api.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace reservas_api.Repositories
{
    public class AerolineaRepository: IAerolineaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string cadenaSql;

        public AerolineaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            cadenaSql = _configuration.GetConnectionString("CadenaSQL")!;
        }

        public async Task<List<Aerolinea>> GetAerolineas()
        {
            string query = "sp_ListarAerolineas";
            using (var con = new SqlConnection(cadenaSql))
            {
                var lista = await con.QueryAsync<Aerolinea>(query, commandType: CommandType.StoredProcedure);
                return lista.ToList();
            }
        }
    }
}
