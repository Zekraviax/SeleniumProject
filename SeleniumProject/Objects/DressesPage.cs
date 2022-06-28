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
            return driver.FindElement(By.ClassName("ajax_add_to_cart_button"));
        }

        public static IWebElement CheckoutButton(IWebDriver driver)
        {
            return driver.FindElement(By.PartialLinkText("Proceed to checkout"));
        }

        public static IWebElement ShoppingCartPopup(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("ajax_cart_product_txt_s"));
        }
    }
}
