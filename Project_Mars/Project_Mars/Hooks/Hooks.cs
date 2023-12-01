using Project_Mars.Utilities;
using TechTalk.SpecFlow;

namespace Project_Mars.Hooks
{
    [Binding]
    public sealed class Hooks:CommonDriver
    {
        

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            Initialize();
        }

        
        [AfterScenario]
        public void AfterScenario()
        {
            Close();
        }
    }
}