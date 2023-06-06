using static System.Console;

namespace ZooManagementSystem
{
    public class VisitigSchedule
    {
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime DateTime { get; set; }
        public VisitigSchedule(DayOfWeek dayOfWeek, DateTime dateTime)
        {
            DayOfWeek = dayOfWeek;
            DateTime = dateTime;
        }

        public bool ZooSchedule()
        {   
            switch (DayOfWeek)
            {
                case DayOfWeek.Monday:
                    WriteLine("Sorry, we are closed today; the animals and their homes need some TLC");
                    return false;
                default:
                   return IsOpened();
            }
        }

        private static bool IsOpened()
        {
            DateTime dateTime = DateTime.Now;
            DateTime utcTime = dateTime.ToUniversalTime();
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("GTB Standard Time");

            DateTime yourLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, cstZone);
            var hour = yourLocalTime.Hour;

            switch (hour)
            {
                case int time when time < 9 || time > 20:
                    WriteLine("Sorry, you came outside of working hours...please visit us Tuesday to Sunday between 9:00 AM & 20:00 PM");
                    return false;
                case int time when time > 9 && time == 20:
                    WriteLine("Sorry, we're closed for today...please come again tomorrow from 9:00 AM");
                    return false;
                default:
                    WriteLine("\nThe Zoo is OPEN!");
                    return true;
            }
        }


    }
}
