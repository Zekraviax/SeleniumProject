using OpenQA.Selenium;


namespace SeleniumProject.Objects
{
    class AccountCreationPage
    {
        public static IWebElement SubmitAccountButton(IWebDriver driver)
        {
            return driver.FindElement(By.Name("SubmitCreate"));
        }
    }
}
