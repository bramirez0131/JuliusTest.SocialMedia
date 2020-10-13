using System;

namespace JuliusTest.SocialMedia.Domain.Entities
{
    /// <summary>
    /// Class Publicacion.
    /// Implements the <see cref="JuliusTest.SocialMedia.Domain.Entities.BaseEntity" />
    /// </summary>
    /// <seealso cref="JuliusTest.SocialMedia.Domain.Entities.BaseEntity" />
    public class Publicacion : BaseEntity
    {
        /// <summary>
        /// Gets or sets the IdUsuario.
        /// </summary>
        /// <value>The IdUsuario.</value>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Gets or sets the Title.
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

        /// <summary>
        /// Gets or sets the FechaCreacion.
        /// </summary>
        /// <value>The FechaCreacion.</value>
        public DateTime FechaCreacion { get; set; }


        /// <summary>
        /// Gets or sets the User.
        /// </summary>
        /// <value>The User.</value>
        public Usuario Usuario { get; set; }
    }
}
