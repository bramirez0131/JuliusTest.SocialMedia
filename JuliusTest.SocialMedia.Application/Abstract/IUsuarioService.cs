using System.Threading.Tasks;

using JuliusTest.SocialMedia.Domain.DTO;
using JuliusTest.SocialMedia.Domain.Entities;

namespace JuliusTest.SocialMedia.Application.Abstract
{
    /// <summary>
    /// Interface IUsuarioService
    /// </summary>
    public interface IUsuarioService
    {

        /// <summary>
        /// Crears the usuario.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        /// <returns>Task&lt;bool&gt;.</returns>
        Task<bool> CrearUsuario(Usuario usuario);

        /// <summary>
        /// Gets the login by credentials.
        /// </summary>
        /// <param name="usuario">The user login.</param>
        /// <returns>Task&lt;Security&gt;.</returns>

        Task<Usuario> ValidarUsuario(SeguridadDto usuario);
    }
}
