using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumProject.Objects;
using System;

namespace SeleniumProject
{
    public class TC2_RP1
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            DriverUtilities myDriverUtilities = new DriverUtilities();
            driver = myDriverUtilities.GetDriver();
            driver.Manage().Window.Maximize();
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
        public void ClickForgottenPasswordLink()
        {
            // home page
            driver.Navigate().GoToUrl(DataFile.loginURL);
            LoginPage.ForgottenPasswordLink(driver).Click();

            // forgotten url page
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("form_forgotpassword")));

            Assert.NotNull(ForgottenPasswordPage.RetrievePasswordButton(driver));
        }

        [Test, Order(2)]
        public void EnterValidEmailAddress()
        {
            ForgottenPasswordPage.EmailField(driver).SendKeys(DataFile.emailAddress);

            Assert.AreEqual(ForgottenPasswordPage.EmailField(driver).GetAttribute("value"), DataFile.emailAddress);
        }

        [Test, Order(3)]
        public void SubmitPasswordRetrieval()
        {
            ForgottenPasswordPage.RetrievePasswordButton(driver).Click();

            var alertWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            alertWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("alert-success")));

            Assert.NotNull(ForgottenPasswordPage.SuccessAlert(driver));
        }

        [Test, Order(4)]
        public void ReturnToLoginPage()
        {
            ForgottenPasswordPage.ReturnToLoginButton(driver).Click();

            var loginFormWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            loginFormWait.Until(ExpectedConditions.ElementIsVisible(By.Name("passwd")));

            Assert.NotNull(LoginPage.ForgottenPasswordLink(driver));
        }
    }
}