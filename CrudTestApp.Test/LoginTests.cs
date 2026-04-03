using CrudTestApp.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginTests : BaseTest
{
    [Test]
    public void Login_Exitoso()
    {
        driver.Navigate().GoToUrl("http://localhost:5086/Account/Login");

        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(d => d.FindElement(By.Name("username"))).SendKeys("admin");
        driver.FindElement(By.Name("password")).SendKeys("1234");

        driver.FindElement(By.CssSelector("button[type='submit']")).Click();

        wait.Until(d => d.Url.Contains("Dashboard"));

        Screenshot("login_exitoso");

        Assert.That(driver.Url.Contains("Dashboard"), Is.True);
    }

    [Test]
    public void Login_Vacio()
    {
        driver.Navigate().GoToUrl("http://localhost:5086/Account/Login");

        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        // Click en botón submit correcto
        wait.Until(d => d.FindElement(By.CssSelector("button[type='submit']"))).Click();

        Screenshot("login_vacio");

        // ✅ Verifica que NO avanzó (sigue en login)
        Assert.That(driver.Url.Contains("Login"), Is.True);
    }

    [Test]
    public void Login_Incorrecto()
    {
        driver.Navigate().GoToUrl("http://localhost:5086/Account/Login");

        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(d => d.FindElement(By.Name("username"))).SendKeys("fake");
        driver.FindElement(By.Name("password")).SendKeys("1234");

        ((IJavaScriptExecutor)driver).ExecuteScript(
            "arguments[0].click();",
            driver.FindElement(By.CssSelector(".btn"))
        );

        Screenshot("login_incorrecto");

        Assert.That(driver.PageSource.Contains("Error")
                 || driver.PageSource.Contains("incorrecto"), Is.True);
    }
}

  

