using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
//-----------------------------------------------------------------
//   Namespace:      Gumtree.PageObjects
//   Class:          Homepage
//   Description:    Class contains all objects and related operation for gumtree
//-----------------------------------------------------------------
namespace specflowTestFramework.Pages
{
    class gumtree
    {
        private IWebDriver driver;
        private string baseUrl;
        private WebDriverWait dynamicWait;
        //Constructor to initialise the driver
        public gumtree(IWebDriver browser)
        {
            this.driver = browser;
            this.baseUrl = "https://www.gumtree.com.au/";
            this.dynamicWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
        //Objects
        private readonly By pageLoaderElementBy = By.XPath("//body[@id='homenew']");
        public IWebElement pageLoaderElement => driver.FindElement(pageLoaderElementBy);

        private readonly By searchElementBy = By.XPath("//input[@id='search-query']");
        public IWebElement searchElement => driver.FindElement(searchElementBy);

        private readonly By searchButtonBy = By.XPath("//*[@id='search-form-form']//button");
        public IWebElement searchButton => driver.FindElement(searchButtonBy);

        private readonly By checkRowElementBy = By.XPath("//div[@class='user-ad-row__info']");
        public IWebElement checkRowElement => driver.FindElement(checkRowElementBy);

        private readonly By resultPerPageElementBy = By.XPath("//div[@class='results - per - page - selector']//select[@class='select__select']");
        public IWebElement resultPerPageElement => driver.FindElement(checkRowElementBy);

        private readonly By pageNumberElementBy = By.XPath("//div[@class='page - number - navigation']/a[contains(text(),'2')");
        public IWebElement pageNumberElement => driver.FindElement(pageNumberElementBy);

        private readonly By numberOfImagesButtonBy = By.XPath("//div[@class='page - number - navigation']/a[contains(text(),'2')");
        public IWebElement numberOfImagesButton => driver.FindElement(numberOfImagesButtonBy);

        private readonly By nextImageButtonBy = By.XPath("//button[@class='Button__button--2NsdC Button__buttonBasic--3CSBx undefined Button__buttonBase--3YR6h Button-main__button--3RLVh undefined vip-ad-gallery__nav-btn vip-ad-gallery__nav-btn--next']");
        public IWebElement nextImageButton => driver.FindElement(nextImageButtonBy);

        //Operations
        //----------------------------------------------------------------
        //   Function Name:  checkHomepage
        //   Description:    check if homepage is loaded
        //----------------------------------------------------------------
        public void checkHomepage()
        {
            try
            {
                driver.Navigate().GoToUrl(baseUrl);
                if (commonFunctions.commonFunctions.dynamicSync(pageLoaderElement, dynamicWait))
                    Assert.IsTrue(pageLoaderElement.Displayed, "Gumtreee home page is Loaded");
                Console.WriteLine("Gumtreee page load Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine("Gumtree page is not loaded + " + e);
            }
        }

        //----------------------------------------------------------------
        //   Function Name:  searchStr
        //   Description:    search for string value
        //----------------------------------------------------------------
        public void searchStr(String searchStr)
        {
            try
            {
                if (commonFunctions.commonFunctions.dynamicSync(searchElement, dynamicWait))
                    Assert.IsTrue(searchElement.Displayed, "search element is Loaded");
                if (searchElement.Displayed)
                    searchElement.SendKeys(searchStr);
                if (commonFunctions.commonFunctions.dynamicSync(searchButton, dynamicWait))
                    Assert.IsTrue(searchButton.Displayed, "search button is Loaded");
                if (searchButton.Displayed)
                    searchButton.Click();

                Console.WriteLine("Search completed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Search functionality failed + " + e);
            }
        }

        //----------------------------------------------------------------
        //   Function Name:  countObj
        //   Description:    Count objects in the page 
        //----------------------------------------------------------------
        public void countObj(int count)
        {
            try
            {
                if (commonFunctions.commonFunctions.dynamicSync(checkRowElement, dynamicWait))
                { 
                    Assert.IsTrue(checkRowElement.Displayed, "Search results are Loaded");
                    Assert.AreEqual(count, driver.FindElements(checkRowElementBy).Count, "Check on results row count");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Results were not loaded or count didn't match + " + e);
            }
        }
        //----------------------------------------------------------------
        //   Function Name:  verifyResultElement
        //   Description:    verify results elemnt 
        //----------------------------------------------------------------
        public void verifyResultElement()
        {
            try
            {
                if (commonFunctions.commonFunctions.dynamicSync(resultPerPageElement, dynamicWait))
                    Assert.IsTrue(resultPerPageElement.Displayed, "result page number");
            }
            catch (Exception e)
            {
                Console.WriteLine("Results page number element not found + " + e);
            }
        }

    }
}