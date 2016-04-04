using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
	[Table("Products")]
	public class Product : IValidatableObject
	{
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false,
			ErrorMessageResourceType = typeof (Messages),
			ErrorMessageResourceName = "Product_Name_Required_ErrorMessage_The_product_name_is_required")]
		[MaxLength(20,
			ErrorMessageResourceType = typeof (Messages),
			ErrorMessageResourceName = "Product_Name_MaxLength_ErrorMessage_The_product_name_is_too_long")]
		public string Name { get; set; }

		public decimal? UnitPrice { get; set; }

		public short? UnitsInStock { get; set; }

		public bool Discontinued { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (UnitPrice <= 0)
				yield return
					new ValidationResult(Messages.Product_UnitPrice_GreaterThanZero_The_unit_price_must_be_greater_than_zero,
						new[] { nameof(UnitPrice) });
		}
	}
}