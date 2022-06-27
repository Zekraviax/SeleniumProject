using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumProject.Objects;
using System;


namespace SeleniumProject
{
    class TC1_Reg1
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

        [Test, Order(1)]
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

        [Test, Order(2)]
        public void EnterValidEmailAddress()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);

            Assert.AreEqual(LoginPage.EmailCreateField(driver).GetAttribute("value"), DataFile.emailAddress);
        }

        [Test, Order(3)]
        public void ClickCreateAccountButton()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);

            LoginPage.SubmitCreateAccountButton(driver).Click();
        }

        [Test, Order(4)]
        public void CheckTitleRadioButton()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            AccountCreationPage.TitleRadioButton(driver).Click();

            Assert.NotNull(AccountCreationPage.CheckedRadioButtonSpan(driver));
        }

        [Test, Order(5)]
        public void EnterFirstName()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            AccountCreationPage.CustomerFirstNameField(driver).SendKeys(DataFile.firstName);

            Assert.AreEqual(AccountCreationPage.CustomerFirstNameField(driver).GetAttribute("value"), DataFile.firstName);
        }

        [Test, Order(6)]
        public void EnterLastNameAndCheckEmailAutopopulated()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            AccountCreationPage.CustomerLastNameField(driver).SendKeys(DataFile.lastName);

            Assert.AreEqual(AccountCreationPage.CustomerLastNameField(driver).GetAttribute("value"), DataFile.lastName);
            Assert.AreEqual(AccountCreationPage.EmailField(driver).GetAttribute("value"), DataFile.emailAddress);
        }

        [Test, Order(7)]
        public void EnterPasswordAndCheckFirstNameAndLastNameAutopopulated()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);
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

        [Test, Order(8)]
        public void EnterValidAddress()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            AccountCreationPage.FirstAddressLineField(driver).SendKeys(DataFile.address);

            Assert.AreEqual(AccountCreationPage.FirstAddressLineField(driver).GetAttribute("value"), DataFile.address);
        }

        [Test, Order(9)]
        public void EnterValidCity()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            AccountCreationPage.CityField(driver).SendKeys(DataFile.city);

            Assert.AreEqual(AccountCreationPage.CityField(driver).GetAttribute("value"), DataFile.city);
        }

        [Test, Order(10)]
        public void SelectValidState()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            SelectElement stateElement = new SelectElement(AccountCreationPage.StateDropdown(driver));
            stateElement.SelectByValue("32");

            Assert.AreEqual(AccountCreationPage.StateDropdown(driver).GetAttribute("value"), "32");
        }

        [Test, Order(11)]
        public void EnterValidPostalCode()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            AccountCreationPage.PostalCodeField(driver).SendKeys(DataFile.postalCode);

            Assert.AreEqual(AccountCreationPage.PostalCodeField(driver).GetAttribute("value"), DataFile.postalCode);
        }

        [Test, Order(12)]
        public void EnterValidMobilePhoneNumber()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            AccountCreationPage.MobileNumberField(driver).SendKeys(DataFile.mobileNumber);

            Assert.AreEqual(AccountCreationPage.MobileNumberField(driver).GetAttribute("value"), DataFile.mobileNumber);
        }

        [Test, Order(13)]
        public void CreateAccount()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("account-creation_form")));

            AccountCreationPage.TitleRadioButton(driver).Click();
            AccountCreationPage.CustomerFirstNameField(driver).SendKeys(DataFile.firstName);
            AccountCreationPage.CustomerLastNameField(driver).SendKeys(DataFile.lastName);
            AccountCreationPage.PasswordField(driver).SendKeys(DataFile.password);
            AccountCreationPage.FirstAddressLineField(driver).SendKeys(DataFile.address);
            AccountCreationPage.CityField(driver).SendKeys(DataFile.city);
            SelectElement stateElement = new SelectElement(AccountCreationPage.StateDropdown(driver));
            stateElement.SelectByValue("32");
            AccountCreationPage.PostalCodeField(driver).SendKeys(DataFile.postalCode);
            AccountCreationPage.MobileNumberField(driver).SendKeys(DataFile.mobileNumber);

            AccountCreationPage.SubmitAccountButton(driver).Click();
        }

        [Test, Order(14)]
        public void ClickSignOutButton()
        {
            // go-to login page
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.EmailCreateField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.SubmitCreateAccountButton(driver).Click();

            // fill out register form
            var accountCreationFormWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            accountCreationFormWait.Until(ExpectedConditions.ElementIsVisible(By.Id("account-creation_form")));
            AccountCreationPage.TitleRadioButton(driver).Click();
            AccountCreationPage.CustomerFirstNameField(driver).SendKeys(DataFile.firstName);
            AccountCreationPage.CustomerLastNameField(driver).SendKeys(DataFile.lastName);
            AccountCreationPage.PasswordField(driver).SendKeys(DataFile.password);
            AccountCreationPage.FirstAddressLineField(driver).SendKeys(DataFile.address);
            AccountCreationPage.CityField(driver).SendKeys(DataFile.city);
            SelectElement stateElement = new SelectElement(AccountCreationPage.StateDropdown(driver));
            stateElement.SelectByValue("32");
            AccountCreationPage.PostalCodeField(driver).SendKeys(DataFile.postalCode);
            AccountCreationPage.MobileNumberField(driver).SendKeys(DataFile.mobileNumber);
            AccountCreationPage.SubmitAccountButton(driver).Click();

            // wait for logout button to be usable
            var logoutButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            logoutButtonWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("logout")));
            AccountPage.LogoutButton(driver).Click();

            // check for an element on the home page
            var homePageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            homePageWait.Until(ExpectedConditions.ElementIsVisible(By.Name("submitLogin")));

            Assert.NotNull(LoginPage.SubmitCreateAccountButton(driver));
        }

        [Test, Order(15)]
        public void EnterEmailIntoLoginField()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            LoginPage.EmailLoginField(driver).SendKeys(DataFile.emailAddress);

            Assert.AreEqual(LoginPage.EmailLoginField(driver).GetAttribute("value"), DataFile.emailAddress);
        }

        [Test, Order(16)]
        public void EnterPasswordIntoLoginField()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            LoginPage.PasswordLoginField(driver).SendKeys(DataFile.password);

            Assert.AreEqual(LoginPage.PasswordLoginField(driver).GetAttribute("value"), DataFile.password);
        }

        [Test, Order(17)]
        public void LoginToAccount()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            LoginPage.EmailLoginField(driver).SendKeys(DataFile.emailAddress);
            LoginPage.PasswordLoginField(driver).SendKeys(DataFile.password);
            LoginPage.SubmitLoginButton(driver).Click();

            var logoutButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            logoutButtonWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("logout")));
            Assert.NotNull(AccountPage.LogoutButton(driver));
        }
    }
}