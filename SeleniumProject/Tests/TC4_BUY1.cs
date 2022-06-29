using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumProject.Objects;
using System;

namespace SeleniumProject
{
    class TC4_BUY1
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            DriverUtilities myDriverUtilities = new DriverUtilities();
            driver = myDriverUtilities.GetDriver();
            driver.Manage().Window.Maximize();

            // User needs to be signed in
            driver.Navigate().GoToUrl(DataFile.homePageURL);
            HomePage.LoginButton(driver).Click();

            // wait for login form first
            var loginFormWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            loginFormWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("form_content")));

            LoginPage.EmailLoginField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.PasswordLoginField(driver).SendKeys(DataFile.password);
            LoginPage.SubmitLoginButton(driver).Click();

            var loginWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            loginWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("logout")));
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
        public void ClickTShirtsLink()
        {
            AccountPage.TShirtsLink(driver).Click();

            var tshirtsPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            tshirtsPageWait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText("T-shirts")));

            Assert.NotNull(TShirtsPage.TShirtsItem(driver));
        }

        [Test, Order(2)]
        public void AddTShirtToCart()
        {
            TShirtsPage.AddToCartLink(driver).Click();

            var continueShoppingWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            continueShoppingWait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("button-medium")));

            Assert.NotNull(TShirtsPage.ContinueShoppingButton(driver));
        }

        [Test, Order(3)]
        public void ClickContinueShoppingButton()
        {
            TShirtsPage.ContinueShoppingButton(driver).Click();

            var dressesButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            dressesButtonWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[6]/ul/li[2]/a")));

            Assert.NotNull(TShirtsPage.TShirtsItem(driver));
        }

        [Test, Order(4)]
        public void ClickDressesButton()
        {
            AccountPage.DressesLink(driver).Click();

            // insert wait here
            var addToCartButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            addToCartButtonWait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("compare-form")));

            Assert.NotNull(DressesPage.CasualDressesLink(driver));
        }

        [Test, Order(5)]
        public void AddDressToCart()
        {
            DressesPage.AddToCartLink(driver).Click();

            var checkoutWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            checkoutWait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText("Proceed to checkout")));

            // check that 2 items are in the cart
            Assert.NotNull(DressesPage.ShoppingCartPopup(driver));
        }

        [Test, Order(6)]
        public void ProceedToCheckout()
        {
            DressesPage.CheckoutButton(driver).Click();

            var orderSummaryPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            orderSummaryPageWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("cart_quantity_delete")));

            Assert.NotNull(DressesPage.CheckoutButton(driver));
        }

        [Test, Order(7)]
        public void ProceedToAddressPage()
        {
            ShoppingCartPage.ProceedToCheckoutButton(driver).Click();

            var selectAddressPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            selectAddressPageWait.Until(ExpectedConditions.ElementIsVisible(By.Id("uniform-id_address_delivery")));

            Assert.NotNull(ShoppingCartPage.DeliveryAddressDropdown(driver));
        }

        [Test, Order(8)]
        public void ProceedToShippingPage()
        {
            ShoppingCartPage.ProcessAddressCheckoutButton(driver).Click();

            var shippingOptionsPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            shippingOptionsPageWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("delivery_option_radio")));

            Assert.NotNull(ShoppingCartPage.DeliveryOptionRadio(driver));
        }

        [Test, Order(9)]
        public void CheckTermsAndConditionsBox()
        {

            ShoppingCartPage.TermsOfServiceCheckbox(driver).Click();

            // wait?
            var shippingOptionsPageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));
            shippingOptionsPageWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("delivery_option_radio")));

            Assert.NotNull(driver.FindElement(By.ClassName("checked")));
        }

        [Test, Order(10)]
        public void ProceedToPaymentChoice()
        {
            ShoppingCartPage.ProceedToCheckoutButton(driver).Click();

            Assert.NotNull(ShoppingCartPage.BankwirePaymentOption(driver));
        }

        [Test, Order(11)]
        public void SelectBankwirePaymentOption()
        {
            ShoppingCartPage.BankwirePaymentOption(driver).Click();

            Assert.NotNull(ShoppingCartPage.BankwirePaymentSubheading(driver));
        }

        [Test, Order(12)]
        public void ConfirmOrder()
        {
            ShoppingCartPage.ConfirmOrderButton(driver).Click();

            Assert.NotNull(ShoppingCartPage.OrderConfirmationHeading(driver));
        }

        [Test, Order(13)]
        public void GoToOrderHistoryPage()
        {
            ShoppingCartPage.BackToOrdersLink(driver).Click();

            Assert.NotNull(ShoppingCartPage.OrderHistoryLink(driver));
        }
    }
}
