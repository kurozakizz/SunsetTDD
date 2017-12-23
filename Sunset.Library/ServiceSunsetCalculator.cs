using System;
using Microsoft.CSharp.RuntimeBinder;
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

            // hardcode service data
            string serviceData = "{\"results\": {\"sunrise\": \"6:37:49 AM\", \"sunset\": \"4:42:49 PM\", \"solar_noon\": \"11:40:19 AM\", \"day_length\": \"10:05:00.1530000\"}, \"status\": \"OK\"}";

            // parse sunset from data
            string sunsetTimeString = ParseSunset(serviceData);

            // convert sunset to DateTime
            return LocalTime(sunsetTimeString, date);
        }

        public static string ParseSunset(string jsonContent)
        {
            try
            {
                dynamic data = JsonConvert.DeserializeObject(jsonContent);
                return data.results.sunset;
            }
            catch (RuntimeBinderException)
            {
                throw new ArgumentException($"JSON Object dose not contain 'sunset': {jsonContent} ");
            }
        }

        public static DateTime LocalTime(string timeString, DateTime inputDate)
        {
            DateTime time = DateTime.Parse(timeString);
            return inputDate + time.TimeOfDay;
        }
    }
}
