using JuliusTest.SocialMedia.Domain.DTO;
using JuliusTest.SocialMedia.Infrastructure.Interfaces;

namespace JuliusTest.SocialMedia.Infrastructure.Repositories
{
    public class UsuarioDapperRepository : DapperRepository<UsuarioDto>, IUsuarioDapperRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioDapperRepository"/> class.
        /// </summary>
        public UsuarioDapperRepository()
        {
        }
    }
}
