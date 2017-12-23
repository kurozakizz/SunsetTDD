using System;
using Sunset.Interface;

namespace Sunset.Library
{
    public class ServiceSunsetCalculator : ISunsetCalculator
    {
        public DateTime GetSunrise(DateTime date)
        {
            throw new NotImplementedException();
        }

        public DateTime GetSunset(DateTime date)
        {
            // call service to get data

            // parse sunset from data

            // convert sunset ro DateTime

            throw new NotImplementedException();
        }
    }
}
