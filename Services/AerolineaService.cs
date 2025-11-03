using reservas_api.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace reservas_api.Services
{
    public class AerolineaService
    {
        private readonly IConfiguration _configuration;
        private readonly string cadenaSql;

        public AerolineaService(IConfiguration configuration)
        {
            _configuration = configuration;
            cadenaSql = _configuration.GetConnectionString("CadenaSQL")!;
        }

        public async Task<List<Aerolinea>> GetAerolineas()
        {
            string query = "sp_ListarAerolineas";
            using ( var con=new SqlConnection(cadenaSql))
            {
                 var lista = await con.QueryAsync<Aerolinea>(query, commandType:CommandType.StoredProcedure);
                return lista.ToList();
            }
        }
    }
}
