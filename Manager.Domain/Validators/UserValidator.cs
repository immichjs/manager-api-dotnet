using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(50)
                .WithMessage("O nome pode ter no máximo 50 caracteres");

            RuleFor(user => user.Password)
               .NotEmpty()
               .WithMessage("A senha não pode ser vazio.")

               .NotNull()
               .WithMessage("A senha não pode ser nulo.")

               .MinimumLength(6)
               .WithMessage("A senha deve ter no mínimo 6 caracteres.")

               .MaximumLength(30)
               .WithMessage("A senha pode ter no máximo 30 caracteres");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("O email não pode ser vazio")

                .NotNull()
                .WithMessage("O email não pode ser nulo.")

                .MaximumLength(180)
                .WithMessage("O email pode ter no máximo 180 caracteres.")

                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("O email informado não é válido.");

        }
    }
}
