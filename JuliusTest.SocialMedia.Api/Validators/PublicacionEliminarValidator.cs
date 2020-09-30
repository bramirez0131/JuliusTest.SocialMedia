using FluentValidation;
using JuliusTest.SocialMedia.Application.DTO;
using JuliusTest.SocialMedia.Application.Enumerations;

namespace JuliusTest.SocialMedia.Api.Validators
{
	/// <summary>
	/// Class PublicacionEliminarValidator.
	/// Implements the  />
	/// </summary>
	/// <seealso  />
	public class PublicacionEliminarValidator : AbstractValidator<PublicacionEliminarDto>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PublicacionEliminarValidator" /> class.
		/// </summary>
		public PublicacionEliminarValidator()
		{
			RuleFor(s => s.IdPublicacion)
				.NotNull()
				.NotEmpty()
				.GreaterThan(NumerosEnum.Cero.Id)
				.WithMessage("{PropertyName} es requerido y su valor [{PropertyValue}] debe ser mayor 0.");
		}
	}
}
