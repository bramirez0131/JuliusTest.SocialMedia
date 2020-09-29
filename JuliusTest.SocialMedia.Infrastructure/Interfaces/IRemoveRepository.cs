using System.Collections.Generic;

namespace JuliusTest.SocialMedia.Infrastructure.Interfaces
{
	/// <summary>
	/// Interface IRemoveRepository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRemoveRepository<in T> where T : class
	{
		/// <summary>
		/// Remove as logic level
		/// </summary>
		/// <param name="t">The t.</param>
		void Remove(T t);

		/// <summary>
		/// Removes the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		/// Remove collection as logic level
		void Remove(IEnumerable<T> t);
	}
}
