using System.Web.Http;
using Infrastructure.Crosscutting.Core.Logging;
using Infrastructure.Crosscutting.NetFramework.Logging;
using Infrastructure.Data;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace Api
{
	/// <summary>
	/// </summary>
	public static class UnityConfig
	{
		/// <summary>
		/// </summary>
		public static void RegisterComponents(HttpConfiguration config)
		{
			var container = new UnityContainer();

			container.RegisterType<IStockContext, StockContext>(new HierarchicalLifetimeManager());

			ConfigureFactories();

			config.DependencyResolver = new UnityDependencyResolver(container);
		}

		private static void ConfigureFactories()
		{
			LoggerFactory.SetCurrent(new TraceSourceLoggerFactory());
		}
	}
}