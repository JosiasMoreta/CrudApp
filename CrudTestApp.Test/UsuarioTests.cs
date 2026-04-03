using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CrudTestApp.Tests
{
    [TestFixture]
    public class UsuarioTests : BaseTest
    {
        private string baseUrl = "http://localhost:5086/Usuarios/Create";

        [Test]
        public void Crear_Usuario_Exitoso()
        {
            Login();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl(baseUrl);

            string username = "user_" + DateTime.Now.Ticks;

            wait.Until(d => d.FindElement(By.Name("Username"))).SendKeys(username);
            driver.FindElement(By.Name("Password")).SendKeys("1234");

            var button = wait.Until(d => d.FindElement(By.CssSelector("button[type='submit']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", button);

            // 🔥 esperar redirección a Index
            wait.Until(d => d.Url.Contains("Usuarios"));

            // 🔥 esperar que aparezca el usuario
            wait.Until(d => d.PageSource.Contains(username));

            Screenshot("usuario_exitoso");

            Assert.That(driver.PageSource.Contains(username), Is.True);
        }

        [Test]
        public void Crear_Usuario_Vacio()
        {
            Login();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl(baseUrl);

            var button = wait.Until(d => d.FindElement(By.CssSelector("button[type='submit']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", button);

            Screenshot("usuario_vacio");

            // 🔥 debe quedarse en Create
            Assert.That(driver.Url.Contains("Create"), Is.True);
        }

        [Test]
        public void Crear_Usuario_Incorrecto()
        {
            Login();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl(baseUrl);

            wait.Until(d => d.FindElement(By.Name("Username"))).SendKeys("");
            driver.FindElement(By.Name("Password")).SendKeys("1234");

            var button = wait.Until(d => d.FindElement(By.CssSelector("button[type='submit']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", button);

            Screenshot("usuario_incorrecto");

            // 🔥 sigue en Create
            Assert.That(driver.Url.Contains("Create"), Is.True);
        }
    }
}