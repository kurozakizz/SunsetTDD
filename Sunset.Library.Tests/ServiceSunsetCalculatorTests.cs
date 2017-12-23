using System;
using Sunset.Interface;
using Xunit;

namespace Sunset.Library.Tests
{
    public class ServiceSunsetCalculatorTests
    {
        string goodData = "{\"result\": {\"sunrise\": \"6:37:49 AM\", \"sunset\": \"4:42:49 PM\", \"solar_noon\": \"11:40:19 AM\", \"day_length\": \"10:05:00.1530000\"}, \"status\": \"OK\"}";

        [Fact]
        public void ServiceSunsetCalculator_ImplementISunsetCalculator()
        {
            // Arrange
            ServiceSunsetCalculator calculator = new ServiceSunsetCalculator();

            // Assert
            Assert.IsAssignableFrom<ISunsetCalculator>(calculator);
        }
    }
}
