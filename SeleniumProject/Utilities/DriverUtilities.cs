using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Required to access app.config
using System.Configuration;
// Needed to work with webdriver
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;


namespace SeleniumProject.Objects
{
    public class DriverUtilities
    {
        private static DriverUtilities InstanceOfDriverUtilities;
        private IWebDriver driver;

        public static DriverUtilities GetInstanceOfDriverUtilities() {
            if (InstanceOfDriverUtilities == null) {
                InstanceOfDriverUtilities = new DriverUtilities();
            }

            return InstanceOfDriverUtilities;
        }

        public IWebDriver GetDriver() {
            if (driver == null) {
                CreateDriver();
            }

            return driver;
        }

        private string GetDriverName() {
            string driverName = ConfigurationManager.AppSettings["browser"];
            return driverName;
        }

        private void CreateDriver() {
            DriverUtilities myDriverUtilities = InstanceOfDriverUtilities;
            string driverName = GetDriverName();

            switch (driverName)
            {
                case "Google Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Internet Explorer":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    break;
            }
        }
    }
}
