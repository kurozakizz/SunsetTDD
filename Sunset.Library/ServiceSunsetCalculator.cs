using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Sunset.Interface;

namespace Sunset.Library
{
    public class ServiceSunsetCalculator : ISunsetCalculator
    {
        private ISolarService service;
        public ISolarService Service
        {
            get { 
                if (service == null)
                {
                    service = new SolarService();
                }
                return service;
            }
            set { service = value; }
        }

        public DateTime GetSunrise(DateTime date)
        {
            throw new NotImplementedException();
        }

        public DateTime GetSunset(DateTime date)
        {
            // call service to get data
            string serviceData = Service.GetServiceData(date);

            // parse sunset from data
            string sunsetTimeString = ParseSunset(serviceData);

            // convert sunset to DateTime
            return ToLocalTime(sunsetTimeString, date);
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

        public static DateTime ToLocalTime(string timeString, DateTime inputDate)
        {
            DateTime time = DateTime.Parse(timeString);
            return inputDate + time.TimeOfDay;
        }
    }

    public interface ISolarService
    {
        string GetServiceData(DateTime date);
    }

    public class SolarService : ISolarService
    {
        public string GetServiceData(DateTime date)
        {
            // simulate response from other server
            return "{\"results\": {\"sunrise\": \"6:37:49 AM\", \"sunset\": \"4:42:39 PM\", \"solar_noon\": \"11:40:19 AM\", \"day_length\": \"10:05:00.1530000\"}, \"status\": \"OK\"}";
        }
    }
}
