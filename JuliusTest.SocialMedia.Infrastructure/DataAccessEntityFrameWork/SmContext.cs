using JuliusTest.SocialMedia.Domain.Entities;

using Microsoft.EntityFrameworkCore;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace JuliusTest.SocialMedia.Infrastructure.DataAccessEntityFrameWork
{
    /// <summary>
    /// Class SocialMediaContext.
    /// Implements the <see cref="DbContext" />
    /// </summary>
    /// <seealso cref="DbContext" />
    [ExcludeFromCodeCoverage]
    public partial class SmContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmContext"/> class.
        /// </summary>
        public SmContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SmContext(DbContextOptions<SmContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Users.
        /// </summary>
        /// <value>The lineas.</value>
        public virtual DbSet<Usuario> Usuarios { get; set; }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>The posts.</value>
        public virtual DbSet<Publicacion> Publicaciones { get; set; }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publicacion>()
                .HasOne(p => p.Usuario)
                .WithMany(b => b.Publicaciones)
                .HasForeignKey(p => p.IdUsuario);

            modelBuilder.Entity<Publicacion>()
                .HasIndex(p => new { p.Titulo, p.Contenido })
                .HasFilter(null);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
