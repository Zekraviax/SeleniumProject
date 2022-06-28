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
            return driver.FindElement(By.ClassName("ajax_add_to_cart_button"));
        }

        public static IWebElement ContinueShoppingButton(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("continue"));
        }
    }
}
