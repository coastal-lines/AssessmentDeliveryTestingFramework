using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace TestingFramework.Core.TestManagement.Extensions.NUnit
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
    public class BrowserTypeAttribute : NUnitAttribute, IApplyToTest
    {
        public BrowserTypeAttribute(string name) => Name = name.Trim();

        public string Name { get; }

        public void ApplyToTest(Test test)
        {
            test.Properties.Add("Category", Name);
            test.Properties.Add("BrowserType", Name);
        }
    }
}
