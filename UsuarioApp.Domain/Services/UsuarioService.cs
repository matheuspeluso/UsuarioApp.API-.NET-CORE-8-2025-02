using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Dtos.Requests;
using UsuarioApp.Domain.Dtos.Responses;
using UsuarioApp.Domain.Entities;
using UsuarioApp.Domain.Helpers;
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
            var validator = new UsuarioValidator(_usuarioRepository);
            var result = validator.Validate(usuario);

            //verficar se ocorreram erros de validações
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            //criptografar senha do usuario
            usuario.Senha = CriptHelper.GetSHA256(usuario.Senha);

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


        public AutenticarUsuarioResponse Autenticar(AutenticarUsuarioRequest request)
        {
            var usuario = _usuarioRepository.Get(request.Email, CriptHelper.GetSHA256(request.Senha));

            if (usuario == null)
                throw new ApplicationException("Email ou senha inválidos");

            

            return new AutenticarUsuarioResponse(
                 usuario.Id,
                 usuario.Nome, 
                 usuario.Email,
                 usuario.Perfil.Nome,
                 DateTime.Now,
                 JwtTokenHelper.GenerateToken(usuario.Email, usuario.Perfil.Nome)
           );
        }

    }

    
}
