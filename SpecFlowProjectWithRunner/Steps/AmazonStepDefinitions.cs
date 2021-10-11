using TechTalk.SpecFlow;
using UI_Automation;

namespace SpecFlowProjectWithRunner.Steps
{
    [Binding]
    public sealed class AmazonStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public AmazonStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("We are on Amazon website and login")]
        public void GivenTheFirstNumberIs()
        {
            Utilities.IntitializeDriver();
        }

        [Then("We verify user and logout")]
        public void ThenTheResultShouldBe()
        {
            Utilities.WebDriver.Quit();
        }
    }
}
