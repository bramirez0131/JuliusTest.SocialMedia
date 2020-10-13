using FluentValidation;
using JuliusTest.SocialMedia.Domain.DTO;

namespace JuliusTest.SocialMedia.Api.Validators
{
	/// <summary>
	/// Class SeguridadValidator.
	/// </summary>
	/// <seealso  />
	public class UsuarioValidator : AbstractValidator<SeguridadDto>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UsuarioValidator" /> class.
		/// </summary>
		public UsuarioValidator()
		{
			RuleFor(s => s.Usuario)
			  .NotEmpty()
			  .NotNull()
			  .WithMessage("{PropertyName} requerido")
			  .Length(12, 50);

			RuleFor(s => s.Contrasena)
				.NotEmpty()
				.NotNull()
				.WithMessage("{PropertyName}  requerida")
				.Length(10, 50);
		}
	}
}
