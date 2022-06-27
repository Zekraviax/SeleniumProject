using OpenQA.Selenium;

namespace SeleniumProject.Objects
{
    class DressesPage
    {
        public static IWebElement CasualDressesLink(IWebDriver driver)
        {
            return driver.FindElement(By.PartialLinkText("Casual Dresses"));
        }

        public static IWebElement AddToCartLink(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div[2]/ul/li[1]/div/div[2]/div[2]/a[1]"));
        }

        public static IWebElement CheckoutButton(IWebDriver driver)
        {
            return driver.FindElement(By.PartialLinkText("Proceed to checkout"));
        }

        public static IWebElement ShoppingCartPopup(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//*[text()='There are 2 items in your cart']"));
        }
    }
}
