using OpenQA.Selenium;

namespace SeleniumProject.Objects
{
    class AccountPage
    {
        public static IWebElement LogoutButton(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("logout"));
        }
    }
}
