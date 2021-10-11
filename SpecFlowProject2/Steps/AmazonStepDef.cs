using TechTalk.SpecFlow;
using UI_Automation;

namespace SpecFlowProject2.Steps
{
    [Binding]
    public sealed class AmazonStepDef
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public AmazonStepDef(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        [Given("We are on the Amazon website")]
        public void Startup()
        {
            Utilities.IntitializeDriver();
            System.IO.Directory.CreateDirectory(Utilities.LogFolder);
            Utilities.Log("***********************************************************START of test case***********************************************************");
            Scenarios.Login();
        }

        [When("We search for a Television and Add to Cart")]
        public void TestMethod2()
        {
            Scenarios.AddToCart();
        }

        [Then("We verify the added item and logout")]
        public void TearDown()
        {
            Scenarios.Logout();
            Utilities.WebDriver.Quit();
            Utilities.Log("***********************************************************END of test case************************************************************");
        }
    }
}
