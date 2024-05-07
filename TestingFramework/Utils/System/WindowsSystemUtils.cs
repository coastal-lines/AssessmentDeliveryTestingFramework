using TestingFramework.Core.Logging;
using System.Diagnostics;

namespace TestingFramework.Utils.System
{
    public class WindowsSystemUtils
    {
        #region Process

        public void CloseAllProcesses(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }

        public Process[] GetProcessesByName(string processName)
        {
            return Process.GetProcessesByName(processName);
        }

        public List<Process> GetListProcessesByName(string processName)
        {
            return new List<Process>(Process.GetProcessesByName(processName));
        }

        public List<int> GetListProcessesId(string processName)
        {
            return GetProcessesByName("chromedriver").Select(process => process.Id).ToList();
        }

        public string GetApplicationTopLevelWindowHandleHex(string processName, string windowTitle)
        {
            var currentProcesses = GetListProcessesByName(processName);
            var userProcess = currentProcesses.Where(process => process.MainWindowHandle.ToString() != "0" && process.MainWindowTitle.ToString().Contains(windowTitle)).ToList();
            var appTopLevelWindowHandle = userProcess[0].MainWindowHandle;
            var appTopLevelWindowHandleHex = appTopLevelWindowHandle.ToString("x");

            return appTopLevelWindowHandleHex;
        }

        /// <summary>
        /// p.StartInfo.Verb = "runas";
        /// Run as Administrator.
        /// </summary>
        public void StartProcess(string processPath)
        {
            var process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.FileName = processPath;
            process.StartInfo.Verb = "runas";
            process.Start();
        }

        public void WaitProcessStarted(string processName, int waitTime = 30)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            while (stopWatch.Elapsed.Seconds < waitTime)
            {
                Thread.Sleep(500);
                if (GetListProcessesByName(processName).Count > 0)
                {
                    stopWatch.Stop();
                    break;
                }
            }

            if (stopWatch.Elapsed.Seconds > waitTime)
            {
                stopWatch.Stop();

                Logger.LogError($"Process '{processName}' was not started after {waitTime} seconds.", new TimeoutException());
                throw new TimeoutException();
            }
        }

        #endregion

        #region CMD

        public string RunCmdScript(string arguments, bool waitForExit, bool waitForResponse, bool isHiddenProcess = false)
        {
            string output = null;
            string error = null;

            var processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = arguments
            };

            if (isHiddenProcess)
            {
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            }
            
            // Create a new process
            var process = new Process
            {
                StartInfo = processStartInfo
            };

            // Start the process
            process.Start();

            if (waitForResponse)
            {
                // Read the output and error streams
                output = process.StandardOutput.ReadToEnd();
                error = process.StandardError.ReadToEnd();
            }

            // Wait for the process to exit
            if (waitForExit)
            {
                process.WaitForExit();
            }

            return !string.IsNullOrEmpty(error) ? error : output;
        }

        #endregion
    }
}
