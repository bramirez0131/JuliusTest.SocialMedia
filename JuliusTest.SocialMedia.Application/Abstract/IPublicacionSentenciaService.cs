using System.Threading.Tasks;

using JuliusTest.SocialMedia.Application.DTO;
using JuliusTest.SocialMedia.Domain.DTO;
using JuliusTest.SocialMedia.Domain.Entities;

namespace JuliusTest.SocialMedia.Application.Abstract
{
    /// <summary>
    /// Interface IPublicacionSentenciaService
    /// </summary>
    public interface IPublicacionSentenciaService
    {
        /// <summary>
        /// Obteners the sentencia.
        /// </summary>
        /// <param name="parametros">The parametros.</param>
        /// <returns>System.String.</returns>
        string ObtenerSentenciaUsuario(PublicacionUsuarioDto parametros);

        /// <summary>
        /// Obteners the sentencia.
        /// </summary>
        /// <param name="parametros">The parametros.</param>
        /// <returns>System.String.</returns>
        string ObtenerSentenciaGeneral(PublicacionGeneralDto parametros);

        /// <summary>
        /// Obteners the sentencia.
        /// </summary>
        /// <param name="parametros">The parametros.</param>
        /// <returns>System.String.</returns>
        string ObtenerSentenciaBusquedaUsuario(PublicacionBusquedaDto parametros);
    }
}
