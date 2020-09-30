using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuliusTest.SocialMedia.Application.Abstract;
using JuliusTest.SocialMedia.Application.DTO;
using JuliusTest.SocialMedia.Application.Enumerations;
using JuliusTest.SocialMedia.Domain.Entities;
using JuliusTest.SocialMedia.Infrastructure.Interfaces;

namespace JuliusTest.SocialMedia.Application.Implements
{
    /// <summary>
    /// Class PublicacionService.
    /// Implements the <see cref="JuliusTest.SocialMedia.Application.Abstract.IPublicacionService" />
    /// </summary>
    /// <seealso cref="JuliusTest.SocialMedia.Application.Abstract.IPublicacionService" />
    public class PublicacionService : IPublicacionService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// The Publicacion dapper
        /// </summary>
        private readonly IPublicacionDapperRepository _publicacionDapper;

        /// <summary>
        /// The linea sentencia
        /// </summary>
        private readonly IPublicacionSentenciaService _publicacionSentencia;

        /// <summary>
        /// The connection string Sm
        /// </summary>
        private readonly string _connectionStringSm;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublicacionSentenciaService"/> class.
        /// </summary>
        /// <param name="publicacionDapper">The publicacion dapper.</param>
        /// <param name="publicacionSentencia">The publicacion sentencia.</param>
        /// <param name="configuration">The configuration.</param>
        public PublicacionService(IUnitOfWork unitOfWork
                                , IPublicacionDapperRepository publicacionDapper
                                , IPublicacionSentenciaService publicacionSentencia
                                , IConfiguration configuration)
        {
            this._unitOfWork = unitOfWork;
            this._publicacionDapper = publicacionDapper;
            this._publicacionSentencia = publicacionSentencia;
            this._connectionStringSm = configuration[CadenaConexionEnum.Sm.Name];
        }
    }
}
