using reservas_api.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace reservas_api.Services
{
    public class VueloService
    {
        private readonly IConfiguration _configuration;
        private readonly string cadenaSql;

        public VueloService(IConfiguration configuration)
        {
            _configuration = configuration;
            cadenaSql = _configuration.GetConnectionString("CadenaSQL")!;
        }

        public async Task <Vuelo> GetVuelos(int id)
        {
            string query = "sp_ListarVuelosPorAerolinea";
            var parametros = new DynamicParameters();
            parametros.Add("@AerolineaId", id, DbType.Int32);

            using (var con = new SqlConnection(cadenaSql))
            {
                var vuelos = await con.QueryFirstOrDefaultAsync<Vuelo>(query,parametros, commandType: CommandType.StoredProcedure);
                return vuelos;
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
