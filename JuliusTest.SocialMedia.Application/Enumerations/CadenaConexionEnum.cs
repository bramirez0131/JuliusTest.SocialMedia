using System;
using System.Collections.Generic;
using System.Text;

namespace JuliusTest.SocialMedia.Application.Enumerations
{
	public class CadenaConexionEnum : Enumeration
	{
		/// <summary>
		/// The sm
		/// </summary>
		private static CadenaConexionEnum _sm = new CadenaConexionEnum(1, "ConnectionStrings:Sm");

		/// <summary>
		/// Gets the Sm.
		/// </summary>
		/// <value>The Sm.</value>
		public static CadenaConexionEnum Sm { get => _sm; }

		/// <summary>
		/// Initializes a new instance of the <see cref="CadenaConexionEnum" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		public CadenaConexionEnum(int id, string name) : base(id, name)
		{
		}
	}
}
