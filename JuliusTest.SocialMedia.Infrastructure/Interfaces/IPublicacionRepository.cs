using JuliusTest.SocialMedia.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface IPublicacionRepository
    /// Implements the <see cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IReadRepository{JuliusTest.SocialMedia.Domain.Entities.Publicacion}" />
    /// Implements the <see cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.ICreateRepository{JuliusTest.SocialMedia.Domain.Entities.Publicacion}" />
    /// Implements the <see cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IRemoveRepository{JuliusTest.SocialMedia.Domain.Entities.Publicacion}" />
    /// </summary>
    /// <seealso cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IReadRepository{JuliusTest.SocialMedia.Domain.Entities.Publicacion}" />
    /// <seealso cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.ICreateRepository{JuliusTest.SocialMedia.Domain.Entities.Publicacion}" />
    /// <seealso cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IDapperRepository{JuliusTest.SocialMedia.Domain.Entities.Publicacion}" /> 
    public interface IPublicacionRepository : IReadRepository<Publicacion>, ICreateRepository<Publicacion>, IRemoveRepository<Publicacion>
    {
        /// <summary>
        /// Gets the Eliminar Publicacion.
        /// </summary>
        /// <param name="email">The Email.</param>
        /// <returns>Task&lt;bool&gt;.</returns>
        Task EliminarPublicacion(int idPublicacion);
    }
}
