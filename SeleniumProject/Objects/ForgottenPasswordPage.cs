using OpenQA.Selenium;

namespace SeleniumProject.Objects
{
    class ForgottenPasswordPage
    {
        public static IWebElement RetrievePasswordButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//*[text()='Retrieve Password']"));
        }

        public static IWebElement EmailField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("email"));
        }

        public static IWebElement SuccessAlert(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("alert-success"));
        }

        public static IWebElement ReturnToLoginButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/ul/li/a"));
        }
    }
}
