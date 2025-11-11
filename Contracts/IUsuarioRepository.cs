using Microsoft.Identity.Client;
using reservas_api.Entities;

namespace reservas_api.Contracts
{
    public interface IUsuarioRepository
    {
       Task<Usuario> GetUsuario(int id);
    }
}
