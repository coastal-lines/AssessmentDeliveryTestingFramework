using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace QuestionProTests.Hooks
{
    [Binding]
    internal class ScenarioContextManager
    {
        private ScenarioContext _scenarioContext;

        public ScenarioContextManager(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public void SetContextValue(string key, object value)
        {
            _scenarioContext[key] = value;
        }

        public T GetContextValue<T>(string key)
        {
            return _scenarioContext.Get<T>(key);
        }
    }
}
