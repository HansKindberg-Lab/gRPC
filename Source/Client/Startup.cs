using System;
using Client.Models.Clients;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Client
{
	public class Startup
	{
		#region Constructors

		public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
		{
			this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
			this.HostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
		}

		#endregion

		#region Properties

		protected internal virtual IConfiguration Configuration { get; }
		protected internal virtual IHostEnvironment HostEnvironment { get; }

		#endregion

		#region Methods

		public virtual void Configure(IApplicationBuilder applicationBuilder)
		{
			if(applicationBuilder == null)
				throw new ArgumentNullException(nameof(applicationBuilder));

			applicationBuilder
				.UseDeveloperExceptionPage()
				.UseStaticFiles()
				.UseRouting()
				.UseAuthorization()
				.UseEndpoints(endpoints =>
				{
					endpoints.MapDefaultControllerRoute();
				});
		}

		public virtual void ConfigureServices(IServiceCollection services)
		{
			if(services == null)
				throw new ArgumentNullException(nameof(services));

			services.AddSingleton<IListDictionaryClient, ListDictionaryClient>();

			services.AddControllersWithViews();
		}

		#endregion
	}
}