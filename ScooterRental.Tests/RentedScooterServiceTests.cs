using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using ScooterRental.Core.Models;
using ScooterRental.Core.Services;
using ScooterRental.Data;
using ScooterRental.Services;

namespace ScooterRental.Tests
{
    [TestClass]
    public class RentedScooterServiceTests
    {
        private RentedScooterService _service;
        private AutoMocker _mocker;
        private Mock<IScooterRentalDbContext> _moq;

        [TestInitialize]
        public void Setup()
        {
            _mocker = new AutoMocker();
            _service = _mocker.CreateInstance<RentedScooterService>();
            _moq = _mocker.GetMock<IScooterRentalDbContext>();
        }

        [TestMethod]
        public void GetNotFinishedRentalIncome_IfYearNotSameAsDateTimeNowYear_ReturnZero()
        {
            // Arrange
            var year = DateTime.UtcNow.Year -1;

            // Act
            var result = _service.GetNotFinishedRentalIncome(year);

            // Assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void GetNotFinishedRentalIncome_IfYearSameAsDateTimeNowYear_ReturnZero()
        {
            // Arrange
            var year = DateTime.UtcNow.Year;

            _moq.Setup(c => c.RentedScooters).Returns(List<RentedScooter>());

            // Act
            var result = _service.GetNotFinishedRentalIncome(year);

            // Assert
            result.Should().Be(0);
        }

        private DbSet<RentedScooter> List<T>() where T : class
        {
            return _moq.Object.RentedScooters;
        }


        public IList<RentedScooter> GetRentedScooters()
        {
            return new List<RentedScooter>
            {
                new RentedScooter("1", DateTime.UtcNow.AddMinutes(-10), DateTime.UtcNow, 0.2m),
                new RentedScooter("2", DateTime.UtcNow.AddMinutes(-5),  0.2m),
                new RentedScooter("3", DateTime.UtcNow.AddMinutes(-10),  0.2m),
            };
        }
    }
}
