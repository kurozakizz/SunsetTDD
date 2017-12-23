using System;
using Sunset.Interface;
using Xunit;

namespace Sunset.Library.Tests
{
    public class ServiceSunsetCalculatorTests
    {
        string goodData = "{\"results\": {\"sunrise\": \"6:37:49 AM\", \"sunset\": \"4:42:49 PM\", \"solar_noon\": \"11:40:19 AM\", \"day_length\": \"10:05:00.1530000\"}, \"status\": \"OK\"}";
        string badData  = "{\"results\": null, \"status\": \"ERROR\"}";

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
            string actual = ServiceSunsetCalculator.ParseSunset(goodData);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParseJsonSunsetValue_OnBadData_ThrowArgumentxception()
        {
            try
            {
                // Act
                string actual = ServiceSunsetCalculator.ParseSunset(badData);

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

    }
}
