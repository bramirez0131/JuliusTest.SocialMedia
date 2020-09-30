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
    /// Class UsuarioService.
    /// Implements the <see cref="JuliusTest.SocialMedia.Application.Abstract.IUsuarioService" />
    /// </summary>
    /// <seealso cref="JuliusTest.SocialMedia.Application.Abstract.IUsuarioService" />
    public class UsuarioService : IUsuarioService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// The Usuario dapper
        /// </summary>
        private readonly IUsuarioDapperRepository _usuarioDapper;

        /// <summary>
        /// The connection string Sm
        /// </summary>
        private readonly string _connectionStringSm;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioService"/> class.
        /// </summary>
        /// <param name="usuarioDapper">The publicacion dapper.</param>
        /// <param name="configuration">The configuration.</param>
        public UsuarioService(IUnitOfWork unitOfWork
                                , IUsuarioDapperRepository usuarioDapper
                                , IConfiguration configuration)
        {
            this._unitOfWork = unitOfWork;
            this._usuarioDapper = usuarioDapper;
            this._connectionStringSm = configuration[CadenaConexionEnum.Sm.Name];
        }
    }
}
