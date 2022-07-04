using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumProject.StepDefinitionFiles
{
    [Binding]
    public sealed class PurchaseStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public PurchaseStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public void Setup()
        {
            //PicoContainer 
        }


        // Defaults
        //[Given("the first number is (.*)")]
        //public void GivenTheFirstNumberIs(int number)
        //{
        //    //TODO: implement arrange (precondition) logic
        //    // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
        //    // To use the multiline text or the table argument of the scenario,
        //    // additional string/Table parameters can be defined on the step definition
        //    // method. 

        //    _scenarioContext.Pending();
        //}

        //[Given("the second number is (.*)")]
        //public void GivenTheSecondNumberIs(int number)
        //{
        //    //TODO: implement arrange (precondition) logic
        //    // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
        //    // To use the multiline text or the table argument of the scenario,
        //    // additional string/Table parameters can be defined on the step definition
        //    // method. 

        //    _scenarioContext.Pending();
        //}

        //[When("the two numbers are added")]
        //public void WhenTheTwoNumbersAreAdded()
        //{
        //    //TODO: implement act (action) logic

        //    _scenarioContext.Pending();
        //}

        //[Then("the result should be (.*)")]
        //public void ThenTheResultShouldBe(int result)
        //{
        //    //TODO: implement assert (verification) logic

        //    _scenarioContext.Pending();
        //}


        // Purchase test
        [Given("a user is signed in to the AutomationPractice website with email (.*) and password (.*)")]
        public void GivenAUserIsSignedIntoTheAutomationPracticeWebsite(string email, string password)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Pending();
        }
    }
}
