using System;
using Moq;
using Sunset.Interface;
using Xunit;

namespace Sunset.Library.Tests
{
    public class ServiceSunsetCalculatorTests
    {
        string successData = "{\"results\": {\"sunrise\": \"6:37:49 AM\", \"sunset\": \"4:42:49 PM\", \"solar_noon\": \"11:40:19 AM\", \"day_length\": \"10:05:00.1530000\"}, \"status\": \"OK\"}";
        string errorData  = "{\"results\": null, \"status\": \"ERROR\"}";

        [Fact]
        public void ServiceSunsetCalculator_ImplementISunsetCalculator()
        {
            // Arrange
            ServiceSunsetCalculator calculator = new ServiceSunsetCalculator();

            // Assert
            Assert.IsAssignableFrom<ISunsetCalculator>(calculator);
        }

        [Fact]
        public void ParseJsonSunsetValue_OnGoodData_ReturnExpectedString()
        {
            // Arrange
            string expected = "4:42:49 PM";

            // Act
            string actual = ServiceSunsetCalculator.ParseSunset(successData);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParseJsonSunsetValue_OnBadData_ThrowArgumentxception()
        {
            try
            {
                // Act
                string actual = ServiceSunsetCalculator.ParseSunset(errorData);

                // Assert
                Assert.True(false, "ArgumentException was not thrown");
            }
            catch (ArgumentException)
            {
                // Assert
                Assert.True(true);
            }
        }

        [Fact]
        public void LocalTime_OnValidValue_ReturnsExpectedDateTime()
        {
            // Arrange
            string timeString = "4:42:49 PM";
            DateTime inputDate = new DateTime(2016, 11, 30);
            DateTime expected = new DateTime(2016, 11, 30, 16, 42, 49);

            // Act
            DateTime actual = ServiceSunsetCalculator.LocalTime(timeString, inputDate);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetSunset_OnValidDate_ReturnsExpectedDateTime()
        {
            // Arrange
            var serviceMoq = new Mock<ISolarService>();
            serviceMoq
                .Setup(s => s.GetServiceData(It.IsAny<DateTime>()))
                .Returns(successData);
            ServiceSunsetCalculator calculator = new ServiceSunsetCalculator();
            calculator.Service = serviceMoq.Object;
            DateTime inputDate = new DateTime(2016, 11, 30);
            DateTime expectedDateTime = new DateTime(2016, 11, 30, 16, 42, 49);

            // Act
            DateTime actualDateTime = calculator.GetSunset(inputDate);

            // Assert
            Assert.Equal(expectedDateTime, actualDateTime);
        }

    }
}
