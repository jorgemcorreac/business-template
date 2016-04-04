using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Infrastructure.Crosscutting.Core.Validator;

namespace Infrastructure.Crosscutting.NetFramework.Validator
{
	public class DataAnnotationsEntityValidator
		: IEntityValidator
	{
		public bool IsValid<TEntity>(TEntity item) where TEntity : class
		{
			if (item == null)
				return false;

			var validationErrors = new List<string>();

			SetValidatableObjectErrors(item, validationErrors);
			SetValidationAttributeErrors(item, validationErrors);

			return !validationErrors.Any();
		}

		public IList<ValidationResult> GetValidationResults<TEntity>(TEntity item) where TEntity : class
		{
			if (item == null)
				return null;

			var validation = new List<ValidationResult>();

			if (typeof(IValidatableObject).IsAssignableFrom(typeof(TEntity)))
			{
				var validationContext = new ValidationContext(item, null, null);
				IEnumerable<ValidationResult> validationsObject = ((IValidatableObject)item).Validate(validationContext);
				validation.AddRange(validationsObject);
			}

			IEnumerable<ValidationResult> validationsAttribute = TypeDescriptor.GetProperties(item)
				.Cast<PropertyDescriptor>()
				.SelectMany(property => property.Attributes.OfType<ValidationAttribute>(),
					(property, attribute) => new { property, attribute })
				.Where(@t => !@t.attribute.IsValid(@t.property.GetValue(item)))
				.Select(@t => new ValidationResult(@t.attribute.FormatErrorMessage(string.Empty), new List<string> { @t.property.Name }))
				.ToList();

			if (validationsAttribute.Any())
				validation.AddRange(validationsAttribute);

			return validation;
		}

		public IEnumerable<string> GetInvalidMessages<TEntity>(TEntity item) where TEntity : class
		{
			if (item == null)
				return null;

			var validationErrors = new List<string>();

			SetValidatableObjectErrors(item, validationErrors);
			SetValidationAttributeErrors(item, validationErrors);

			return validationErrors;
		}

		private void SetValidatableObjectErrors<TEntity>(TEntity item, List<string> errors) where TEntity : class
		{
			if (typeof (IValidatableObject).IsAssignableFrom(typeof (TEntity)))
			{
				var validationContext = new ValidationContext(item, null, null);

				IEnumerable<ValidationResult> validationResults = ((IValidatableObject) item).Validate(validationContext);

				errors.AddRange(validationResults.Select(vr => vr.ErrorMessage));
			}
		}

		private void SetValidationAttributeErrors<TEntity>(TEntity item, List<string> errors) where TEntity : class
		{
			IEnumerable<string> result = TypeDescriptor.GetProperties(item)
				.Cast<PropertyDescriptor>()
				.SelectMany(property => property.Attributes.OfType<ValidationAttribute>(),
					(property, attribute) => new {property, attribute})
				.Where(@t => !@t.attribute.IsValid(@t.property.GetValue(item)))
				.Select(@t => @t.attribute.FormatErrorMessage(string.Empty))
				.ToList();

			if (result.Any())
				errors.AddRange(result);
		}
	}
}