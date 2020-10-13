using Microsoft.EntityFrameworkCore.Query;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Infrastructure.Interfaces
{
	/// <summary>
	/// Interface IReadRepository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IReadRepository<T> where T : class
	{
		/// <summary>
		/// Gets all.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="take">The take.</param>
		/// <param name="include">The include.</param>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		IEnumerable<T> GetAll(
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			int? take = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

		/// <summary>
		/// Gets all asynchronous.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="take">The take.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
		Task<IEnumerable<T>> GetAllAsync(
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			int? take = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

		/// <summary>
		/// Singles the specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>T.</returns>
		T Single(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

		/// <summary>
		/// Singles the asynchronous.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;T&gt;.</returns>
		Task<T> SingleAsync(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

		/// <summary>
		/// Singles the or default.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>T.</returns>
		T SingleOrDefault(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

		/// <summary>
		/// Singles the or default asynchronous.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;T&gt;.</returns>
		Task<T> SingleOrDefaultAsync(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

		/// <summary>
		/// Firsts the specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="include">The include.</param>
		/// <returns>T.</returns>
		T First(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

		/// <summary>
		/// Firsts the asynchronous.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;T&gt;.</returns>
		Task<T> FirstAsync(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

		/// <summary>
		/// Firsts the or default.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="include">The include.</param>
		/// <returns>T.</returns>
		T FirstOrDefault(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

		/// <summary>
		/// Firsts the or default asynchronous.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;T&gt;.</returns>
		Task<T> FirstOrDefaultAsync(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

		// Extras
		/// <summary>
		/// Counts the asynchronous.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>Task&lt;System.Int32&gt;.</returns>
		Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
		/// <summary>
		/// Counts the specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>System.Int32.</returns>
		int Count(Expression<Func<T, bool>> predicate = null);

		/// <summary>
		/// Sums the asynchronous.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>Task&lt;System.Nullable&lt;System.Decimal&gt;&gt;.</returns>
		Task<decimal?> SumAsync(Expression<Func<T, bool>> predicate = null);
		/// <summary>
		/// Sums the specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>System.Nullable&lt;System.Decimal&gt;.</returns>
		decimal? Sum(Expression<Func<T, bool>> predicate = null);
	}
}
