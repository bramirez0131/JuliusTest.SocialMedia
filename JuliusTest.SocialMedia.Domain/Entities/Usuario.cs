using System.Collections.Generic;

namespace JuliusTest.SocialMedia.Domain.Entities
{
    /// <summary>
    /// Class Usuario.
    /// Implements the <see cref="JuliusTest.SocialMedia.Domain.Entities.BaseEntity" />
    /// </summary>
    /// <seealso cref="JuliusTest.SocialMedia.Domain.Entities.BaseEntity" />
    public class Usuario : BaseEntity
    {
        /// <summary>
        /// Gets or sets the NombreUsuario.
        /// </summary>
        /// <value>The NombreUsuario.</value>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Contrasena { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The password.</value>
        public string Email { get; set; }

        public List<Publicacion> Publicaciones { get; set; }
    }
}
