using OpenQA.Selenium;


namespace SeleniumProject.Objects
{
    public class LoginPage
    {
        public static IWebElement EmailField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("email_create"));
        }

        public static IWebElement SubmitLoginButton(IWebDriver driver)
        {
            return driver.FindElement(By.Name("SubmitLogin"));
        }

        public static IWebElement SubmitCreateAccountButton(IWebDriver driver)
        {
            return driver.FindElement(By.Name("SubmitCreate"));
        }
    }
}
