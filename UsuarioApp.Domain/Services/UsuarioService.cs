using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using UsuarioApp.Domain.Dtos.Responses;
using UsuarioApp.Domain.Entities;
using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Domain.Interfaces.Services;
using UsuarioApp.Domain.Validators;
using UsuariosApp.Domain.Dtos.Requests;

namespace UsuarioApp.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPerfilRepository _perfilRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository)
        {
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
        }

        public CriarContaResponse Criar(CriarContaRequest request)
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha
            };

            //validar os dados do usuario
            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);

            //verficar se ocorreram erros de validações
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var perfil = _perfilRepository.Get("Usuario");
            if(perfil != null)
                usuario.PerfilId = perfil.Id;

            
           _usuarioRepository.Add(usuario);

            //Retornar os dados do usuário criado
            return new CriarContaResponse(
                usuario.Id,
                usuario.Nome,
                usuario.Email,
                perfil != null ? perfil.Nome : string.Empty,
                DateTime.Now
             );

        }
    }

    
}
