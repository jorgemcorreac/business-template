using System;
using System.IO;
using System.Reflection;
using System.Web.Http;
using Api;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof (Startup))]

namespace Api
{
	/// <summary>
	/// Owin startup
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="app"></param>
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();
			WebApiConfig.Register(config);
			UnityConfig.RegisterComponents(config);

			config.EnableSwagger(c =>
			{
				c.SingleApiVersion("v1", "Api");
				c.IncludeXmlComments(GetXmlCommentsPath());
			}).EnableSwaggerUi();

			app.UseWebApi(config);
		}

		/// <summary>
		/// </summary>
		/// <returns></returns>
		protected static string GetXmlCommentsPath()
		{
			var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
			var commentsFile = Path.Combine(baseDirectory, "bin", commentsFileName);

			return commentsFile;
		}
	}
}
