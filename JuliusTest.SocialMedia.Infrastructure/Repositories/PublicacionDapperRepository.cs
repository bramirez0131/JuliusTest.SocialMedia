using JuliusTest.SocialMedia.Domain.DTO;
using JuliusTest.SocialMedia.Infrastructure.Interfaces;

namespace JuliusTest.SocialMedia.Infrastructure.Repositories
{
    public class PublicacionDapperRepository : DapperRepository<PublicacionDto>, IPublicacionDapperRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublicacionDapperRepository"/> class.
        /// </summary>
        public PublicacionDapperRepository()
        {
        }
    }
}
