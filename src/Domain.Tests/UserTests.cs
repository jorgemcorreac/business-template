using System;
using System.Linq;
using Infrastructure.Crosscutting.Core.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
	[TestClass]
	public class UserTests
	{
		[TestMethod]
		[TestCategory("User")]
		public void User_Is_Invalid_When_The_Name_Is_Null()
		{
			//arrange
			var user = new User
			{
				Name = null
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(user).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(
				validationResults.Any(
					vr => vr.ErrorMessage == Messages.User_Name_Required_ErrorMessage_The_user_name_is_required));
		}

		[TestMethod]
		[TestCategory("User")]
		public void User_Is_Invalid_When_The_Name_Is_Empty()
		{
			//arrange
			var user = new User
			{
				Name = string.Empty
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(user).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(
				validationResults.Any(
					vr => vr.ErrorMessage == Messages.User_Name_Required_ErrorMessage_The_user_name_is_required));
		}

		[TestMethod]
		[TestCategory("User")]
		public void User_Is_Invalid_When_The_Name_Is_White_Spaces()
		{
			//arrange
			var user = new User
			{
				Name = "   "
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(user).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(
				validationResults.Any(
					vr => vr.ErrorMessage == Messages.User_Name_Required_ErrorMessage_The_user_name_is_required));
		}

		[TestMethod]
		[TestCategory("User")]
		public void User_Is_Invalid_When_The_Name_Is_Too_Long()
		{
			//arrange
			var user = new User
			{
				Name = new string('U', 101)
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(user).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(
				validationResults.Any(
					vr => vr.ErrorMessage == Messages.User_Name_MaxLength_ErrorMessage_The_user_name_is_too_long));
		}

		[TestMethod]
		[TestCategory("User")]
		public void User_Is_Invalid_When_The_Birthdate_Year_Is_Less_Than_1900()
		{
			//arrange
			var user = new User
			{
				Name = "User Name",
				Birthdate = new DateTime(1899, 01, 01)
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(user).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(
				validationResults.Any(
					vr => vr.ErrorMessage == Messages.User_Birthdate_GreaterThan1900_The_year_of_the_birth_date_must_be_greater_1900));
		}

		[TestMethod]
		[TestCategory("User")]
		public void User_Is_Invalid_When_The_Birthdate_Year_Is_Equal_To_1900()
		{
			//arrange
			var user = new User
			{
				Name = "User Name",
				Birthdate = new DateTime(1900, 01, 01)
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(user).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(
				validationResults.Any(
					vr => vr.ErrorMessage == Messages.User_Birthdate_GreaterThan1900_The_year_of_the_birth_date_must_be_greater_1900));
		}

		[TestMethod]
		[TestCategory("User")]
		public void User_Is_Valid()
		{
			//arrange
			var user = new User
			{
				Name = "User Name",
				Birthdate = new DateTime(1970, 01, 01)
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(user).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(!validationResults.Any());
		}
	}
}