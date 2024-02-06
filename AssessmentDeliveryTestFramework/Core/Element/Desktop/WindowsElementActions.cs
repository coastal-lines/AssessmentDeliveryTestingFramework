using System.Runtime.InteropServices.ComTypes;

namespace AssessmentDeliveryTestingFramework.Core.Element.Desktop
{
    public class WindowsElementActions
    {
        #region Windows actions



        /*
        public void WindowsCtrlA()
        {
            SendKeys.SendWait("^{A}");
        }

        public void WindowsCtrlC()
        {
            SendKeys.SendWait("^{C}");
        }

        public void WindowsCtrlV()
        {
            SendKeys.SendWait("^{V}");
        }

        public void CopyToWindowsClipboard()
        {
            WindowsCtrlA();
            Thread.Sleep(100);
            WindowsCtrlC();
            Thread.Sleep(1000);
        }

        public string PastFromWindowsClipboard()
        {
            var text = "";
            text = Clipboard.GetText(TextDataFormat.Text);

            if (text == "")
            {
                IDataObject idat = null;
                Exception threadEx = null;

                Thread staThread = new Thread(
                    delegate ()
                    {
                        try
                        {
                            idat = Clipboard.GetDataObject();
                            text = (string)idat.GetData(DataFormats.Text);
                        }

                        catch (Exception ex)
                        {
                            threadEx = ex;
                        }
                    });
                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start();
                staThread.Join();
            }

            return text;
        }

        */

        #endregion
    }
}
