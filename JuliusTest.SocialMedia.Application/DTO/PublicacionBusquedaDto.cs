namespace JuliusTest.SocialMedia.Application.DTO
{
    /// <summary>
    /// Class PublicacionUsuarioDto.
    /// </summary>
    public class PublicacionBusquedaDto
    {
        /// <summary>
        /// Gets or sets the Id Usuario.
        /// </summary>
        /// <value>The Id Usuario.</value>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Gets or sets the Id Usuario.
        /// </summary>
        /// <value>The Id Usuario.</value>
        public string Busqueda { get; set; }

        /// <summary>
        /// Paging first record indicator.
        /// This is the start point in the current data set (0 index based - i.e. 0 is the first record).
        /// </summary>
        /// <value>The start.</value>
        public int Start { get; set; }

        /// <summary>
        /// Number of records that the table can display in the current draw.
        /// It is expected that the number of records returned will be equal to this number, unless the server has fewer records to return.
        /// Note that this can be -1 to indicate that all records should be returned (although that negates any benefits of server-side processing!)
        /// </summary>
        /// <value>The length.</value>
        public int Length { get; set; }
    }
}
