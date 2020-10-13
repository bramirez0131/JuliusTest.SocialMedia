using FluentValidation;
using JuliusTest.SocialMedia.Application.DTO;
using JuliusTest.SocialMedia.Application.Enumerations;

namespace JuliusTest.SocialMedia.Api.Validators
{
	/// <summary>
	/// Class PublicacionCrearValidator.
	/// Implements the  />
	/// </summary>
	/// <seealso  />
	public class PublicacionCrearValidator : AbstractValidator<PublicacionCrearDto>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="UsuarioCrearValidator" /> class.
		/// </summary>
		public PublicacionCrearValidator()
		{
			RuleFor(s => s.IdUsuario)
				.NotNull()
				.NotEmpty()
				.GreaterThan(NumerosEnum.Cero.Id)
				.WithMessage("{PropertyName} es requerido y su valor [{PropertyValue}] debe ser mayor 0.");

			RuleFor(s => s.Titulo)
				.NotEmpty()
				.NotNull()
				.WithMessage("{PropertyName}  requerido");

		}
	}
}
