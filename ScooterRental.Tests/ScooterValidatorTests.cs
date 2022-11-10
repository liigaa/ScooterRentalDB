using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScooterRental.Core.Models;
using ScooterRental.Core.Validations;

namespace ScooterRental.Tests
{
    [TestClass]
    public class ScooterValidatorTests
    {
        private readonly IScooterValidator _idValidator = new IdValidator();
        private readonly IScooterValidator _pricePerMinuteValidator = new PricePerMinuteValidator();

        [TestMethod]
        public void ScooterId_IsNotEmptyOrNull_ResultTrue()
        {
            // Arrange
            var scooter = new Scooter
            {
                Id = "1"
            };

            // Act
            var result = _idValidator.IsValid(scooter);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void ScooterId_IsEmptyOrNull_ResultFalse(string id)
        {
            // Arrange
            var scooter = new Scooter
            {
                Id = id
            };

            // Act
            var result = _idValidator.IsValid(scooter);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void ScooterPricePerMinute_IsNotLessThanZero_ResultTrue()
        {
            // Arrange
            var scooter = new Scooter
            {
                PricePerMinute = 0.4m
            };

            // Act
            var result = _pricePerMinuteValidator.IsValid(scooter);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ScooterPricePerMinute_IsEmptyOrNull_ResultFalse()
        {
            // Arrange
            var scooter = new Scooter
            {
                PricePerMinute = -0.4m
            };

            // Act
            var result = _pricePerMinuteValidator.IsValid(scooter);

            // Assert
            result.Should().BeFalse();
        }
    }
}
