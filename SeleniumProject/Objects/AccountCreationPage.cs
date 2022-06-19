using OpenQA.Selenium;


namespace SeleniumProject.Objects
{
    class AccountCreationPage
    {
        public static IWebElement SubmitAccountButton(IWebDriver driver)
        {
            return driver.FindElement(By.Name("SubmitCreate"));
        }

        public static IWebElement TitleRadioButton(IWebDriver driver)
        {
            return driver.FindElement(By.Id("id_gender2"));
        }

        public static IWebElement CheckedRadioButtonSpan(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("checked"));
        }

        public static IWebElement CustomerFirstNameField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("customer_firstname"));
        }

        public static IWebElement CustomerLastNameField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("customer_lastname"));
        }

        public static IWebElement EmailField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("email"));
        }

        public static IWebElement PasswordField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("passwd"));
        }

        public static IWebElement AddressFirstNameField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("firstname"));
        }

        public static IWebElement AddressLastNameField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("lastname"));
        }
    }
}
