using System;
using System.Collections.Generic;

namespace JuliusTest.SocialMedia.Infrastructure.Pages
{
	/// <summary>
	/// Class PagedList.
	/// Implements the <see cref="List{T}" />
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="List{T}" />
	public class PagedList<T> : List<T>
	{
		/// <summary>
		/// Gets or sets the current page.
		/// </summary>
		/// <value>The current page.</value>
		public int CurrentPage { get; set; }

		/// <summary>
		/// Gets or sets the total pages.
		/// </summary>
		/// <value>The total pages.</value>
		public int TotalPages { get; set; }

		/// <summary>
		/// Gets or sets the size of the page.
		/// </summary>
		/// <value>The size of the page.</value>
		public int PageSize { get; set; }

		/// <summary>
		/// Gets or sets the total count.
		/// </summary>
		/// <value>The total count.</value>
		public int TotalCount { get; set; }

		/// <summary>
		/// Gets a value indicating whether this instance has previous page.
		/// </summary>
		/// <value><c>true</c> if this instance has previous page; otherwise, <c>false</c>.</value>
		public bool HasPreviousPage => CurrentPage > 1;

		/// <summary>
		/// Gets a value indicating whether this instance has next page.
		/// </summary>
		/// <value><c>true</c> if this instance has next page; otherwise, <c>false</c>.</value>
		public bool HasNextPage => CurrentPage < TotalPages;

		/// <summary>
		/// Gets the next page number.
		/// </summary>
		/// <value>The next page number.</value>
		public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : (int?)null;

		/// <summary>
		/// Gets the previous page number.
		/// </summary>
		/// <value>The previous page number.</value>
		public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : (int?)null;

		/// <summary>
		/// Initializes a new instance of the <see cref="PagedList{T}" /> class.
		/// </summary>
		/// <param name="items">The items.</param>
		/// <param name="count">The count.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		public PagedList(List<T> items, int count, int pageNumber, int pageSize)
		{
			TotalCount = count;
			PageSize = pageSize;
			CurrentPage = pageNumber;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);

			AddRange(items);
		}

		/// <summary>
		/// Creates the specified source.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="count">The count.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>PagedList&lt;T&gt;.</returns>
		public static PagedList<T> Create(List<T> source, int count, int pageNumber, int pageSize)
		{
			return new PagedList<T>(source, count, pageNumber, pageSize);
		}
	}
}
