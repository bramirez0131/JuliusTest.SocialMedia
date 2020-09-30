using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using JuliusTest.SocialMedia.Domain.Entities;

namespace JuliusTest.SocialMedia.Infrastructure.DataAccessEntityFrameWork.Configuration
{
    /// <summary>
    /// Class PublicacionConfiguration.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{JuliusTest.SocialMedia.Domain.Entities.Publicacion}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{JuliusTest.SocialMedia.Domain.Entities.Publicacion}" />
    public class PublicacionConfiguration : IEntityTypeConfiguration<Publicacion>
    {
		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<Publicacion> builder)
		{

			builder.ToTable("Publicacion");

			builder.HasKey(e => e.Id);

			builder.Property(e => e.Id)
			   .HasColumnName("IdPublicacion")
			   .IsRequired()
			   .IsUnicode(false);

			builder.Property(e => e.IdUsuario)
			   .HasColumnName("IdUsuario")
			   .IsRequired()
			   .IsUnicode(false);

			builder.Property(e => e.Titulo)
				.IsRequired()
				.IsUnicode(false);

			builder.Property(e => e.Contenido)
				.IsUnicode(false);

			builder.Property(e => e.FechaCreacion)
				.HasColumnType("datetime")
				.IsRequired()
				.IsUnicode(false);
		}
	}
}
