namespace TestingFramework.Utils
{
    public static class WindowsEnvironmentUtils
    {
        public static string GetUserSystemPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }
    }
}