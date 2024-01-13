namespace AssessmentDeliveryTestingFramework.Utils
{
    public class DirectoryUtils
    {
        public List<string> GetListFilesFromDirectory(string path)
        {
            var directory = new DirectoryInfo(path);

            var listFiles = directory.GetFiles().Select(file => file.Name).ToList();

            return listFiles;
        }
    }
}
