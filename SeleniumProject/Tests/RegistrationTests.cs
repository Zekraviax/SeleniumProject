using NUnit.Framework;
using OpenQA.Selenium;
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
    }
}
