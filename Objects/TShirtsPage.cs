using OpenQA.Selenium;

namespace SeleniumProject.Objects
{
    class TShirtsPage
    {
        public static IWebElement TShirtsItem(IWebDriver driver)
        {
            return driver.FindElement(By.PartialLinkText("T-shirts"));
        }

        public static IWebElement AddToCartLink(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div[2]/ul/li/div/div[2]/div[2]/a[1]"));
        }

        public static IWebElement ContinueShoppingButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/span"));
        }
    }
}
