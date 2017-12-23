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

            // parse sunset from data

            // convert sunset ro DateTime

            throw new NotImplementedException();
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
