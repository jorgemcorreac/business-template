using System.Web.Http.ExceptionHandling;
using Infrastructure.Crosscutting.Core.Logging;


namespace Api
{
	/// <summary>
	/// Global Exception Logger
	/// </summary>
	public class GlobalExceptionLogger: ExceptionLogger
	{
		public override void Log(ExceptionLoggerContext context)
		{
			if (context?.Exception != null)
			{
				var log =  LoggerFactory.CreateLog();
				log.Fatal("An unhandled error occurred", context.Exception);
			}

			base.Log(context);
		}
	}
}