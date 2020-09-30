using System;
using System.Collections.Generic;
using System.Text;

namespace JuliusTest.SocialMedia.Application.Enumerations
{
	/// <summary>
	/// Class ContrasenaOpcionEnum.
	/// Implements the <see cref="JuliusTest.SocialMedia.Application.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="JuliusTest.SocialMedia.Application.Enumerations.Enumeration" />
	public class ContrasenaOpcionEnum : Enumeration
	{
		/// <summary>
		/// The iteracion
		/// </summary>
		private readonly static ContrasenaOpcionEnum iteracion = new ContrasenaOpcionEnum(0, "Iteracion");
		/// <summary>
		/// The salto
		/// </summary>
		private readonly static ContrasenaOpcionEnum salto = new ContrasenaOpcionEnum(1, "Salto");
		/// <summary>
		/// The llave
		/// </summary>
		private readonly static ContrasenaOpcionEnum llave = new ContrasenaOpcionEnum(2, "Llave");

		/// <summary>
		/// Gets the iteracion.
		/// </summary>
		/// <value>The iteracion.</value>
		public static ContrasenaOpcionEnum Iteracion { get => iteracion; }
		/// <summary>
		/// Gets the salto.
		/// </summary>
		/// <value>The salto.</value>
		public static ContrasenaOpcionEnum Salto { get => salto; }
		/// <summary>
		/// Gets the llave.
		/// </summary>
		/// <value>The llave.</value>
		public static ContrasenaOpcionEnum Llave { get => llave; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ContrasenaOpcionEnum"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		public ContrasenaOpcionEnum(int id, string name) : base(id, name)
		{
		}
	}
}
