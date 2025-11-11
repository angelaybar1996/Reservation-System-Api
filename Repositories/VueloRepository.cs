using reservas_api.Contracts;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using reservas_api.Entities;

namespace reservas_api.Repositories
{
    public class VueloRepository:IVueloRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string cadenaSql;

        public VueloRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            cadenaSql = _configuration.GetConnectionString("CadenaSQL")!;
        }

        public async Task<List<Vuelo>> GetVuelos(int id)
        {
            string query = "sp_ListarVuelosPorAerolinea";
            var parametros = new DynamicParameters();
            parametros.Add("@AerolineaId", id, DbType.Int32);
            using (var con = new SqlConnection(cadenaSql))
            {
                var vuelos = await con.QueryAsync<Vuelo>(query, parametros, commandType: CommandType.StoredProcedure);
                return vuelos.ToList();
            }
        }

        public async Task CancelarVuelo(int id)
        {
            string query = "sp_CancelarVuelo";
            var parametros = new DynamicParameters();
            parametros.Add("@VueloId", id, DbType.Int32);

            using (var con = new SqlConnection(cadenaSql))
            {
                await con.ExecuteAsync(query, parametros, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
