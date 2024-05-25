using System;
using System.Collections.Generic;
using System.Linq;
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

        public static int GetEquivalentNumberOfWeek(string week)
        {
            int weekNumber = 1;
            switch (week)
            {
                case var _ when week.StartsWith("Su"): weekNumber = 1; break;
                case var _ when week.StartsWith("Mo"): weekNumber = 2; break;
                case var _ when week.StartsWith("Tu"): weekNumber = 3; break;
                case var _ when week.StartsWith("We"): weekNumber = 4; break;
                case var _ when week.StartsWith("Th"): weekNumber = 5; break;
                case var _ when week.StartsWith("Fr"): weekNumber = 6; break;
                case var _ when week.StartsWith("Sa"): weekNumber = 7; break;
            }

            return weekNumber;
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
