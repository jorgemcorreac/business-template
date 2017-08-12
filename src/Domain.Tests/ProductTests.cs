using System.Linq;
using Infrastructure.Crosscutting.Core.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
	[TestClass]
	public class ProductTests
	{
		[TestMethod]
		[TestCategory("Product")]
		public void Product_Is_Invalid_When_The_Name_Is_Null()
		{
			//arrange
			var product = new Product
			{
				Name = null
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(product).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(
				validationResults.Any(
					vr => vr.ErrorMessage == Messages.Product_Name_Required_ErrorMessage_The_product_name_is_required));
		}

		[TestMethod]
		[TestCategory("Product")]
		public void Product_Is_Invalid_When_The_Name_Is_Empty()
		{
			//arrange
			var product = new Product
			{
				Name = string.Empty
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(product).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(
				validationResults.Any(
					vr => vr.ErrorMessage == Messages.Product_Name_Required_ErrorMessage_The_product_name_is_required));
		}

		[TestMethod]
		[TestCategory("Product")]
		public void Product_Is_Invalid_When_The_Name_Is_White_Spaces()
		{
			//arrange
			var product = new Product
			{
				Name = "   "
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(product).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(
				validationResults.Any(
					vr => vr.ErrorMessage == Messages.Product_Name_Required_ErrorMessage_The_product_name_is_required));
		}

		[TestMethod]
		[TestCategory("Product")]
		public void Product_Is_Invalid_When_The_Name_Is_Too_Long()
		{
			//arrange
			var product = new Product
			{
				Name = new string('P', 21)
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(product).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(
				validationResults.Any(
					vr => vr.ErrorMessage == Messages.Product_Name_MaxLength_ErrorMessage_The_product_name_is_too_long));
		}

		[TestMethod]
		[TestCategory("Product")]
		public void Product_Is_Invalid_When_The_Unit_Price_Is_Less_Than_Zero()
		{
			//arrange
			var product = new Product
			{
				Name = "Product Name",
				UnitPrice = -1
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(product).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(
				validationResults.Any(
					vr => vr.ErrorMessage == Messages.Product_UnitPrice_GreaterThanZero_The_unit_price_must_be_greater_than_zero));
		}

		[TestMethod]
		[TestCategory("Product")]
		public void Product_Is_Invalid_When_The_Unit_Price_Is_Equal_To_Zero()
		{
			//arrange
			var product = new Product
			{
				Name = "Product Name",
				UnitPrice = 0
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(product).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(
				validationResults.Any(
					vr => vr.ErrorMessage == Messages.Product_UnitPrice_GreaterThanZero_The_unit_price_must_be_greater_than_zero));
		}

		[TestMethod]
		[TestCategory("Product")]
		public void Product_Is_Valid()
		{
			//arrange
			var product = new Product
			{
				Name = "Product Name",
				UnitPrice = 100,
				UnitsInStock = 1000,
				Discontinued = false
			};

			//act
			var validator = EntityValidatorFactory.CreateValidator();
			var validationResults = validator.GetValidationResults(product).ToList();

			//write to the console output
			TestHelper.WriteInConsoleValidationResults(validationResults);

			//assert
			Assert.IsTrue(!validationResults.Any());
		}
	}
}