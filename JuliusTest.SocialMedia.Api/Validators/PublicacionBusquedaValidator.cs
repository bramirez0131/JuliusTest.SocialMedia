using FluentValidation;

using JuliusTest.SocialMedia.Application.DTO;
using JuliusTest.SocialMedia.Application.Enumerations;

namespace JuliusTest.SocialMedia.Api.Validators
{
	/// <summary>
	/// Class PublicacionBusquedaValidator.
	/// Implements the  />
	/// </summary>
	/// <seealso  />
	public class PublicacionBusquedaValidator : AbstractValidator<PublicacionBusquedaDto>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PublicacionBusquedaValidator" /> class.
		/// </summary>
		public PublicacionBusquedaValidator()
		{
			RuleFor(s => s.IdUsuario)
				.NotNull()
				.NotEmpty()
				.GreaterThan(NumerosEnum.Cero.Id)
				.WithMessage("{PropertyName} es requerido y su valor [{PropertyValue}] debe ser mayor 0.");
			RuleFor(s => s.Busqueda)
				.NotNull()
				.NotEmpty()
				.WithMessage("{PropertyName} es requerido.");
		}
	}
}
