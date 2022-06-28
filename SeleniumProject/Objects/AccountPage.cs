using OpenQA.Selenium;

namespace SeleniumProject.Objects
{
    class AccountPage
    {
        public static IWebElement LogoutButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[2]/div/div/nav/div[2]/a"));
        }

        public static IWebElement TShirtsLink(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/ html / body / div / div[1] / header / div[3] / div / div / div[6] / ul / li[3] / a"));
        }

        public static IWebElement DressesLink(IWebDriver driver)
        {
            //return driver.FindElement(By.LinkText("Dresses"));
            return driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[6]/ul/li[2]/a"));
        }

        // TC3
        public static IWebElement OrderHistoryLink(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[1]/ul/li[1]/a"));
        }

        public static System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> AllOrders(IWebDriver driver)
        {
            return driver.FindElements(By.PartialLinkText("PDF"));
        }
    }
}
