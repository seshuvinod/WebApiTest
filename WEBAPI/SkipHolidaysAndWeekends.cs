using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI
{
    public class SkipHolidaysAndWeekends
    {
        public static List<DateTime> GetlistOfHolidays()
        {
            List<DateTime> listOfHolidays = new List<DateTime>()
            {
            new DateTime(DateTime.Now.Year, 1, 1),
            new DateTime(DateTime.Now.Year, 1, 26),
            new DateTime(DateTime.Now.Year, 2, 14),
            new DateTime(DateTime.Now.Year, 8, 15),
            new DateTime(DateTime.Now.Year, 12, 25)
            };
            return listOfHolidays;
        }
        public static bool IsHoliday(DateTime date)
        {
            List<DateTime> list = GetlistOfHolidays();
            return list.Contains(date);
        }
        private static bool IsWeekEnd(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
   
}