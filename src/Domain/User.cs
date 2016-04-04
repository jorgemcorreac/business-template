using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
	[Table("Users")]
	public class User : IValidatableObject
	{
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false,
			ErrorMessageResourceType = typeof (Messages),
			ErrorMessageResourceName = "User_Name_Required_ErrorMessage_The_user_name_is_required")]
		[MaxLength(100,
			ErrorMessageResourceType = typeof (Messages),
			ErrorMessageResourceName = "User_Name_MaxLength_ErrorMessage_The_user_name_is_too_long")]
		public string Name { get; set; }

		public DateTime Birthdate { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Birthdate.Year <= 1900)
				yield return
					new ValidationResult(Messages.User_Birthdate_GreaterThan1900_The_year_of_the_birth_date_must_be_greater_1900,
						new[] {nameof(Birthdate)});
		}
	}
}