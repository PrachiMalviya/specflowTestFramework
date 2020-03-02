using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace specflowTestFramework.steps
{
    [Binding]
    public class GumtreeSearchSteps
    {
        private IWebDriver _driver;

        public GumtreeSearchSteps(IWebDriver driver) => _driver = driver;
        Pages.gumtree gumtreeObj;

        [Given(@"I navigate to gumtree homepage")]
        public void GivenINavigateToGumtreeHomepage()
        {
            gumtreeObj = new Pages.gumtree(_driver);
            gumtreeObj.checkHomepage();
        }
        
        [Given(@"I search for '(.*)'")]
        public void GivenISearchFor(String searchStr)
        {
            gumtreeObj.searchStr(searchStr);
        }
        
        [Given(@"I count number of results match '(.*)'")]
        public void GivenICountNumberOfResultsMatch(int count)
        {
            gumtreeObj.countObj(count);
        }
        
        [Then(@"I find the label that show number of results")]
        public void ThenIFindTheLabelThatShowNumberOfResults()
        {
            gumtreeObj.verifyResultElement();
        }
    }
}
