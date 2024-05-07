namespace AssessmentDeliveryTestingFramework.Core.Driver.PlatformUtils
{
    public interface IPlatformDriverUtils
    {
        void TerminateProcess(string processName);

        List<int> GetDriversProcessesId(string browserType);
    }
}