using System.Diagnostics.CodeAnalysis;

namespace JuliusTest.SocialMedia.Domain.Entities
{
	/// <summary>
	/// Class BaseEntity.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public abstract class BaseEntity
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public int Id { get; set; }
	}
}
