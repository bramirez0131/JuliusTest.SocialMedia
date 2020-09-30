using FluentValidation;

using JuliusTest.SocialMedia.Application.DTO;
using JuliusTest.SocialMedia.Application.Enumerations;

namespace JuliusTest.SocialMedia.Api.Validators
{
	/// <summary>
	/// Class UsuarioCrearValidator.
	/// Implements the  />
	/// </summary>
	/// <seealso  />
	public class PublicacionUsuarioValidator : AbstractValidator<PublicacionUsuarioDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioCrearValidator" /> class.
        /// </summary>
        public PublicacionUsuarioValidator()
        {
			RuleFor(s => s.IdUsuario)
				.NotNull()
				.NotEmpty()
				.GreaterThan(NumerosEnum.Cero.Id)
				.WithMessage("{PropertyName} es requerido y su valor [{PropertyValue}] debe ser mayor 0.");
		}
	}
}
