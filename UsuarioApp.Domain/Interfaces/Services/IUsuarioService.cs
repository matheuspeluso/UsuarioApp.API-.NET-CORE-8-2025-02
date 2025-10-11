using UsuarioApp.Domain.Dtos.Responses;
using UsuariosApp.Domain.Dtos.Requests;

namespace UsuarioApp.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        CriarContaResponse Criar(CriarContaRequest request);
    }
}
