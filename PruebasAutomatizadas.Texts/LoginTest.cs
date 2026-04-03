using NUnit.Framework;
using OpenQA.Selenium;

[TestFixture]
public class LoginTests : BaseTest
{
    [Test]
    public void Login_Exitoso()
    {
        driver.Navigate().GoToUrl("http://localhost:5086/Account/Login");

        driver.FindElement(By.Name("username")).SendKeys("admin");
        driver.FindElement(By.Name("password")).SendKeys("1234");
        driver.FindElement(By.TagName("button")).Click();

        Thread.Sleep(2000); // 

        Assert.IsTrue(driver.Url.Contains("Dashboard"));
    }
}