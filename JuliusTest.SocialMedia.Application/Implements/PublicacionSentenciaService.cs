using JuliusTest.SocialMedia.Application.Abstract;
using JuliusTest.SocialMedia.Application.DTO;
using JuliusTest.SocialMedia.Infrastructure.QueryResources;

namespace JuliusTest.SocialMedia.Application.Implements
{
    /// <summary>
    /// Class PublicacionSentenciaService.
    /// Implements the <see cref="JuliusTest.SocialMedia.Application.Abstract.IPublicacionSentenciaService" />
    /// </summary>
    /// <seealso cref="JuliusTest.SocialMedia.Application.Abstract.IPublicacionSentenciaService" />
    public class PublicacionSentenciaService : IPublicacionSentenciaService
    {
        /// <summary>
        /// Obteners the sentencia.
        /// </summary>
        /// <param name="parametros">The parametros.</param>
        /// <returns>System.String.</returns>
        public string ObtenerSentenciaBusquedaUsuario(PublicacionBusquedaDto parametros)
        {
            string consulta = PublicacionSentencias.PublicacionConsultaBase;
            consulta += PublicacionSentencias.LineaOrdenamiento;
            consulta += string.Format(PublicacionSentencias.LineaPaginado, ((parametros.Start - 1) * parametros.Length), parametros.Length);
            return consulta;
        }

        /// <summary>
        /// Obteners the sentencia.
        /// </summary>
        /// <param name="parametros">The parametros.</param>
        /// <returns>System.String.</returns>
        public string ObtenerSentenciaGeneral(PublicacionGeneralDto parametros)
        {
            string consulta = PublicacionSentencias.PublicacionConsultaBase;
            consulta += PublicacionSentencias.LineaOrdenamiento;
            consulta += string.Format(PublicacionSentencias.LineaPaginado, ((parametros.Start - 1) * parametros.Length), parametros.Length);
            return consulta;
        }

        /// <summary>
        /// Obteners the sentencia.
        /// </summary>
        /// <param name="parametros">The parametros.</param>
        /// <returns>System.String.</returns>
        public string ObtenerSentenciaUsuario(PublicacionUsuarioDto parametros)
        {
            string consulta = PublicacionSentencias.PublicacionConsultaBase;
            consulta += string.Format(PublicacionSentencias.LineaWhere, parametros.IdUsuario);
            consulta += PublicacionSentencias.LineaOrdenamiento;
            consulta += string.Format(PublicacionSentencias.LineaPaginado, ((parametros.Start - 1) * parametros.Length), parametros.Length);
            return consulta;
        }
    }
}
