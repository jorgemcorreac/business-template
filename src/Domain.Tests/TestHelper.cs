using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Domain.Tests
{
	public static class TestHelper
	{
		public static void WriteInConsoleValidationResults(IEnumerable<ValidationResult> results)
		{
			foreach (var validationResult in results.ToList())
			{
				Console.Out.Write("ErrorMessage: {0}, MemberNames: {1}",
					validationResult.ErrorMessage,
					validationResult.MemberNames.Aggregate((current, next) => $"{current}, {next}"));

				Console.Out.WriteLine(".");
			}
		}
	}
}