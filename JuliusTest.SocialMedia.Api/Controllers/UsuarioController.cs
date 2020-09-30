using AutoMapper;

using JuliusTest.SocialMedia.Application.Abstract;
using JuliusTest.SocialMedia.Application.DTO;
using JuliusTest.SocialMedia.Application.Enumerations;
using JuliusTest.SocialMedia.Domain.DTO;
using JuliusTest.SocialMedia.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Api.Controllers
{
    /// <summary>
    /// Class UsuarioController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
		/// <summary>
		/// The usuario service
		/// </summary>
		private readonly IUsuarioService _usuarioService;

		/// <summary>
		/// The contrasena service
		/// </summary>
		private readonly IContrasenaService _contrasenaService;

		/// <summary>
		/// The configuracion
		/// </summary>
		private readonly IConfiguration _configuracion;

		/// <summary>
		/// The mapper
		/// </summary>
		private readonly IMapper _mapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="UsuarioController" /> class.
		/// </summary>
		/// <param name="usuarioService">The usuario service.</param>
		/// <param name="contrasenaService">The contrasena service.</param> 
		/// <param name="configuracion">The configuracion.</param>
		/// <param name="mapper">The mapper.</param> 
		public UsuarioController(IUsuarioService usuarioService
			, IContrasenaService contrasenaService
			, IConfiguration configuracion
			, IMapper mapper)
		{
			_usuarioService = usuarioService;
			_contrasenaService = contrasenaService;
			_configuracion = configuracion;
			_mapper = mapper;
		}


		/// <summary>
		/// crear usuario.
		/// </summary>
		/// <param name="usuario">The usuario.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost(nameof(Crear))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Crear(UsuarioCrearDto usuario)
		{
			usuario.Contrasena = _contrasenaService.Hash(usuario.Contrasena);
			var dataMap = _mapper.Map<Usuario>(usuario);
			var result = await _usuarioService.CrearUsuario(dataMap);
			return Ok(result);
		}

		/// <summary>
		/// Authentications the specified login.
		/// </summary>
		/// <param name="login">The login.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost(Name = nameof(Autenticar))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
		public async Task<IActionResult> Autenticar(SeguridadDto login)
		{
			var seguridad = await _usuarioService.ValidarUsuario(login);
			if (seguridad == null)
			{
				return NotFound();
			}

			var token = GenerarToken(seguridad);
			return Ok(new { token });
		}

		/// <summary>
		/// Generates the token.
		/// </summary>
		/// <param name="usuario">The usuario.</param>
		/// <returns>System.String.</returns>
		private string GenerarToken(Usuario usuario)
		{
			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracion[AutenticacionEnum.LlaveSecreta.Name]));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
			var header = new JwtHeader(signingCredentials);

			var claims = new[]
			{
				new Claim(AutenticacionEnum.IdUsuario.Name, usuario.Id.ToString()),
				new Claim(ClaimTypes.Name, usuario.NombreUsuario),
				new Claim(ClaimTypes.Email, usuario.Email),
			};

			var minutos = Convert.ToDouble(_configuracion[AutenticacionEnum.MinutosToken.Name]);
			var payload = new JwtPayload
			(
				_configuracion[AutenticacionEnum.Editor.Name],
				_configuracion[AutenticacionEnum.Audiencia.Name],
				claims,
				DateTime.Now,
				DateTime.UtcNow.AddMinutes(minutos)
			);

			var token = new JwtSecurityToken(header, payload);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
