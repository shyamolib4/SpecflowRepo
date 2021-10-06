using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using UI_Automation;

namespace SpecFlowProject1
{
    
    [Binding]
    public sealed class AmazonStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        
            public AmazonStepDefinition(ScenarioContext scenarioContext)
            {
                _scenarioContext = scenarioContext;
            }

            /*[TestInitialize]
             public void Startup2()
             {
            
                 Utilities.IntitializeDriver();
                 System.IO.Directory.CreateDirectory(Utilities.LogFolder);
                 Utilities.Log("***********************************************************START of test case***********************************************************");
                 Scenarios.Login();
             }*/

            [Given("We are on Amazon website")]
            public void Startup()
            {
             Utilities.IntitializeDriver();
             System.IO.Directory.CreateDirectory(Utilities.LogFolder);
             Utilities.Log("***********************************************************START of test case***********************************************************");
             Scenarios.Login();
            Utilities.Log("Entered startup method");
             }

       
            [When("We search for Television")]
            public void TestMethod2()
            {
                Scenarios.AddToCart();
            }

            [Then("We successfully add an item and logoff")]
            public void TearDown()
            {
                Scenarios.Logout();
                Utilities.WebDriver.Quit();
                Utilities.Log("***********************************************************END of test case************************************************************");
            }
        }

      
    }

