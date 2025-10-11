namespace UsuarioApp.Domain.Dtos.Responses
{
    public record CriarContaResponse (Guid Id, string Nome, string Email, string Perfil, DateTime DataCriacao)
    {

    }
}
