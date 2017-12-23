using System;
using Newtonsoft.Json;
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

        public static string ParseSunset(string jsonContent)
        {
            dynamic data = JsonConvert.DeserializeObject(jsonContent);
            string sunset = data.results.sunset;
            return sunset;
        }
    }
}
