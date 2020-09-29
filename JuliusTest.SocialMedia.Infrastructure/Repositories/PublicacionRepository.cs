using JuliusTest.SocialMedia.Domain.Entities;
using JuliusTest.SocialMedia.Infrastructure.DataAccessEntityFrameWork;
using JuliusTest.SocialMedia.Infrastructure.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Infrastructure.Repositories
{
    /// <summary>
    /// Class PublicacionRepository.
    /// Implements the <see cref="JuliusTest.SocialMedia.Infrastructure.Repositories.GenericRepository{JuliusTest.SocialMedia.Domain.Entities.Publicacion}" />
    /// Implements the <see cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IPublicacionRepository" />
    /// </summary>
    /// <seealso cref="JuliusTest.SocialMedia.Infrastructure.Repositories.GenericRepository{JuliusTest.SocialMedia.Domain.Entities.Publicacion}" />
    /// <seealso cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IPublicacionRepository" />
    /// <summary>
    /// Initializes a new instance of the <see cref="PublicacionRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public class PublicacionRepository : GenericRepository<Publicacion>, IPublicacionRepository
    {
        public PublicacionRepository(SmContext context) : base(context)
        {
        }

        /// <summary>
        /// Consultars the Publicaciones.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task<List<Publicacion>> ConsultarPublicaciones()
        {
            return await _entities.ToListAsync();
        }

        /// <summary>
        /// Consultars the Publicaciones por Usuario.
        /// </summary>
        /// <param name="idUsuario">id del usuario.</param>
        /// <returns>Task.</returns>

        public async Task<List<Publicacion>> ConsultarPublicacionesPorUsuario(int idUsuario)
        {
            return await _entities.Where(x => x.IdUsuario == idUsuario).ToListAsync();
        }
    }
}
