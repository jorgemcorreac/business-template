using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Infrastructure.Crosscutting.Core.Logging;


namespace Api
{
	/// <summary>
	/// Global Exception Logger
	/// </summary>
	public class GlobalExceptionLogger: ExceptionLogger
	{
	    /// <inheritdoc />
	    public override void Log(ExceptionLoggerContext context)
		{
			if (context?.Exception != null)
			{
				var log =  LoggerFactory.CreateLog();
				log.Fatal("An unhandled error occurred", context.Exception);
			}

			base.Log(context);
		}

	    /// <inheritdoc />
	    public override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
	    {
	        if (context?.Exception != null)
	        {
	            var log = LoggerFactory.CreateLog();
	            log.Fatal("An unhandled error occurred", context.Exception);
	        }

            return base.LogAsync(context, cancellationToken);
	    }
    }
}