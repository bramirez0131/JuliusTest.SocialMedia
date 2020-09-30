namespace JuliusTest.SocialMedia.Application.DTO
{
    /// <summary>
    /// Class UsuarioCrearDto.
    /// </summary>
    public class UsuarioCrearDto
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Contrasena { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>The Email.</value>
        public string Email { get; set; }
    }
}
