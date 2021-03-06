﻿using System;

namespace JuliusTest.SocialMedia.Domain.DTO
{
    public class PublicacionDto
    {
        /// <summary>
        /// Gets or sets the IdPublicacion.
        /// </summary>
        /// <value>The IdUsuario.</value>
        public int IdPublicacion { get; set; }

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
        /// Gets or sets the Contenido.
        /// </summary>
        /// <value>The Contenido.</value>
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
        /// Gets or sets the total registros.
        /// </summary>
        /// <value>The total registros.</value>
        public int TotalRegistros { get; set; }

        /// <summary>
        /// Gets or sets the registros filtrados.
        /// </summary>
        /// <value>The registros filtrados.</value>
        public int RegistrosFiltrados { get; set; }
    }
}
