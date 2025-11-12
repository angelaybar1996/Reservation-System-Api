using Dapper;
using Microsoft.Data.SqlClient;
using reservas_api.Contracts;
using reservas_api.Entities;
using System.Data;


namespace reservas_api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string cadenaSql;

        public UsuarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            cadenaSql = _configuration.GetConnectionString("CadenaSQL")!;
        }
        public async Task<Usuario> GetUsuario(int id)
        {
            string query = "SELECT * FROM Usuario WHERE UsuarioId= @id";

            using (var con = new SqlConnection(cadenaSql))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@id", id, DbType.Int32);

                var usuario = await con.QueryFirstOrDefaultAsync<Usuario>(
                 query,parametros,commandType: CommandType.Text);

                return usuario;
            }
        }
    }
}
