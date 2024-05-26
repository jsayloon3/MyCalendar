using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyCalendar
{
    public static class CalendarUtility
    {
        public static string GetMonthName(int curMonth)
        {
            string[] monthDictionary = { 
                "January", "February", "March", "April", "May", "June",
                 "July", "August", "September", "October", "November", "December"
            };

            return monthDictionary[curMonth];
        }

        public static int GetEquivalentNumberOfDayInWeek(string day)
        {
            int dayNumber = 1;
            switch (day)
            {
                case var _ when day.StartsWith("Su"): dayNumber = 1; break;
                case var _ when day.StartsWith("Mo"): dayNumber = 2; break;
                case var _ when day.StartsWith("Tu"): dayNumber = 3; break;
                case var _ when day.StartsWith("We"): dayNumber = 4; break;
                case var _ when day.StartsWith("Th"): dayNumber = 5; break;
                case var _ when day.StartsWith("Fr"): dayNumber = 6; break;
                case var _ when day.StartsWith("Sa"): dayNumber = 7; break;
            }

            return dayNumber;
        }

        public static string CalendarWeekHeaderFormat()
        {
            string weekHeader = string.Format(@"Su  Mo  Tu  We  Th  Fr  Sa");

            return weekHeader;
        }

        public static void FormatDisplayCalendar(string day, bool isWeekend = false, bool nextLine = false)
        {
            const int length = 2;
            const int blankLength = 2;

            string formattedNumber = day.Length > length ? day.Substring(0, length) : day.PadRight(length);
            string formattedBlank = "".PadRight(blankLength);

            if (isWeekend) Console.ForegroundColor = ConsoleColor.Green;

            if (!nextLine)
                Console.Write($"{formattedNumber}{formattedBlank}");
            else
                Console.Write($"\n{formattedNumber}{formattedBlank}");

            if (isWeekend) Console.ResetColor();
        }
    }
}
