using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace specflowTestFramework.commonFunctions
{
    class commonFunctions
    {
        //-----------------------------------------------------------------
        //   Function Name:  dynamicSync
        //   Description:    wait until page is in ready state
        //-----------------------------------------------------------------
        public static bool dynamicSync(IWebElement webElement, WebDriverWait dynamicWait)
        {
            try
            {
                bool syncCheck;
                syncCheck = dynamicWait.Until(d => (bool)(webElement as IWebElement).Displayed);
                return syncCheck;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:-" + e);
                return false;
            }
        }
    }
}
