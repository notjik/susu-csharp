namespace Lab5
{
    public static class TimeFormat
    {
        public static string GetTimeFormatted(int minutes)
        {
            int hours = minutes / 60;
            int remainingMinutes = minutes % 60;

            string hourText = GetHourText(hours);

            string minuteText = GetMinuteText(remainingMinutes);

            return $"{(hours > 0 ? $"{hours} {hourText}" : "")} {remainingMinutes} {minuteText}".Trim();
        }

        static string GetHourText(int hours)
        {
            if (hours == 1)
                return "час";
            if (hours >= 2 && hours <= 4)
                return "часа";
            return "часов";
        }

        static string GetMinuteText(int minutes)
        {
            if (minutes == 1)
                return "минута";
            if (minutes >= 2 && minutes <= 4)
                return "минуты";
            return "минут";
        }
    }
}