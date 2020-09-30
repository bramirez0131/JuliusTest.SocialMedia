namespace JuliusTest.SocialMedia.Application.Abstract
{
	/// <summary>
	/// Interface IPasswordService
	/// </summary>
	public interface IContrasenaService
	{
		/// <summary>
		/// Hashes the specified password.
		/// </summary>
		/// <param name="password">The password.</param>
		/// <returns>System.String.</returns>
		string Hash(string password);

		/// <summary>
		/// Checks the specified hash.
		/// </summary>
		/// <param name="hash">The hash.</param>
		/// <param name="password">The password.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		bool Check(string hash, string password);
	}
}
