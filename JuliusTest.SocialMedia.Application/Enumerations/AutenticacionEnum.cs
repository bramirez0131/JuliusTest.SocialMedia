using System;
using System.Collections.Generic;
using System.Text;

namespace JuliusTest.SocialMedia.Application.Enumerations
{
	/// <summary>
	/// Class AutenticacionEnum.
	/// Implements the <see cref="JuliusTest.SocialMedia.Application.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="JuliusTest.SocialMedia.Application.Enumerations.Enumeration" />
	public class AutenticacionEnum : Enumeration
	{
		/// <summary>
		/// The editor
		/// </summary>
		private static readonly AutenticacionEnum _editor = new AutenticacionEnum(0, "Authentication:Issuer");

		/// <summary>
		/// The llave secreta
		/// </summary>
		private static readonly AutenticacionEnum _llaveSecreta = new AutenticacionEnum(1, "Authentication:SecretKey");

		/// <summary>
		/// The audiencia
		/// </summary>
		private static readonly AutenticacionEnum _audiencia = new AutenticacionEnum(2, "Authentication:Audience");

		/// <summary>
		/// The minutos token
		/// </summary>
		private static readonly AutenticacionEnum _minutosToken = new AutenticacionEnum(3, "Authentication:MinutosToken");

		/// <summary>
		/// The idUsuario
		/// </summary>
		private static readonly AutenticacionEnum _idUsuario = new AutenticacionEnum(4, "IdUsuario");

		/// <summary>
		/// Gets the editor.
		/// </summary>
		/// <value>The editor.</value>
		public static AutenticacionEnum Editor { get => _editor; }

		/// <summary>
		/// Gets the llave secreta.
		/// </summary>
		/// <value>The llave secreta.</value>
		public static AutenticacionEnum LlaveSecreta { get => _llaveSecreta; }

		/// <summary>
		/// Gets the audiencia.
		/// </summary>
		/// <value>The audiencia.</value>
		public static AutenticacionEnum Audiencia { get => _audiencia; }

		/// <summary>
		/// Gets the minutos token.
		/// </summary>
		/// <value>The minutos token.</value>
		public static AutenticacionEnum MinutosToken { get => _minutosToken; }

		/// <summary>
		/// Gets the usuario.
		/// </summary>
		/// <value>The usuario.</value>
		public static AutenticacionEnum IdUsuario { get => _idUsuario; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AutenticacionEnum" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		public AutenticacionEnum(int id, string name) : base(id, name)
		{
		}
	}
}
