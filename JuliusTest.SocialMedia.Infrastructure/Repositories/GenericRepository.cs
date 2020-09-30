using JuliusTest.SocialMedia.Domain.Entities;
using JuliusTest.SocialMedia.Infrastructure.DataAccessEntityFrameWork;
using JuliusTest.SocialMedia.Infrastructure.Pages;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Infrastructure.Repositories
{
    /// <summary>
    /// Class GenericRepository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ExcludeFromCodeCoverage]
	public class GenericRepository<T> where T : BaseEntity
	{
		/// <summary>
		/// The context
		/// </summary>
		private readonly SmContext _context;

		/// <summary>
		/// The entities
		/// </summary>
		protected readonly DbSet<T> _entities;

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericRepository{T}" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public GenericRepository(SmContext context)
		{
			_context = context;
			_entities = context.Set<T>();
		}

		/// <summary>
		/// Prepares the query.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="take">The take.</param>
		/// <returns>IQueryable&lt;T&gt;.</returns>
		protected IQueryable<T> PrepareQuery(
			IQueryable<T> query,
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			int? take = null
		)
		{
			if (include != null)
				query = include(query);

			if (predicate != null)
				query = query.Where(predicate);

			if (orderBy != null)
				query = orderBy(query);

			if (take.HasValue)
				query = query.Take(Convert.ToInt32(take));

			return query;
		}

		#region Extras

		/// <summary>
		/// sum as an asynchronous operation.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>Task&lt;System.Nullable&lt;System.Decimal&gt;&gt;.</returns>
		public virtual async Task<decimal?> SumAsync(
			Expression<Func<T, bool>> predicate = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate);

			return await ((IQueryable<decimal?>)query).SumAsync();
		}

		/// <summary>
		/// Sums the specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>System.Nullable&lt;System.Decimal&gt;.</returns>
		public virtual decimal? Sum(
			Expression<Func<T, bool>> predicate = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate);

			return ((IQueryable<decimal?>)query).Sum();
		}

		/// <summary>
		/// count as an asynchronous operation.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>Task&lt;System.Int32&gt;.</returns>
		public virtual async Task<int> CountAsync(
			Expression<Func<T, bool>> predicate = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate);

			return await query.CountAsync();
		}

		/// <summary>
		/// Counts the specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>System.Int32.</returns>
		public virtual int Count(
			Expression<Func<T, bool>> predicate = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate);

			return query.Count();
		}

		#endregion Extras

		#region Get All

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="take">The take.</param>
		/// <param name="include">The include.</param>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		public virtual IEnumerable<T> GetAll(
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			int? take = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate, include, orderBy, take);

			return query.ToList();
		}

		/// <summary>
		/// get all as an asynchronous operation.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="take">The take.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
		public virtual async Task<IEnumerable<T>> GetAllAsync(
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			int? take = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate, include, orderBy, take);

			return await query.ToListAsync();
		}

		#endregion Get All

		#region Paged

		/// <summary>
		/// get paged as an asynchronous operation.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <param name="take">The take.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;PagedList&lt;T&gt;&gt;.</returns>
		public virtual async Task<PagedList<T>> GetPagedAsync(
			int page,
			int take,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate, include, orderBy);
			var totalCount = await query.CountAsync();
			var items = await query.Skip(page).Take(take).ToListAsync();
			var result = PagedList<T>.Create(items, totalCount, page, take);

			return result;
		}

		/// <summary>
		/// Gets the paged.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <param name="take">The take.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>PagedList&lt;T&gt;.</returns>
		public virtual PagedList<T> GetPaged(
			int page,
			int take,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate, include, orderBy);
			var totalCount = query.Count();
			var items = query.Skip(page).Take(take).ToList();
			var result = PagedList<T>.Create(items, totalCount, page, take);

			return result;
		}

		#endregion Paged

		#region First

		/// <summary>
		/// Firsts the specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="include">The include.</param>
		/// <returns>T.</returns>
		public virtual T First(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate, include, orderBy);

			return query.First();
		}

		/// <summary>
		/// first as an asynchronous operation.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;T&gt;.</returns>
		public virtual async Task<T> FirstAsync(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate, include, orderBy);

			return await query.FirstAsync();
		}

		/// <summary>
		/// Firsts the or default.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="include">The include.</param>
		/// <returns>T.</returns>
		public virtual T FirstOrDefault(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate, include, orderBy);

			return query.FirstOrDefault();
		}

		/// <summary>
		/// first or default as an asynchronous operation.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;T&gt;.</returns>
		public virtual async Task<T> FirstOrDefaultAsync(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate, include, orderBy);

			return await query.FirstOrDefaultAsync();
		}

		#endregion First

		#region Single

		/// <summary>
		/// Singles the specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>T.</returns>
		public virtual T Single(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate, include);

			return query.Single();
		}

		/// <summary>
		/// single as an asynchronous operation.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;T&gt;.</returns>
		public virtual async Task<T> SingleAsync(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate, include);

			return await query.SingleAsync();
		}

		/// <summary>
		/// Singles the or default.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>T.</returns>
		public virtual T SingleOrDefault(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate, include);

			return query.SingleOrDefault();
		}

		/// <summary>
		/// single or default as an asynchronous operation.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;T&gt;.</returns>
		public virtual async Task<T> SingleOrDefaultAsync(
			Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		)
		{
			var query = _entities.AsQueryable();

			query = PrepareQuery(query, predicate, include);

			return await query.SingleOrDefaultAsync();
		}

		#endregion Single

		#region Add

		/// <summary>
		/// Adds the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		public virtual void Add(T t)
		{
			_context.Add(t);
		}

		/// <summary>
		/// Adds the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		public virtual void Add(IEnumerable<T> t)
		{
			_context.AddRange(t);
		}

		/// <summary>
		/// add as an asynchronous operation.
		/// </summary>
		/// <param name="t">The t.</param>
		/// <returns>Task.</returns>
		public virtual async Task AddAsync(T t)
		{
			await _context.AddAsync(t);
		}

		/// <summary>
		/// add as an asynchronous operation.
		/// </summary>
		/// <param name="t">The t.</param>
		/// <returns>Task.</returns>
		public virtual async Task AddAsync(IEnumerable<T> t)
		{
			await _context.AddRangeAsync(t);
		}

		#endregion Add

		#region Remove

		/// <summary>
		/// Removes the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		public virtual void Remove(T t)
		{
			_context.Remove(t);
		}

		/// <summary>
		/// Removes the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		public virtual void Remove(IEnumerable<T> t)
		{
			_context.RemoveRange(t);
		}

		#endregion Remove

		#region Update

		/// <summary>
		/// Updates the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		public virtual void Update(T t)
		{
			_context.Update(t);
		}

		/// <summary>
		/// Updates the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		public virtual void Update(IEnumerable<T> t)
		{
			_context.UpdateRange(t);
		}

		#endregion Update
	}
}
