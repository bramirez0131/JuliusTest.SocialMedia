using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using JuliusTest.SocialMedia.Domain.Entities;

namespace JuliusTest.SocialMedia.Infrastructure.Interfaces
{
	/// <summary>
	/// Interface IGenericRepository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IGenericRepository<T> where T : BaseEntity
	{
		/// <summary>
		/// Finds the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>T.</returns>
		T Find(int id);

		/// <summary>
		/// Adds the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns>T.</returns>
		T Add(T entity);

		/// <summary>
		/// Deletes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Delete(T entity);

		/// <summary>
		/// Edits the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Edit(T entity);

		/// <summary>
		/// Adds the range.
		/// </summary>
		/// <param name="entities">The entities.</param>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		IEnumerable<T> AddRange(List<T> entities);

		/// <summary>
		/// Deletes the range.
		/// </summary>
		/// <param name="entities">The entities.</param>
		void DeleteRange(List<T> entities);

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		IEnumerable<T> GetAll();

		/// <summary>
		/// Finds the by.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

		/// <summary>
		/// Finds the by.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="includeProperties">The include properties.</param>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		IEnumerable<T> FindBy(
			Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>,
			IOrderedQueryable<T>> orderBy = null,
			string includeProperties = ""
		 );
	}
}
