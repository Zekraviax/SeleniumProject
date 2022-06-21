using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumProject.Objects;
using System;

namespace SeleniumProject
{
    public class TestCases2_ForgottenPassword
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            DriverUtilities myDriverUtilities = new DriverUtilities();
            driver = myDriverUtilities.GetDriver();
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [Test] // 1
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

        [Test] // 2
        public void EnterValidEmailAddress()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            LoginPage.ForgottenPasswordLink(driver).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("form_forgotpassword")));

            ForgottenPasswordPage.EmailField(driver).SendKeys(DataFile.emailAddress);
            Assert.AreEqual(ForgottenPasswordPage.EmailField(driver).GetAttribute("value"), DataFile.emailAddress);
        }

        [Test] // 3
        public void SubmitPasswordRetrieval()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            LoginPage.ForgottenPasswordLink(driver).Click();

            var formWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            formWait.Until(ExpectedConditions.ElementIsVisible(By.Id("form_forgotpassword")));

            ForgottenPasswordPage.EmailField(driver).SendKeys(DataFile.emailAddress);
            ForgottenPasswordPage.RetrievePasswordButton(driver).Click();

            // check for confirmation prompt
            var alertWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            alertWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("alert-success")));
            Assert.NotNull(ForgottenPasswordPage.SuccessAlert(driver));
        }

        [Test] // 4
        public void ReturnToLoginPage()
        {
            driver.Navigate().GoToUrl(DataFile.loginURL);
            LoginPage.ForgottenPasswordLink(driver).Click();

            var formWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            formWait.Until(ExpectedConditions.ElementIsVisible(By.Id("form_forgotpassword")));

            ForgottenPasswordPage.EmailField(driver).SendKeys(DataFile.emailAddress);
            ForgottenPasswordPage.RetrievePasswordButton(driver).Click();

            // check for confirmation prompt
            var alertWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            alertWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("alert-success")));

            // return
            ForgottenPasswordPage.ReturnToLoginButton(driver).Click();

            var loginFormWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            loginFormWait.Until(ExpectedConditions.ElementIsVisible(By.Name("passwd")));

            Assert.NotNull(LoginPage.ForgottenPasswordLink(driver));
        }
    }
}