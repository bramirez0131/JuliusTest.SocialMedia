namespace JuliusTest.SocialMedia.Infrastructure.Options
{
	/// <summary>
	/// Class PasswordOptions.
	/// </summary>
	public class ContrasenaOpcion
	{
		/// <summary>
		/// Gets or sets the size of the salt.
		/// </summary>
		/// <value>The size of the salt.</value>
		public int SaltSize { get; set; }

		/// <summary>
		/// Gets or sets the size of the key.
		/// </summary>
		/// <value>The size of the key.</value>
		public int KeySize { get; set; }

		/// <summary>
		/// Gets or sets the iterations.
		/// </summary>
		/// <value>The iterations.</value>
		public int Iterations { get; set; }
	}
}
