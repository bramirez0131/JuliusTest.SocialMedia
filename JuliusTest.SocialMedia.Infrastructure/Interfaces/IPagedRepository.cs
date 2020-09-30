using JuliusTest.SocialMedia.Infrastructure.Pages;

using Microsoft.EntityFrameworkCore.Query;

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface IPagedRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedRepository<T> where T : class
	{
		/// <summary>
		/// Gets the paged asynchronous.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <param name="take">The take.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;PagedList&lt;T&gt;&gt;.</returns>
		Task<PagedList<T>> GetPagedAsync(
			int page,
			int take,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		);

		/// <summary>
		/// Gets the paged.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <param name="take">The take.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>PagedList&lt;T&gt;.</returns>
		PagedList<T> GetPaged(
			int page,
			int take,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		);
	}
}
