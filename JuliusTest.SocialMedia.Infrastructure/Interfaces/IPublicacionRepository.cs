using JuliusTest.SocialMedia.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface IPublicacionRepository
    /// Implements the <see cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IReadRepository{JuliusTest.SocialMedia.Domain.Entities.Usuario}" />
    /// Implements the <see cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.ICreateRepository{JuliusTest.SocialMedia.Domain.Entities.Usuario}" />
    /// </summary>
    /// <seealso cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IReadRepository{JuliusTest.SocialMedia.Domain.Entities.Usuario}" />
    /// <seealso cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.ICreateRepository{JuliusTest.SocialMedia.Domain.Entities.Usuario}" />
    public interface IPublicacionRepository : IReadRepository<Publicacion>, ICreateRepository<Publicacion>, IPagedRepository<Publicacion>
    {

        /// <summary>
        /// Consultars the Publicaciones.
        /// </summary>
        /// <returns>Task.</returns>
        Task<List<Publicacion>> ConsultarPublicaciones();

        /// <summary>
        /// Consultars the Publicaciones por Usuario.
        /// </summary>
        /// <param name="idUsuario">id del usuario.</param>
        /// <returns>Task.</returns>
        Task<List<Publicacion>> ConsultarPublicacionesPorUsuario(int idUsuario);
    }
}
