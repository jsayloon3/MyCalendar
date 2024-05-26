using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using MyCalendar;

i_run_again:
Console.Write("Enter year: ");
if (int.TryParse(Console.ReadLine(), out int year))
{
    // validate year
    // Get Months
    // Get Days
    Calendar calendar = CultureInfo.InvariantCulture.Calendar;
    int months = calendar.GetMonthsInYear(year);
    int numberOfDaysInWeek = 7;

    Console.WriteLine($"\nCalendar for Year {year}");

    for (int i = 0; i < months; i++)
    {
        string monthName = CalendarUtility.GetMonthName(curMonth: i);
        int days = calendar.GetDaysInMonth(year, month: i + 1);

        Console.Write($"\n{monthName} {year}\n");

        int ctr = 0;
        for (int j = 0; j < days; j++)
        {
            DateTime currDate = new DateTime(year, month: i + 1, day: j + 1);
            int numberOfDayInWeek = CalendarUtility.GetEquivalentNumberOfDayInWeek(calendar.GetDayOfWeek(currDate).ToString());

            if (ctr == 0)
            {
                Console.Write($"{CalendarUtility.CalendarWeekHeaderFormat()}\n");

                for (int k = 1; k < numberOfDaysInWeek; k++)
                {
                    if (k != numberOfDayInWeek)
                    { 
                        CalendarUtility.FormatDisplayCalendar("");
                        ctr++;
                    }
                    else break;
                }
            }

            if (ctr < 7)
            {
                CalendarUtility.FormatDisplayCalendar((j + 1).ToString(), (numberOfDayInWeek == 1 || numberOfDayInWeek == 7));
                ctr++;
            }
            else
            { 
                CalendarUtility.FormatDisplayCalendar((j + 1).ToString(), (numberOfDayInWeek == 1 || numberOfDayInWeek == 7), nextLine: true);
                ctr = 1;
            }
        }

        Console.WriteLine();
    }

    ask_again:
    Console.Write("\nDo you want to generate a calander again? [y/n]: ");
    string? answer = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(answer) && !int.TryParse(answer, out int e) && (answer.StartsWith("y") || answer.StartsWith("n")))
        if (answer.StartsWith("y"))
        {
            Console.Clear();
            goto i_run_again;
        }
        else Environment.Exit(0);
    else
    {
        Console.WriteLine("Invalid");
        goto ask_again;
    }
} 
else
{ 
    Console.WriteLine("Invalid number format");
}

Console.ReadKey();
