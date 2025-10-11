using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UsuarioApp.Domain.Entities;

namespace UsuarioApp.Domain.Validators
{
    public class PerfilValidator : AbstractValidator<Perfil>
    {
       public PerfilValidator() {

            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("O campo Nome do perfil não pode ser vazio")
                .Length(6,25)
                .WithMessage("O nome do perfil deve ter de 6 a 25 caracteres");
        }
    }
}
