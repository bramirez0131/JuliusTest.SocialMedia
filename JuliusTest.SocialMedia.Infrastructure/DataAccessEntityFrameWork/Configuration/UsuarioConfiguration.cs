using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using JuliusTest.SocialMedia.Domain.Entities;
using JuliusTest.SocialMedia.Domain.Enumerations;
using System;

namespace JuliusTest.SocialMedia.Infrastructure.DataAccessEntityFrameWork.Configuration
{
    /// <summary>
    /// Class UsuarioConfiguration.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{JuliusTest.SocialMedia.Domain.Entities.Usuario}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{JuliusTest.SocialMedia.Domain.Entities.Usuario}" />
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

			builder.ToTable("Usuario");

			builder.HasKey(e => e.Id);

			builder.Property(e => e.Id)
			   .HasColumnName("IdUsuario")
			   .IsRequired()
			   .IsUnicode(false);

			builder.Property(e => e.NombreUsuario)
				.IsRequired()
				.HasMaxLength(100)
				.IsUnicode(false);

			builder.Property(e => e.Contrasena)
				.IsRequired()
				.HasMaxLength(200)
				.IsUnicode(false);

			builder.Property(e => e.Email)
				.IsRequired()
				.HasMaxLength(200)
				.IsUnicode(true);

			builder.Property(e => e.Rol)
			   .HasMaxLength(15)
			   .IsRequired()
			   .HasConversion(
					x => x.ToString(),
					x => (RoleType)Enum.Parse(typeof(RoleType), x)
				);

		}
    }
}
