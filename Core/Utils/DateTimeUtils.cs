namespace TWJobs.Core.Utils;

public static class DateTimeUtils
{
    public static int GetAge(this DateTime dateTime)
    {
        var age = DateTime.Now.Year - dateTime.Year;
        if (DateTime.Now.DayOfYear < dateTime.DayOfYear)
        {
            age--;
        }
        return age;
    }
}