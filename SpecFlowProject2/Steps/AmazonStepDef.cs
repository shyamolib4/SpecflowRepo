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


       /* [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Pending();
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Pending();
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            _scenarioContext.Pending();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            _scenarioContext.Pending();
        }*/
    }
}
