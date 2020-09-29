using System;
using System.Collections.Generic;
using System.Text;

namespace JuliusTest.SocialMedia.Domain.DTO
{
    public class UsuarioDto
    {
        /// <summary>
        /// Gets or sets the IdUsuario.
        /// </summary>
        /// <value>The IdUsuario.</value>
        public int IdUsuario { get; set; }

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
    }
}
