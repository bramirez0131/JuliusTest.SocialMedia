namespace JuliusTest.SocialMedia.Application.DTO
{
    /// <summary>
    /// Class DataTableResponseDto.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseDto<T> where T : class
    {
        /// <summary>
        /// Gets or sets the records total.
        /// </summary>
        /// <value>The records total.</value>
        public int RecordsTotal { get; set; }
        /// <summary>
        /// Gets or sets the records filtered.
        /// </summary>
        /// <value>The records filtered.</value>
        public int RecordsFiltered { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public T[] Data { get; set; }
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        public string Error { get; set; }
    }
}
