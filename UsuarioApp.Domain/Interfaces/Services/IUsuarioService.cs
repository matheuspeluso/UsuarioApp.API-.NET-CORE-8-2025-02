using UsuarioApp.Domain.Dtos.Requests;
using UsuarioApp.Domain.Dtos.Responses;
using UsuariosApp.Domain.Dtos.Requests;

namespace UsuarioApp.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        CriarContaResponse Criar(CriarContaRequest request);
        AutenticarUsuarioResponse Autenticar(AutenticarUsuarioRequest request);
    }
}
