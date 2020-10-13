using System.Collections.Generic;
using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Infrastructure.Interfaces
{
	/// <summary>
	/// Interface ICreateRepository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ICreateRepository<in T> where T : class
	{
		/// <summary>
		/// Adds the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Add(T t);
		/// <summary>
		/// Adds the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Add(IEnumerable<T> t);

		/// <summary>
		/// Adds the asynchronous.
		/// </summary>
		/// <param name="t">The t.</param>
		/// <returns>Task.</returns>
		Task AddAsync(T t);
		/// <summary>
		/// Adds the asynchronous.
		/// </summary>
		/// <param name="t">The t.</param>
		/// <returns>Task.</returns>
		Task AddAsync(IEnumerable<T> t);
	}
}
