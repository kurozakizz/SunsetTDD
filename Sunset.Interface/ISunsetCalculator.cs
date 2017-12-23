using System;

namespace Sunset.Interface
{
    public interface ISunsetCalculator
    {
        DateTime GetSunset(DateTime date);
        DateTime GetSunrise(DateTime date);
    }
}
