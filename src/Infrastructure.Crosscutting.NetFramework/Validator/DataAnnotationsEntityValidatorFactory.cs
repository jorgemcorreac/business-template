using Infrastructure.Crosscutting.Core.Validator;

namespace Infrastructure.Crosscutting.NetFramework.Validator
{
	public class DataAnnotationsEntityValidatorFactory
		: IEntityValidatorFactory
	{
		public IEntityValidator Create()
		{
			return new DataAnnotationsEntityValidator();
		}
	}
}