using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace first
{
    [TestFixture]
    public class Task3
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Login()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.CssSelector(".input-wrapper [name='username']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".input-wrapper [name='password']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".footer [name='login']")).Click();
        }

        //[TearDown]
        //public void stop()
        //{
        //    driver.Quit();
        //    driver = null;
        //}
    }
}