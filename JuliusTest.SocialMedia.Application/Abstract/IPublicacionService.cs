using System;
using System.Threading.Tasks;

using JuliusTest.SocialMedia.Application.DTO;
using JuliusTest.SocialMedia.Domain.DTO;
using JuliusTest.SocialMedia.Domain.Entities;

namespace JuliusTest.SocialMedia.Application.Abstract
{
    /// <summary>
    /// Interface IPublicacionService
    /// </summary>
    public interface IPublicacionService
    {
        /// <summary>
        /// Lineas the consultar publicaciones usuario.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IEnumerable&lt;PublicacionDto&gt;&gt;.</returns>
        Task<ResponseDto<PublicacionDto>> ConsultarPublicacionesBusqueda(PublicacionBusquedaDto dto);

        /// <summary>
        /// Lineas the consultar publicaciones usuario.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IEnumerable&lt;PublicacionDto&gt;&gt;.</returns>
        Task<ResponseDto<PublicacionDto>> ConsultarPublicacionesUsuario(PublicacionUsuarioDto dto);

        /// <summary>
        /// Lineas the consultar publicaciones.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IEnumerable&lt;PublicacionDto&gt;&gt;.</returns>
        Task<ResponseDto<PublicacionDto>> ConsultarPublicaciones(PublicacionGeneralDto dto);

        /// <summary>
        /// Crear the Publicacion.
        /// </summary>
        /// <param name="publicacion">The publicacion.</param>
        /// <returns>Task&lt;bool&gt;.</returns>
        Task<bool> EliminarPublicacion(PublicacionEliminarDto publicacion);

        /// <summary>
        /// Crear the Publicacion.
        /// </summary>
        /// <param name="publicacion">The publicacion.</param>
        /// <returns>Task&lt;bool&gt;.</returns>
        Task<bool> CrearPublicacion(Publicacion publicacion);
    }
}
