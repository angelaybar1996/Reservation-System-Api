using reservas_api.Contracts;
using reservas_api.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace reservas_api.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string cadenaSql;

        public ReservaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            cadenaSql = configuration.GetConnectionString("CadenaSQL")!;
        }

        public async Task<List<Reserva>> GetReservas(int id)
        {
            string query = "sp_ListarReservasPorUsuario";
            var parametros = new DynamicParameters();
            parametros.Add("@UsuarioId", id, DbType.Int32);
            using (var con = new SqlConnection(cadenaSql))
            {
                var reservas = await con.QueryAsync<Reserva>(query,parametros, commandType: CommandType.StoredProcedure);
                return reservas.ToList();
            }
        }

        public async Task<string> CrearReserva(Reserva reserva)
        {
            string query = "sp_CrearReserva";
            var parametros = new DynamicParameters();
            parametros.Add("@UsuarioId", reserva.UsuarioId, DbType.Int32);
            parametros.Add("@VueloId", reserva.VueloId, DbType.Int32);
            parametros.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            using (var con = new SqlConnection(cadenaSql))
            {
                await con.ExecuteAsync(query, parametros, commandType: CommandType.StoredProcedure);
                return parametros.Get<string>("@Mensaje");
            }
        }

        public async Task BajarReserva(int idReserva, int idUsuario)
        {
            string query = "sp_CancelarReserva";
            var parametros = new DynamicParameters();
            parametros.Add("@ReservaId", idReserva, DbType.Int32);
            parametros.Add("@UsuarioId", idUsuario, DbType.Int32);
            using (var con = new SqlConnection(cadenaSql))
            {
                await con.ExecuteAsync(query, parametros, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
