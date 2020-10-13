namespace JuliusTest.SocialMedia.Application.DTO
{
    /// <summary>
    /// Class PublicacionCrearDto.
    /// </summary>
    public class PublicacionCrearDto
    {

        /// <summary>
        /// Gets or sets the IdUsuario.
        /// </summary>
        /// <value>The IdUsuario.</value>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Gets or sets the TItle.
        /// </summary>
        /// <value>The Title.</value>
        public string Titulo { get; set; }

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        /// <value>The Content.</value>
        public string Contenido { get; set; }

        /// <summary>
        /// Gets or sets the Imagen.
        /// </summary>
        /// <value>The Imagen.</value>
        public string Imagen { get; set; }
    }
}
