﻿using JuliusTest.SocialMedia.Domain.DTO;
using JuliusTest.SocialMedia.Domain.Entities;
using JuliusTest.SocialMedia.Infrastructure.DataAccessEntityFrameWork;
using JuliusTest.SocialMedia.Infrastructure.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Infrastructure.Repositories
{
    /// <summary>
    /// Class UsuarioRepository.
    /// Implements the <see cref="JuliusTest.SocialMedia.Infrastructure.Repositories.GenericRepository{JuliusTest.SocialMedia.Domain.Entities.Usuario}" />
    /// Implements the <see cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IUsuarioRepository" />
    /// </summary>
    /// <seealso cref="JuliusTest.SocialMedia.Infrastructure.Repositories.GenericRepository{JuliusTest.SocialMedia.Domain.Entities.Usuario}" />
    /// <seealso cref="JuliusTest.SocialMedia.Infrastructure.Interfaces.IUsuarioRepository" />
    /// <summary>
    /// Initializes a new instance of the <see cref="UsurioRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(SmContext context) : base(context)
        {
        }

        public async Task<bool> ExisteEmail(string email)
        {
            var result = await _entities.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ExisteUsuario(string usuario)
        {
            var result = await _entities.Where(x => x.NombreUsuario == usuario).FirstOrDefaultAsync();
            if(result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Usuario> ValidarUsuario(SeguridadDto usuario)
        {
            return await _entities.FirstOrDefaultAsync(x => x.NombreUsuario == usuario.Usuario);
        }
    }
}
