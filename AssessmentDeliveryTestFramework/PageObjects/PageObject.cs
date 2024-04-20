using AssessmentDeliveryTestingFramework.Core;
using AssessmentDeliveryTestingFramework.Core.Session;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AssessmentDeliveryTestingFramework.Page
{
    public class PageObject
    {
        private DesktopSession _session;

        public DesktopSession Session => _session;
    }
}
