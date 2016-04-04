namespace Infrastructure.Crosscutting.Core.Validator
{
	public interface IEntityValidatorFactory
	{
		IEntityValidator Create();
	}
}