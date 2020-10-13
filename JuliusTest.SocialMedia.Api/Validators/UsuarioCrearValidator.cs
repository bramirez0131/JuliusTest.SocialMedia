using FluentValidation;
using JuliusTest.SocialMedia.Application.DTO;

namespace JuliusTest.SocialMedia.Api.Validators
{
	/// <summary>
	/// Class UsuarioCrearValidator.
	/// Implements the  />
	/// </summary>
	/// <seealso  />
	public class UsuarioCrearValidator : AbstractValidator<UsuarioCrearDto>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UsuarioCrearValidator" /> class.
		/// </summary>
		public UsuarioCrearValidator()
		{
			RuleFor(s => s.NombreUsuario)
				.NotEmpty()
				.NotNull()
				.WithMessage("{PropertyName}  requerido")
				.Length(7, 100);

			RuleFor(s => s.Contrasena)
				.NotEmpty()
				.NotNull()
				.WithMessage("{PropertyName}  requerida")
				.Length(7, 50);

			RuleFor(s => s.Email)
				.NotEmpty()
				.NotNull()
				.WithMessage("{PropertyName}  requerido")
				.EmailAddress()
				.WithMessage("Se requiere un e-mail válido");
		}
	}
}
