namespace JuliusTest.SocialMedia.Application.Enumerations
{
	/// <summary>
	/// Class NumerosEnum.
	/// Implements the <see cref="JuliusTest.SocialMedia.Application.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="JuliusTest.SocialMedia.Application.Enumerations.Enumeration" />
	public class NumerosEnum : Enumeration
	{
		/// <summary>
		/// The cero
		/// </summary>
		private readonly static NumerosEnum _cero = new NumerosEnum(0, "Cero");

		/// <summary>
		/// The uno
		/// </summary>
		private readonly static NumerosEnum _uno = new NumerosEnum(1, "Uno");

		/// <summary>
		/// The dos
		/// </summary>
		private readonly static NumerosEnum _dos = new NumerosEnum(2, "Dos");

		/// <summary>
		/// The tres
		/// </summary>
		private readonly static NumerosEnum _tres = new NumerosEnum(3, "Tres");

		/// <summary>
		/// The menos uno
		/// </summary>
		private readonly static NumerosEnum _menosUno = new NumerosEnum(-1, "Menos Uno");

		/// <summary>
		/// Gets the cero.
		/// </summary>
		/// <value>The cero.</value>
		public static NumerosEnum Cero { get => _cero; }

		/// <summary>
		/// Gets the uno.
		/// </summary>
		/// <value>The uno.</value>
		public static NumerosEnum Uno { get => _uno; }

		/// <summary>
		/// Gets the dos.
		/// </summary>
		/// <value>The dos.</value>
		public static NumerosEnum Dos { get => _dos; }

		/// <summary>
		/// Gets the tres.
		/// </summary>
		/// <value>The tres.</value>
		public static NumerosEnum Tres { get => _tres; }

		/// <summary>
		/// Gets the menos uno.
		/// </summary>
		/// <value>The menos uno.</value>
		public static NumerosEnum MenosUno { get => _menosUno; }

		/// <summary>
		/// Initializes a new instance of the <see cref="NumerosEnum" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		public NumerosEnum(int id, string name) : base(id, name)
		{
		}
	}
}
