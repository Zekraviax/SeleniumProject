using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumProject.Objects;
using System;


namespace SeleniumProject.Tests
{
    class RegistrationTests
    {
        IWebDriver driver;

        [SetUp]
        public void Initialise()
        {
            DriverUtilities myDriverUtilities = new DriverUtilities();
            driver = myDriverUtilities.GetDriver();
        }

        [TearDown]
        public void End()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [Test]
        public void ClickSignInButton()
        {
            // Go to website
            driver.Navigate().GoToUrl(DataFile.homePageURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Interact with sign in button
            HomePage.LoginButton(driver).Click();

            // Search for an element that indicates this is the 'sign in' page
            Assert.NotNull(LoginPage.SubmitLoginButton(driver));
        }

        [Test]
        public void EnterValidEmailAddress()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            LoginPage.EmailField(driver).SendKeys(DataFile.emailAddress);

            Assert.AreEqual(LoginPage.EmailField(driver).GetAttribute("value"), DataFile.emailAddress);
        }

        [Test]
        public void CreateAnAccount()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            LoginPage.EmailField(driver).SendKeys(DataFile.emailAddress);

            LoginPage.SubmitCreateAccountButton(driver).Click();
        }

        [Test]
        public void CheckTitleRadioButton()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            AccountCreationPage.TitleRadioButton(driver).Click();

            Assert.NotNull(AccountCreationPage.CheckedRadioButtonSpan(driver));
        }

        [Test]
        public void EnterFirstName()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            AccountCreationPage.CustomerFirstNameField(driver).SendKeys(DataFile.firstName);

            Assert.AreEqual(AccountCreationPage.CustomerFirstNameField(driver).GetAttribute("value"), DataFile.firstName);
        }

        [Test]
        public void EnterLastNameAndCheckEmailAutopopulated()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            AccountCreationPage.CustomerLastNameField(driver).SendKeys(DataFile.lastName);

            Assert.AreEqual(AccountCreationPage.CustomerLastNameField(driver).GetAttribute("value"), DataFile.lastName);
            Assert.AreEqual(AccountCreationPage.EmailField(driver).GetAttribute("value"), DataFile.emailAddress);
        }

        [Test]
        public void EnterPasswordAndCheckFirstNameAndLastNameAutopopulated()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("account-creation_form")));
            AccountCreationPage.PasswordField(driver).SendKeys(DataFile.password);

            // Check for password length
            Assert.AreEqual(AccountCreationPage.PasswordField(driver).GetAttribute("value").Length, DataFile.password.Length);

            // check for auto-filled first and last name
            Assert.AreEqual(AccountCreationPage.AddressFirstNameField(driver).GetAttribute("value"), DataFile.firstName);
            Assert.AreEqual(AccountCreationPage.AddressLastNameField(driver).GetAttribute("value"), DataFile.lastName);
        }
    }
}