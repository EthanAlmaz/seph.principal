using FluentValidation;

namespace Seph.Principal.Application.Features.Instituciones.Commands.CreateInstitucion
{
    public sealed class CreateInstitucionCommandValidator
    : AbstractValidator<CreateInstitucionCommand>
    {
        public CreateInstitucionCommandValidator()
        {
            RuleFor(x => x.StrValor)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.StrDescripcion)
                .MaximumLength(450);
        }
    }
}
