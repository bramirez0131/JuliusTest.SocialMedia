using System;
using System.Net;
using System.Threading.Tasks;

using AutoMapper;

using JuliusTest.SocialMedia.Application.Abstract;
using JuliusTest.SocialMedia.Application.DTO;
using JuliusTest.SocialMedia.Domain.DTO;
using JuliusTest.SocialMedia.Domain.Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JuliusTest.SocialMedia.Api.Controllers
{
    /// <summary>
    /// Class PublicacionController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class PublicacionController : ControllerBase
    {
        #region Atributos
        /// <summary>
        /// The service
        /// </summary>
        private readonly IPublicacionService service;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PublicacionController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="mapper">The mapper.</param> 
        public PublicacionController(IPublicacionService service
            , IMapper mapper)
        {
            this.service = service;
            _mapper = mapper;
        }
        #endregion

        #region Servicios
        /// <summary>
        /// Crear Publicacion.
        /// </summary>
        /// <param name="publicacion">The publicacion.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CrearPublicacion(PublicacionCrearDto publicacion)
        {
            var MappingData = _mapper.Map<Publicacion>(publicacion);
            MappingData.FechaCreacion = DateTime.Now;
            var result = await service.CrearPublicacion(MappingData);
            return Ok(result);
        }


        /// <summary>
        /// Consultas Publicaciones.
        /// </summary>
        /// <param name="publicacionGeneralDto">The dto.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost(Name = "ConsultaGeneral")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDto<PublicacionDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ConsultaGeneral(PublicacionGeneralDto publicacionGeneralDto)
        {
            var resultado = await this.service.ConsultarPublicaciones(publicacionGeneralDto);
            return Ok(resultado);
        }

        /// <summary>
        /// Consultas Publicaciones Usuario.
        /// </summary>
        /// <param name="publicacionUsuarioDto">The dto.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Authorize]
        [HttpPost(Name = "ConsultaUsuario")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDto<PublicacionDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]

        public async Task<IActionResult> ConsultaUsuario(PublicacionUsuarioDto publicacionUsuarioDto)
        {
            var resultado = await this.service.ConsultarPublicacionesUsuario(publicacionUsuarioDto);
            return Ok(resultado);
        }

        /// <summary>
        /// Consultas Busqueda Publicaciones.
        /// </summary>
        /// <param name="publicacionBusquedaDto">The dto.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Authorize]
        [HttpPost(Name = "ConsultaBusqueda")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDto<PublicacionDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> ConsultaBusqueda(PublicacionBusquedaDto publicacionBusquedaDto)
        {
            var resultado = await this.service.ConsultarPublicacionesBusqueda(publicacionBusquedaDto);
            return Ok(resultado);
        }

        /// <summary>
        /// Eliminar Publicacion.
        /// </summary>
        /// <param name="publicacion">The publicacion.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> EliminarPublicacion(PublicacionEliminarDto publicacion)
        {
            var result = await service.EliminarPublicacion(publicacion);
            return Ok(result);
        }

        #endregion
    }
}
