using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers
{
    public interface IDriverContainer
    {
        object Driver { get; }
        string Name { get; }
        string Platform { get; }
        string CurrentTestType { get; }
    }
}
