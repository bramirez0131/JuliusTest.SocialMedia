using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;

using Microsoft.Extensions.Options;

using JuliusTest.SocialMedia.Application.Abstract;
using JuliusTest.SocialMedia.Infrastructure.Options;

namespace JuliusTest.SocialMedia.Application.Implements
{
	/// <summary>
	/// Class PasswordService.
	/// Implements the <see cref="IContrasenaService" />
	/// Implements the <see cref="Abstract.IContrasenaService" />
	/// </summary>
	/// <seealso cref="Abstract.IContrasenaService" />
	/// <seealso cref="IContrasenaService" />
	[ExcludeFromCodeCoverage]
	public class ContrasenaService : IContrasenaService
	{
		/// <summary>
		/// The options
		/// </summary>
		private readonly ContrasenaOpcion _contrasenaOpcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="ContrasenaService" /> class.
		/// </summary>
		/// <param name="contrasenaOpcion">The options.</param>
		public ContrasenaService(IOptions<ContrasenaOpcion> contrasenaOpcion)
		{
			_contrasenaOpcion = contrasenaOpcion.Value;
		}

		public bool Check(string hash, string password)
		{
			var parts = hash.Split('.');
			if (parts.Length != 3)
			{
				throw new FormatException("Unexpected hash format");
			}

			var iterations = Convert.ToInt32(parts[0]);
			var salt = Convert.FromBase64String(parts[1]);
			var key = Convert.FromBase64String(parts[2]);

			using var algorithm = new Rfc2898DeriveBytes(
				password,
				salt,
				iterations
				);
			var keyToCheck = algorithm.GetBytes(_contrasenaOpcion.KeySize);
			return keyToCheck.SequenceEqual(key);
		}

		public string Hash(string password)
		{
			using var algorithm = new Rfc2898DeriveBytes(
				password,
				_contrasenaOpcion.SaltSize,
				_contrasenaOpcion.Iterations
				);
			var key = Convert.ToBase64String(algorithm.GetBytes(_contrasenaOpcion.KeySize));
			var salt = Convert.ToBase64String(algorithm.Salt);

			return $"{_contrasenaOpcion.Iterations}.{salt}.{key}";
		}
	}
}
