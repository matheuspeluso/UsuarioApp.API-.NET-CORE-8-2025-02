using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UsuarioApp.Domain.Entities;

namespace UsuarioApp.Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator() {
        
            RuleFor(u=> u.Nome)
                .NotEmpty()
                .WithMessage("O campo Nome do usuário não pode ser vazio")
                .Length(8,150)
                .WithMessage("O nome do usuário deve ter de 8 a 150 caracteres");

            RuleFor(u=>u.Email)
                .NotEmpty()
                .WithMessage("O campo Email do usuário não pode ser vazio")
                .EmailAddress()
                .WithMessage("O email informado não é válido");

            RuleFor(u => u.Senha)
                .NotEmpty()
                .WithMessage("O campo Senha do usuário não pode ser vazio")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])
                        (?=.*\d)(?=.*[\W_]).{8,}$")
                .WithMessage("A senha deve ter pelo menos 1 letra minúscula, 1 letra maiúscula, 1 número e 1 caractere especial e no minimo 8 caracteres");

        }
    }
}
