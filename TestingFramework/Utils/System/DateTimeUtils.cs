namespace TestingFramework.Utils.System
{
    public static class DateTimeUtils
    {
        public static string GetCurrentDate()
        {
            return DateTime.Now.ToString("yy:MM:dd");
        }
    }
}
