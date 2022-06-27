using OpenQA.Selenium;


namespace SeleniumProject.Objects
{
    public class LoginPage
    {
        public static IWebElement EmailCreateField(IWebDriver driver)
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

        public static IWebElement EmailLoginField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("email"));
        }

        public static IWebElement PasswordLoginField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("passwd"));
        }

        public static IWebElement ForgottenPasswordLink(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//*[text()='Forgot your password?']"));
        }
    }
}
