using JuliusTest.SocialMedia.Domain.DTO;
using JuliusTest.SocialMedia.Domain.Entities;

using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface IUsuarioRepository
    /// Implements the <see cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IReadRepository{JuliusTest.SocialMedia.Domain.Entities.Usuario}" />
    /// Implements the <see cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.ICreateRepository{JuliusTest.SocialMedia.Domain.Entities.Usuario}" />
    /// </summary>
    /// <seealso cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IReadRepository{JuliusTest.SocialMedia.Domain.Entities.Usuario}" />
    /// <seealso cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.ICreateRepository{JuliusTest.SocialMedia.Domain.Entities.Usuario}" />
    public interface IUsuarioRepository : IReadRepository<Usuario>, ICreateRepository<Usuario>, IPagedRepository<Usuario>
    {

        /// <summary>
        /// Gets the login by credentials.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        /// <returns>Task&lt;Usuario&gt;.</returns>
        Task<Usuario> ValidarUsuario(SeguridadDto usuario);
    }
}
