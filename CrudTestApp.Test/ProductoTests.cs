using CrudTestApp.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

[TestFixture]
public class ProductTests : BaseTest
{
    [Test]
    public void Crear_Producto()
    {
        driver.Navigate().GoToUrl("http://localhost:5086/Producto/Create");

        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        string nombre = "Prod_" + DateTime.Now.Ticks;

        wait.Until(d => d.FindElement(By.Name("Nombre"))).SendKeys(nombre);
        driver.FindElement(By.Name("Precio")).SendKeys("1000");

        driver.FindElement(By.CssSelector("input[type='submit']")).Click();

      
        wait.Until(d => d.Url.Contains("Index"));

        Thread.Sleep(1000);

        Screenshot("crear_producto");

        
        Assert.That(driver.PageSource.Contains(nombre), Is.True);
    }

    [Test]
    public void Crear_Producto_Vacio()
    {
        driver.Navigate().GoToUrl("http://localhost:5086/Producto/Create");

        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        wait.Until(d => d.FindElement(By.CssSelector("input[type='submit']"))).Click();

        Thread.Sleep(1000); 

        Screenshot("producto_vacio");

       
        Assert.That(driver.Url.Contains("Create"), Is.True);
    }
}