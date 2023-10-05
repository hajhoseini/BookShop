using Core.Commands.UserCommands;
using FluentValidation;

namespace Infrastructure.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.Name)
                    .NotEmpty()
                    .WithMessage("لطفا نام را وارد کنید");            
        }       
    }
}
