#pragma warning disable CS1591

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Reflection;

namespace Boruc.LabEquip.Services.Equipment.API
{
	using Boruc.LabEquip.Services.Equipment.Infrastructure;
	using Infrastructure.AutofacModules;
	using Infrastructure.Filters;
	using Newtonsoft.Json;
	using System.Collections.Generic;
	using System.IO;
	using Microsoft.AspNetCore.Rewrite;

	internal class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddCustomMvc()
				.AddCustomDbContext(Configuration)
				.AddCustomSwagger()
				.AddCustomConfiguration(Configuration);

			var container = new ContainerBuilder();
			container.Populate(services);

			container.RegisterModule(new MediatorModule());
			container.RegisterModule(new ApplicationModule(Configuration["ConnectionString"]));
			container.RegisterModule(new EventStoreModule(Configuration["EventStoreConnectionString"]));

			return new AutofacServiceProvider(container.Build());
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				//TODO: understand this
				app.UseHsts();
			}

			app.UseCors("CorsPolicy");

			app.UseHttpsRedirection();
			app.UseMvcWithDefaultRoute();

			app.UseSwagger(swaggerOptions => swaggerOptions.PreSerializeFilters.AddRange(new List<Action<SwaggerDocument, HttpRequest>>()
				{
					(swaggerDoc, httpReq) => swaggerDoc.Host = httpReq.Host.Value,
					(swaggerDoc, httpReq) => swaggerDoc.Schemes = new List<string>{ httpReq.Scheme}
				}))
				.UseSwaggerUI(options =>
				{
					options.SwaggerEndpoint(@"/swagger/v1/swagger.json", "Equipment.API V1");
					options.OAuthClientId("equipmentswaggerui");
					options.OAuthAppName("Equipment Swagger UI");
				});

			var swaggerRewriteOptions = new RewriteOptions();
			swaggerRewriteOptions.AddRedirect("^$", "swagger");
			app.UseRewriter(swaggerRewriteOptions);

		}
	}

	internal static class CustomExtensionsMethods
	{
		internal static IServiceCollection AddCustomMvc(this IServiceCollection services)
		{
			services.AddMvc(options =>
				{
					options.Filters.Add(typeof(HttpGlobalExceptionFilter));
				})
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
				.AddControllersAsServices()
				.AddJsonOptions(options => options.SerializerSettings.Formatting = Formatting.Indented);

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.SetIsOriginAllowed(host => true)
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
			});
			return services;
		}

		internal static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddEntityFrameworkSqlServer()
				.AddDbContext<EquipmentContext>(options =>
					{
						options.UseSqlServer(configuration["ConnectionString"],
							sqlServerOptionsAction: sqlOptions =>
							{
								sqlOptions.MigrationsAssembly(typeof(EquipmentContext).GetTypeInfo().Assembly.GetName().Name);
							});
					});
			return services;
		}

		internal static IServiceCollection AddCustomSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				options.DescribeAllEnumsAsStrings();

				options.SwaggerDoc("v1", new Info()
				{
					Title = "Laboratory equipment API",
					Version = "v1",
					Description = "ASP.NET Core API using CQRS and DDD patterns for supporting Laboratory with equipment storing.",
					TermsOfService = "None",
					Contact =  new Contact
					{
						Name = "Michał Boruciński",
						Email = "s12425@pjwstk.edu.pl",
						Url = "https://twitter.com/mborucinski"
					}
				});

				// Set the comments path for the Swagger JSON and UI.
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				options.IncludeXmlComments(xmlPath);
			});

			//TODO configure oauth
			return services;
		}

		internal static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddOptions();
			//TODO check this
			services.Configure<EquipmentSettings>(configuration);
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = context =>
				{
					var problemDetails = new ValidationProblemDetails(context.ModelState)
					{
						Instance = context.HttpContext.Request.Path,
						Status = StatusCodes.Status400BadRequest,
						Detail = "Please refer to the errors property for additional details."
					};

					return new BadRequestObjectResult(problemDetails)
					{
						ContentTypes = { "application/problem+json", "application/problem+xml" }
					};
				};
			});
			return services;
		}
	}
}
