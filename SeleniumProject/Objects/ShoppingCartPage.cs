using OpenQA.Selenium;

namespace SeleniumProject.Objects
{
    class ShoppingCartPage
    {
        public static IWebElement ShoppingCartHeader(IWebDriver driver)
        {
            return driver.FindElement(By.Id("cart_title"));
        }

        public static IWebElement ProceedToCheckoutButton(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("standard_checkout"));
        }

        public static IWebElement DeliveryAddressDropdown(IWebDriver driver)
        {
            return driver.FindElement(By.Id("id_address_delivery"));
        }

        public static IWebElement DeliveryOptionRadio(IWebDriver driver)
        {
            return driver.FindElement(By.Id("delivery_option_radio"));
        }

        public static IWebElement TermsOfServiceCheckbox(IWebDriver driver)
        {
            return driver.FindElement(By.Id("uniform-cgv"));
        }

        // Bankwire payments
        public static IWebElement BankwirePaymentOption(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("bankwire"));
        }

        public static IWebElement BankwirePaymentSubheading(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//*[contains(text(), 'Bank-wire payment.')]"));
        }

        public static IWebElement ConfirmOrderButton(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("button_medium"));
        }

        public static IWebElement OrderConfirmationHeading(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//*[contains(text(), 'Bank-wire payment')]"));
        }

        public static IWebElement BackToOrdersLink(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("cart_navigation"));
        }

        public static IWebElement OrderHistoryLink(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("history_link"));
        }

        // Cheque payments
        public static IWebElement ChequePaymentLink(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("cheque"));
        }
    }
}
