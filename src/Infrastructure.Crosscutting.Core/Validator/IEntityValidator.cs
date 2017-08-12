using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Crosscutting.Core.Validator
{
	public interface IEntityValidator
	{
		bool IsValid<TEntity>(TEntity item) where TEntity : class;

		IEnumerable<string> GetInvalidMessages<TEntity>(TEntity item) where TEntity : class;

		IList<ValidationResult> GetValidationResults<TEntity>(TEntity item) where TEntity : class;
	}
}