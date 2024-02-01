using System.Globalization;
using AutoMapper;

namespace SocialMedia.Helpers;

public class PersianDateStringToDateMapper : ITypeConverter<string, DateTime>
{
    public static DateTime ConvertToGregorian(string persianDate)
    {
        string[] dateComponents = persianDate.Split('/');

        if (dateComponents.Length != 3)
        {
            throw new ArgumentException("Invalid Persian date format. Please use the format: yyyy/mm/dd");
        }

        int year = int.Parse(dateComponents[0]);
        int month = int.Parse(dateComponents[1]);
        int day = int.Parse(dateComponents[2]);

        PersianCalendar persianCalendar = new PersianCalendar();

        DateTime gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);

        return gregorianDate;
    }

    public DateTime Convert(string source, DateTime destination, ResolutionContext context)
    {
        return ConvertToGregorian(source);
    }
}