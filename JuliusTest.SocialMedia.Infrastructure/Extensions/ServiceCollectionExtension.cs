using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using JuliusTest.SocialMedia.Infrastructure.DataAccessEntityFrameWork;
using JuliusTest.SocialMedia.Infrastructure.Interfaces;
using JuliusTest.SocialMedia.Infrastructure.Options;
using JuliusTest.SocialMedia.Infrastructure.Repositories;

namespace JuliusTest.SocialMedia.Infrastructure.Extensions
{
    /// <summary>
    /// Class ServiceCollectionExtension.
    /// </summary>

    public static class ServiceCollectionExtension
    {
		/// <summary>
		/// Adds the database contexts.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<SmContext>(options =>
			   options.UseSqlServer(configuration.GetConnectionString("Sm"))
		    );

			return services;
		}

		/// <summary>
		/// Adds the options.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<PaginacionOpcion>(options => configuration.GetSection("PaginacionOpcion").Bind(options));
			services.Configure<ContrasenaOpcion>(options => configuration.GetSection("ContrasenaOpcion").Bind(options));
			return services;
		}

		/// <summary>
		/// Adds the services.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped(typeof(IDapperRepository<>), typeof(DapperRepository<>));
			services.AddTransient<IUsuarioDapperRepository, UsuarioDapperRepository>();
			services.AddTransient<IUsuarioRepository, UsuarioRepository>();
			services.AddTransient<IPublicacionDapperRepository, PublicacionDapperRepository>();
			services.AddTransient<IPublicacionRepository, PublicacionRepository>();
			services.AddTransient<IUnitOfWork, UnitOfWork>();
			
			return services;
		}

		/// <summary>
		/// Adds the swagger.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="xmlFileName">Name of the XML file.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
		{
			services.AddSwaggerGen(doc =>
			{
				doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Social Media JuliusTest API", Version = "v1" });

				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
				doc.IncludeXmlComments(xmlPath);

				var securitySchema = new OpenApiSecurityScheme
				{
					Description = "Authorization ",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				};
				doc.AddSecurityDefinition("Bearer", securitySchema);

				var securityRequirement = new OpenApiSecurityRequirement
				{
					{ securitySchema, new[] { "Bearer" } }
				};
				doc.AddSecurityRequirement(securityRequirement);
			});

			return services;
		}
	}
}
