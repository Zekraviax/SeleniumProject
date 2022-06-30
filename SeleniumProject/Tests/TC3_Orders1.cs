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
            driver.Manage().Window.Maximize();

            // Put 6 orders on an account
            // Login
            driver.Navigate().GoToUrl(DataFile.loginURL);

            var loginButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            loginButtonWait.Until(ExpectedConditions.ElementIsVisible(By.Id("SubmitLogin")));

            LoginPage.EmailLoginField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.PasswordLoginField(driver).SendKeys(DataFile.password);
            LoginPage.SubmitLoginButton(driver).Click();

            var logoutButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            logoutButtonWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("logout")));

            AccountPage.OrderHistoryLink(driver).Click();
            var orderHistoryPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            orderHistoryPageWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("item")));

            // Order
            //AccountPage.TShirtsLink(driver).Click();
            //for (int i = 0; i < 6; i++)
            //{
            //    AccountPage.TShirtsLink(driver).Click();

            //    var tshirtsPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //    tshirtsPageWait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("ajax_add_to_cart_button")));
            //    TShirtsPage.AddToCartLink(driver).Click();

            //    var checkoutButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //    checkoutButtonWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a")));
            //    DressesPage.CheckoutButton(driver).Click();

            //    var orderSummaryPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //    orderSummaryPageWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("cart_quantity_delete")));
            //    ShoppingCartPage.ProceedToCheckoutButton(driver).Click();

            //    var selectAddressPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //    selectAddressPageWait.Until(ExpectedConditions.ElementIsVisible(By.Id("uniform-id_address_delivery")));
            //    ShoppingCartPage.ProcessAddressCheckoutButton(driver).Click();

            //    var shippingOptionsPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //    shippingOptionsPageWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("delivery_option_radio")));
            //    ShoppingCartPage.TermsOfServiceCheckbox(driver).Click();
            //    ShoppingCartPage.ProceedToCheckoutButton(driver).Click();

            //    // alternate between bank-wires and check payments
            //    var paymentOptionsPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //    paymentOptionsPageWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("payment_module")));
            //    if (i % 2 == 0) {
            //        ShoppingCartPage.BankwirePaymentOption(driver).Click();

            //        var bankwirePaymentPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //        bankwirePaymentPageWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Bank-wire payment')]")));

            //        ShoppingCartPage.ConfirmOrderButton(driver).Click(); // here
            //    } else {
            //        ShoppingCartPage.ChequePaymentLink(driver).Click();

            //        var checkPaymentPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //        checkPaymentPageWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Check payment')]")));

            //        ShoppingCartPage.ConfirmOrderButton(driver).Click();
            //    }

            //    // go back to the start
            //    var accountPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //    accountPageWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'My account')]")));
            //}
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
            // get all orders
            // output number of elements to console
            //Console.WriteLine("Orders found: " + AccountPage.AllOrders(driver).Count);
            //Assert.AreEqual(6, AccountPage.AllOrders(driver).Count);

            string consoleMessage = "Orders found: " + AccountPage.AllOrders(driver).Count;
            //string foundLog = "";

            //Console.WriteLine(consoleMessage);
            System.Diagnostics.Debug.WriteLine(consoleMessage);

            //var consoleLogs = driver.Manage().Logs.GetLog(LogType.Browser);
            //foreach (LogEntry log in consoleLogs)
            //{
            //    Console.WriteLine(log.ToString());

            //    if (log.ToString() == consoleMessage)
            //    {
            //        foundLog = log.ToString();
            //    }
            //}

            Assert.AreEqual(consoleMessage, "Orders found: 6");
        }

        [Test, Order(2)]
        public void GetTotalAmountSpentOnChequePayments()
        {
            // The account six_smith@gmail.com has six transactions:
            // A single t-shirt totaling $18.51
            // Therefore, the expected total is $55.53
            float runningTotal = 0.0f;

            // should be at the order history page
            // get all table entries and filter out non-cheque payments
            var TableRows = driver.FindElements(By.TagName("tr"));

            foreach (IWebElement Row in TableRows)
            {
                var RowTds = Row.FindElements(By.TagName("td"));
                IWebElement HistoryMethodClass = null;
                IWebElement HistoryPriceClass = null;

                foreach (IWebElement Td in RowTds)
                {
                    if (Td.GetAttribute("class") == "history_price")
                    {
                        HistoryPriceClass = Td;
                    } else if (Td.GetAttribute("class") == "history_method")
                    {
                        HistoryMethodClass = Td;
                    }
                }

                if (HistoryPriceClass != null && HistoryMethodClass != null)
                {
                    if (HistoryMethodClass.Text.Contains("check"))
                    {
                        string AmountAsString = HistoryPriceClass.Text.Replace("$", "");
                        //System.Diagnostics.Debug.WriteLine(AmountAsString);
                        runningTotal += float.Parse(AmountAsString);
                    }
                }
            }

            string consoleMessage = "Total amount spent by cheque: $" + runningTotal.ToString();
            //System.Diagnostics.Debug.WriteLine(consoleMessage);

            Assert.AreEqual(consoleMessage, "Total amount spent by cheque: $55.53");
        }

        [Test, Order(3)]
        public void GetTotalAmountSpentOnBankwirePayments()
        {
            float runningTotal = 0.0f;
            var TableRows = driver.FindElements(By.TagName("tr"));

            foreach (IWebElement Row in TableRows)
            {
                var RowTds = Row.FindElements(By.TagName("td"));
                IWebElement HistoryMethodClass = null;
                IWebElement HistoryPriceClass = null;

                foreach (IWebElement Td in RowTds)
                {
                    if (Td.GetAttribute("class") == "history_price")
                    {
                        HistoryPriceClass = Td;
                    }
                    else if (Td.GetAttribute("class") == "history_method")
                    {
                        HistoryMethodClass = Td;
                    }
                }

                if (HistoryPriceClass != null && HistoryMethodClass != null)
                {
                    if (HistoryMethodClass.Text.Contains("wire"))
                    {
                        string AmountAsString = HistoryPriceClass.Text.Replace("$", "");
                        runningTotal += float.Parse(AmountAsString);
                    }
                }
            }

            string consoleMessage = "Total amount spent by bankwire: $" + runningTotal.ToString();

            Assert.AreEqual(consoleMessage, "Total amount spent by bankwire: $55.53");
        }
    }
}