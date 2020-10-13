using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuliusTest.SocialMedia.Application.Abstract;
using JuliusTest.SocialMedia.Application.DTO;
using JuliusTest.SocialMedia.Application.Enumerations;
using JuliusTest.SocialMedia.Domain.Entities;
using JuliusTest.SocialMedia.Infrastructure.Interfaces;
using JuliusTest.SocialMedia.Domain.DTO;

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
        /// The contrasena service
        /// </summary>
        private readonly IContrasenaService _contrasenaService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="contrasenaService">The contrasena Service.</param>
        public UsuarioService(IUnitOfWork unitOfWork
                            , IContrasenaService contrasenaService)
        {
            this._unitOfWork = unitOfWork;
            this._contrasenaService = contrasenaService;
        }

        /// <summary>
        /// Crears the usuario.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        /// <returns>Task&lt;Usuario&gt;.</returns>
        public async Task<bool> CrearUsuario(Usuario usuario)
        {
            var ExitsUser = await _unitOfWork.UsuarioRepository.ExisteUsuario(usuario.NombreUsuario);
            if(ExitsUser)
            {
                return false;
            }

            var ExitsEmail = await _unitOfWork.UsuarioRepository.ExisteEmail(usuario.Email);
            if (ExitsEmail)
            {
                return false;
            }
            _unitOfWork.UsuarioRepository.Add(usuario);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Gets the login by credentials.
        /// </summary>
        /// <param name="usuario">The user login.</param>
        /// <returns>Task&lt;Usuario&gt;.</returns>
        public async Task<Usuario> ValidarUsuario(SeguridadDto usuario)
        {
            var seguridad = await _unitOfWork.UsuarioRepository.ValidarUsuario(usuario);
            var valido = _contrasenaService.Check(seguridad.Contrasena, usuario.Contrasena);
            return valido ? seguridad : null;
        }
    }
}
