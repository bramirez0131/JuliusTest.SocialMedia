namespace JuliusTest.SocialMedia.Infrastructure.Pages
{
	/// <summary>
	/// Class Metadata.
	/// </summary>
	public class Metadata
	{
		/// <summary>
		/// Gets or sets the total count.
		/// </summary>
		/// <value>The total count.</value>
		public int TotalCount { get; set; }
		/// <summary>
		/// Gets or sets the size of the page.
		/// </summary>
		/// <value>The size of the page.</value>
		public int PageSize { get; set; }
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
		/// Gets or sets a value indicating whether this instance has next page.
		/// </summary>
		/// <value><c>true</c> if this instance has next page; otherwise, <c>false</c>.</value>
		public bool HasNextPage { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this instance has previous page.
		/// </summary>
		/// <value><c>true</c> if this instance has previous page; otherwise, <c>false</c>.</value>
		public bool HasPreviousPage { get; set; }
		/// <summary>
		/// Gets or sets the next page URL.
		/// </summary>
		/// <value>The next page URL.</value>
		public string NextPageUrl { get; set; }
		/// <summary>
		/// Gets or sets the previous page URL.
		/// </summary>
		/// <value>The previous page URL.</value>
		public string PreviousPageUrl { get; set; }
	}
}
