using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UsuarioApp.Domain.Entities;
using UsuarioApp.Domain.Interfaces.Repositories;

namespace UsuarioApp.Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator(IUsuarioRepository usuarioRepository)
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage("O nome do usuário é obrigatório.")
                .Length(8, 150)
                .WithMessage("O nome do usuário deve ter de 8 a 150 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("O email do usuário é obrigatório.")
                .EmailAddress()
                .WithMessage("O valor deve ter um endereço de email válido.")
                .Must(email => !usuarioRepository.Any(email))
                .WithMessage("O email informado ja foi cadastrado para outro usuário.");

            RuleFor(u => u.Senha)
                .NotEmpty()
                .WithMessage("A senha do usuário é obrigatória.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$")
                .WithMessage("A senha deve ter pelo menos 1 letra minúscula, 1 letra maiúscula, 1 número, 1 símbolo e no mínimo 8 caracteres.");

        }
    }
}
