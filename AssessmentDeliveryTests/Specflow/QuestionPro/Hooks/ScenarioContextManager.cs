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
    }
}
