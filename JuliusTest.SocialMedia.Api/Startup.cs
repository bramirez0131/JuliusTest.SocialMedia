using AutoMapper;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Reflection;
using System.Text;

using JuliusTest.SocialMedia.Api.Filters;
using JuliusTest.SocialMedia.Application.Abstract;
using JuliusTest.SocialMedia.Application.Enumerations;
using JuliusTest.SocialMedia.Application.Implements;
using JuliusTest.SocialMedia.Application.Mappings;
using JuliusTest.SocialMedia.Infrastructure.Extensions;

namespace JuliusTest.SocialMedia.Api
{
	/// <summary>
	/// Class Startup.
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Startup"/> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// Gets the configuration.
		/// </summary>
		/// <value>The configuration.</value>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// Configures the services.
		/// </summary>
		/// <param name="services">The services.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(options =>
			{
				options.Filters.Add<ValidatorActionFilter>();
			}).AddFluentValidation(options =>
			{
				options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
			});

			services.AddControllers(options =>
			{
				options.Filters.Add<GlobalExceptionFilter>();
			}).AddNewtonsoftJson(options =>
			{
				options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
				options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
			})
		   .ConfigureApiBehaviorOptions(options =>
		   {
			   options.SuppressModelStateInvalidFilter = true;
		   });

			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new AutomappeProfile());
			});

			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);
			services.AddOptions(Configuration);
			services.AddDbContexts(Configuration);
			AddApplicationService(services);

			services.AddServices();
			services.AddSwagger($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
			AddAuthentication(services);

			services.AddCors(o => o.AddPolicy("AllowClientApp", builder =>
			{
				builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();
			}));

			services.AddResponseCaching();
		}

		/// <summary>
		/// Configures the specified application.
		/// </summary>
		/// <param name="app">The application.</param>
		/// <param name="env">The env.</param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("swagger/v1/swagger.json", "V1");
				options.RoutePrefix = string.Empty;
				options.DefaultModelsExpandDepth(NumerosEnum.MenosUno.Id);
			});

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseResponseCaching();

			app.Use(async (context, next) =>
			{
				context.Response.GetTypedHeaders().CacheControl =
					new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
					{
						Public = true,
						MaxAge = TimeSpan.FromSeconds(20)
					};
				context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
					new string[] { "Accept-Encoding" };

				await next();
			});

			app.UseCors("AllowClientApp");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		/// <summary>
		/// Adds the application service.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>IServiceCollection.</returns>
		public void AddApplicationService(IServiceCollection services)
		{
			services.AddSingleton<IContrasenaService, ContrasenaService>();
			services.AddTransient<IUsuarioService, UsuarioService>();
			services.AddTransient<IPublicacionService, PublicacionService>();
			services.AddTransient<IPublicacionSentenciaService, PublicacionSentenciaService>();
		}

		/// <summary>
		/// Adds the authentication.
		/// </summary>
		/// <param name="services">The services.</param>
		public void AddAuthentication(IServiceCollection services)
		{
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = Configuration["Authentication:Issuer"],
					ValidAudience = Configuration["Authentication:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
				};
			});
		}
	}
}
