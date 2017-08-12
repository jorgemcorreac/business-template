using Infrastructure.Crosscutting.Core.Validator;
using Infrastructure.Crosscutting.NetFramework.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
	[TestClass]
	public static class AssemblyTestsInitialize
	{
	    [AssemblyInitialize]
		public static void InitializeFactories(TestContext context)
		{
			EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
		}
	}
}