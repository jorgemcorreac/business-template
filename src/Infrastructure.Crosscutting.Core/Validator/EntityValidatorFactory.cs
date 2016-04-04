namespace Infrastructure.Crosscutting.Core.Validator
{
	public static class EntityValidatorFactory
	{
		private static IEntityValidatorFactory _factory;

		public static void SetCurrent(IEntityValidatorFactory factory) => _factory = factory;

		public static IEntityValidator CreateValidator() => _factory?.Create();
	}
}