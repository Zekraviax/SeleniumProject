using OpenQA.Selenium;


namespace SeleniumProject.Objects
{
    public class HomePage
    {
        public static IWebElement LoginButton(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("login"));
        }
    }
}
