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

        public static IWebElement FirstAddressLineField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("address1"));
        }

        public static IWebElement CityField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("city"));
        }

        public static IWebElement StateDropdown(IWebDriver driver)
        {
            return driver.FindElement(By.Name("id_state"));
        }

        public static IWebElement PostalCodeField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("postcode"));
        }

        public static IWebElement MobileNumberField(IWebDriver driver)
        {
            return driver.FindElement(By.Name("phone_mobile"));
        }
    }
}
