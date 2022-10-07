using Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Test
{
    internal static class ModelStateTester
    {
        internal static void Do(object sut, bool shouldBeValid = false, string message = null)
        {
            ValidationContext ctx = new ValidationContext(sut);
            List<ValidationResult> resultSet = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(sut, ctx, resultSet, true);
            Assert.Equal(shouldBeValid, isValid);
            if (shouldBeValid == false && message != null)
            {
                Assert.Equal(message, resultSet.First().ErrorMessage);
            }
        }
    }
}
