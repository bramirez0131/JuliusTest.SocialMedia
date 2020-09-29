using JuliusTest.SocialMedia.Domain.DTO;

namespace JuliusTest.SocialMedia.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface IUsuarioDapperRepository
    /// Implements the <see cref="JuliusTest.SocialMedia.Infrastructure.IDapperRepository{JuliusTest.SocialMedia.Domain.DTO.UsuarioDto}" />
    /// </summary>
    /// <seealso cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IDapperRepository{JuliusTest.SocialMedia.Domain.DTO.UsuarioDto}" />
    public interface IUsuarioDapperRepository : IDapperRepository<UsuarioDto>
    {
    }
}
