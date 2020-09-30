using JuliusTest.SocialMedia.Infrastructure.Pages;

namespace JuliusTest.SocialMedia.Api.Response
{
	/// <summary>
	/// Class ApiResponse.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ApiResponse<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApiResponse{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		public ApiResponse(T data)
		{
			Data = data;
		}

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>The data.</value>
		public T Data { get; set; }

		/// <summary>
		/// Gets or sets the meta.
		/// </summary>
		/// <value>The meta.</value>
		public Metadata Meta { get; set; }
	}
}
