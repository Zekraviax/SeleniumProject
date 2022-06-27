using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumProject.Objects;
using System;

namespace SeleniumProject
{
    public class TC3_Orders1
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            DriverUtilities myDriverUtilities = new DriverUtilities();
            driver = myDriverUtilities.GetDriver();

            // Put 6 orders on an account
            // Login
            driver.Navigate().GoToUrl(DataFile.loginURL);
            var loginButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            loginButtonWait.Until(ExpectedConditions.ElementIsVisible(By.Id("submitLogin")));

            LoginPage.EmailLoginField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.PasswordLoginField(driver).SendKeys(DataFile.password);
            LoginPage.SubmitLoginButton(driver).Click();

            var logoutButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            logoutButtonWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("logout")));

            // Order
            AccountPage.TShirtsLink(driver).Click();
            for (int i = 0; i < 6; i++)
            {
                AccountPage.TShirtsLink(driver).Click();

                var tshirtsPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                tshirtsPageWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ajax_add_to_cart")));
                TShirtsPage.AddToCartLink(driver).Click();

                var checkoutButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                checkoutButtonWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a")));
                DressesPage.CheckoutButton(driver).Click();

                var orderSummaryPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                orderSummaryPageWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("cart_quantity_delete")));
                ShoppingCartPage.ProceedToCheckoutButton(driver).Click();

                var selectAddressPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                selectAddressPageWait.Until(ExpectedConditions.ElementIsVisible(By.Id("id_address_delivery")));
                ShoppingCartPage.ProceedToCheckoutButton(driver).Click();

                var shippingOptionsPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                shippingOptionsPageWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("delivery_option_radio")));
                ShoppingCartPage.TermsOfServiceCheckbox(driver).Click();
                ShoppingCartPage.ProceedToCheckoutButton(driver).Click();

                // alternate between bank-wires and check payments
                var paymentOptionsPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                paymentOptionsPageWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("payment_module")));
                ShoppingCartPage.BankwirePaymentOption(driver).Click();
                if (i % 2 == 0) {
                    var bankwirePaymentPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    bankwirePaymentPageWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Bank-wire payment')]")));

                    ShoppingCartPage.ConfirmOrderButton(driver).Click();
                } else {
                    var checkPaymentPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    checkPaymentPageWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Check payment')]")));

                    ShoppingCartPage.ConfirmOrderButton(driver).Click();
                }

                // go back to the start
                var accountPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                accountPageWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'My account')]")));
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [Test, Order(1)]
        public void CountAmountOfPaymentsAndOutputToConsole()
        {
            // should already be at the account page
            AccountPage.OrderHistoryLink(driver).Click();

            // get all orders
            // output number of elements to console
            Console.WriteLine("Orders found: " + AccountPage.AllOrders(driver).Count);

            Assert.AreEqual(6, AccountPage.AllOrders(driver).Count);
        }

        [Test, Order(2)]
        public void GetTotalAmountSpentOnChequePayments()
        {
            float runningTotal = 0.0f;

            // should be at the order history page
            // get all table entries and filter out non-cheque payments
            var TableRows = driver.FindElements(By.TagName("tr"));

            foreach (var Row in TableRows)
            {
                var RowTds = Row.FindElements(By.TagName("td"));
                var HistoryMethodClass = Row.FindElement(By.ClassName("history-method"));
                var HistoryPriceClass = Row.FindElement(By.ClassName("history-price"));

                Console.WriteLine("History Method: " + HistoryMethodClass.GetAttribute("value"));

                if (HistoryMethodClass.GetAttribute("value").Contains("check"))
                {
                    runningTotal += float.Parse(HistoryPriceClass.GetAttribute("value"));
                }

                /*
                foreach(var td in RowTds)
                {
                    if (td.GetCssValue("").Contains("check"))
                    {

                    }
                
                }
                */
            }

            // Assert
        }

        [Test, Order(3)]
        public void GetTotalAmountSpentOnBankwirePayments()
        {
            var TableRows = driver.FindElements(By.TagName("tr"));

            foreach (var Row in TableRows)
            {
                var HistoryMethodClass = Row.FindElement(By.ClassName("history-method"));

                Console.WriteLine("History Method: " + HistoryMethodClass.GetAttribute("value"));
            }
        }
    }
}