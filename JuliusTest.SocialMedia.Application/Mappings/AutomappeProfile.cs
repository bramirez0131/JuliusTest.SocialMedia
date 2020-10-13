using AutoMapper;

using JuliusTest.SocialMedia.Application.DTO;
using JuliusTest.SocialMedia.Domain.Entities;

namespace JuliusTest.SocialMedia.Application.Mappings
{
	/// <summary>
	/// Class AutomappeProfile.
	/// Implements the <see cref="Profile" />
	/// </summary>
	/// <seealso cref="Profile" />
	public class AutomappeProfile : Profile
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AutomappeProfile"/> class.
		/// </summary>
		public AutomappeProfile()
		{
			CreateMap<Usuario, UsuarioCrearDto>();
			CreateMap<UsuarioCrearDto, Usuario>()
			   .ForMember(s => s.Id, o => o.Ignore());
			CreateMap<Publicacion, PublicacionCrearDto>();
			CreateMap<PublicacionCrearDto, Publicacion>()
			   .ForMember(s => s.Id, o => o.Ignore());
		}
	}
}
