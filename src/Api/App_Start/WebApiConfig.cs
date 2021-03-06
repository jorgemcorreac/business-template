﻿using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Api
{
	/// <summary>
	/// 
	/// </summary>
	public static class WebApiConfig
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="config"></param>
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Formatters.Remove(config.Formatters.XmlFormatter);

			config.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger());
		}
	}
}
