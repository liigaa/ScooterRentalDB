using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScooterRental.Core;
using ScooterRental.Core.Models;
using System.Collections.Generic;
using System;
using FluentAssertions;

namespace ScooterRental.Tests
{
    [TestClass]
    public class RentCalculationTests
    {
        private IRentCalculation _calculation;
        private List<DateTime> _starTimes;
        private List<DateTime> _endTimes;
        private List<RentedScooter> _history;

        [TestInitialize]
        public void Setup()
        {
            _starTimes = new List<DateTime>
            {
                new DateTime(2022, 09, 01, 23, 11, 00),
                new DateTime(2022, 09, 02, 23, 45, 00),
                new DateTime(2022, 09, 02, 16, 11, 00)
            };

            _endTimes = new List<DateTime>
            {
                new DateTime(2022, 09, 03, 00, 30, 00),
                new DateTime(2022, 09, 03, 00, 30, 00),
                new DateTime(2022, 09, 02, 16, 30, 00),
            };

            _history = new List<RentedScooter>
            {
                new RentedScooter("1", _starTimes[0], _endTimes[0], 1m),
                new RentedScooter("2", _starTimes[1], _endTimes[1], 1m),
                new RentedScooter("3", DateTime.UtcNow.AddMinutes(-10), 1m),
                new RentedScooter("4", _starTimes[2], _endTimes[2], 1m)
            };

            _calculation = new RentCalculation();
        }

        [TestMethod]
        public void GetTotalPriceForScooterWhenReturned()
        {
            // Act
            var result = _calculation.GetRentedScooterFee(_history[0]);
            var result2 = _calculation.GetRentedScooterFee(_history[1]);
            var result3 = _calculation.GetRentedScooterFee(_history[3]);

            // Assert
            result.Should().Be(60);
            result2.Should().Be(35);
            result3.Should().Be(19);
        }

        [TestMethod]
        public void GetTotalPriceForScooterWhenReturned_IfNotEndTimeSet_ThrowEndTimeNotSetException()
        {
            // Act
            Action act = () => _calculation.GetRentedScooterFee(_history[2]);

            // Assert
            act.Should().Throw<Exception>();
        }
    }
}
