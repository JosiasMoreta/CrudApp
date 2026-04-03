using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace CrudTestApp.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--ignore-certificate-errors");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        // 📸 SCREENSHOT
        protected void Screenshot(string name)
        {
            string path = @"C:\Screenshots";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var shot = ((ITakesScreenshot)driver).GetScreenshot();
            shot.SaveAsFile($"{path}\\{name}.png");
        }

        // 🔐 LOGIN AUTOMÁTICO
        protected void Login()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl("http://localhost:5086/Account/Login");

            wait.Until(d => d.FindElement(By.Name("username"))).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("1234");

            var btn = wait.Until(d => d.FindElement(By.CssSelector("button[type='submit']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", btn);

            // 🔥 Esperar que cargue el dashboard
            wait.Until(d => d.Url.Contains("Dashboard"));
        }
    }
}