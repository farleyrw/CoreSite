using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using BundlerMinifier;
using CoreSite.Base;
using CoreSite.Base.Interfaces;
using CoreSite.Config;
using CoreSite.Filters;
using CoreSite.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using NLog.Web;

namespace CoreSite
{
	public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

			env.ConfigureNLog("nlog.config");
		}

		public IConfigurationRoot Configuration { get; }

		public IContainer ApplicationContainer { get; private set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
        {
			// Add framework services.
			services.AddMvc(options =>
			{
				options.Filters.Add<ExceptionFilter>();
				//options.Filters.Add<ModelValidationFilter>();
			}).AddJsonOptions(options =>
			{
				options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			}).AddControllersAsServices();

			services.AddScoped<ExceptionFilter>()
				.AddScoped<ModelValidationFilter>();

			services.AddSingleton<IConfiguration>(Configuration);

			services.AddOptions();

			services.Configure<Parent>(Configuration.GetSection("Parent"));

			services.AddEntityFrameworkSqlServer();

			var builder = new ContainerBuilder();

			// Register services here

			builder.RegisterTypes(Assembly.GetEntryAssembly().GetTypes())
				.Where(type => type.IsAssignableTo<BaseBusiness>())
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			builder.RegisterTypes(Assembly.GetEntryAssembly().GetTypes())
				.AsClosedTypesOf(typeof(BaseRepository<>))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			
			builder.RegisterTypes(Assembly.GetEntryAssembly().GetTypes())
				.Where(type => type.IsAssignableTo<BaseContext>())
				.AsImplementedInterfaces()
				//.OnActivating(x =>
				//{
				//	var context = x.Instance as IContext;
					
				//	context.SetConnection(Configuration);
				//})
				.InstancePerLifetimeScope();

			//builder.RegisterType<Logging.ILogger>()
			//	.As<Logger>()
			//	.OnPreparing(x => x.Parameters.);

			builder.Populate(services);

			this.ApplicationContainer = builder.Build();
			
			BundleHandler.TryGetBundles("bundleconfig.json", out IEnumerable<Bundle> bundles);
			
			return new AutofacServiceProvider(this.ApplicationContainer);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

			loggerFactory.AddNLog();

			if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
			}
			
			app.UseStaticFiles(new StaticFileOptions
			{
				OnPrepareResponse = (context) => {
					var headers = context.Context.Response.GetTypedHeaders();
					headers.CacheControl = new CacheControlHeaderValue
					{
						MaxAge = TimeSpan.FromDays(1)
					};
				}
			});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

			appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
		}
    }
}