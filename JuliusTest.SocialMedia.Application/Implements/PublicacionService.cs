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


        /// <summary>
        /// Consultar Publicaicones Usuario.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IEnumerable&lt;PublicacionDto&gt;&gt;.</returns>
        public async Task<ResponseDto<PublicacionDto>> ConsultarPublicaciones(PublicacionGeneralDto dto)
        {
            string sentencia = this._publicacionSentencia.ObtenerSentenciaGeneral(dto);
            var registros = await this._publicacionDapper.ExecuteQuerySelectAsync(this._connectionStringSm, sentencia, null);
            int registrosFiltrados = 0;
            int totalRegistros = 0;
            var primerRegistro = registros.FirstOrDefault();
            if (primerRegistro != null)
            {
                totalRegistros = primerRegistro.TotalRegistros;
                registrosFiltrados = primerRegistro.RegistrosFiltrados;
            }

            ResponseDto<PublicacionDto> resultado = new ResponseDto<PublicacionDto>()
            {
                Data = registros.ToArray(),
                Error = string.Empty,
                RecordsFiltered = registrosFiltrados,
                RecordsTotal = totalRegistros
            };

            return resultado;
        }

        /// <summary>
        /// Consultar Publicaciones Busqueda Usuario.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IEnumerable&lt;PublicacionDto&gt;&gt;.</returns>

        public async Task<ResponseDto<PublicacionDto>> ConsultarPublicacionesBusqueda(PublicacionBusquedaDto dto)
        {
            string sentencia = this._publicacionSentencia.ObtenerSentenciaBusquedaUsuario(dto);
            var registros = await this._publicacionDapper.ExecuteQuerySelectAsync(this._connectionStringSm, sentencia, null);
            int registrosFiltrados = 0;
            int totalRegistros = 0;
            var primerRegistro = registros.FirstOrDefault();
            if (primerRegistro != null)
            {
                totalRegistros = primerRegistro.TotalRegistros;
                registrosFiltrados = primerRegistro.RegistrosFiltrados;
            }

            ResponseDto<PublicacionDto> resultado = new ResponseDto<PublicacionDto>()
            {
                Data = registros.ToArray(),
                Error = string.Empty,
                RecordsFiltered = registrosFiltrados,
                RecordsTotal = totalRegistros
            };

            return resultado;
        }

        /// <summary>
        /// Consultar Publicaciones Usuario.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IEnumerable&lt;PublicacionDto&gt;&gt;.</returns>
        public async Task<ResponseDto<PublicacionDto>> ConsultarPublicacionesUsuario(PublicacionUsuarioDto dto)
        {
            string sentencia = this._publicacionSentencia.ObtenerSentenciaUsuario(dto);
            var registros = await this._publicacionDapper.ExecuteQuerySelectAsync(this._connectionStringSm, sentencia, null);
            int registrosFiltrados = 0;
            int totalRegistros = 0;
            var primerRegistro = registros.FirstOrDefault();
            if (primerRegistro != null)
            {
                totalRegistros = primerRegistro.TotalRegistros;
                registrosFiltrados = primerRegistro.RegistrosFiltrados;
            }

            ResponseDto<PublicacionDto> resultado = new ResponseDto<PublicacionDto>()
            {
                Data = registros.ToArray(),
                Error = string.Empty,
                RecordsFiltered = registrosFiltrados,
                RecordsTotal = totalRegistros
            };

            return resultado;
        }

        /// <summary>
        /// Crears the publicacion.
        /// </summary>
        /// <param name="publicacion">The publicacion.</param>
        /// <returns>Task&lt;bool&gt;.</returns>
        public async Task<bool> CrearPublicacion(Publicacion publicacion)
        {
            _unitOfWork.PublicacionRepository.Add(publicacion);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Eliminar the Publicacion.
        /// </summary>
        /// <param name="publicacion">The publicacion.</param>
        /// <returns>Task&lt;bool&gt;.</returns>
        public async Task<bool> EliminarPublicacion(PublicacionEliminarDto publicacion)
        {
            var exist = await _unitOfWork.PublicacionRepository.FirstOrDefaultAsync(x => x.Id == publicacion.IdPublicacion);
            if(exist != null)
            {
                await _unitOfWork.PublicacionRepository.EliminarPublicacion(publicacion.IdPublicacion);
                return true;
            }
            return false;
        }
    }
}
