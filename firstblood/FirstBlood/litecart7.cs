using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;


namespace Litecart
{
    [TestFixture]
    public class litecart7
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver("C:\\1vs\\FirstBlood");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void litecart7task()
        {
            //login
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.CssSelector(".input-wrapper [name='username']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".input-wrapper [name='password']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".footer [name='login']")).Click();
            //menu
            int count = driver.FindElements(By.CssSelector("#box-apps-menu li#app-")).Count;
            for (int i = 1; i <= count; i++)
            {
                var level1 = "#box-apps-menu li:nth-child("+ i.ToString() +")";
                driver.FindElement(By.CssSelector(level1)).Click();
                for (int j = 1; ; j++)
                {
                    var level2 = level1 + " li:nth-child("+ j.ToString() +")";
                    try
                    {
                        driver.FindElement(By.CssSelector(level2)).Click();
                    }
                    catch(NoSuchElementException) {
                        break; }
                    driver.FindElement(By.CssSelector("#content > h1"));
                }
            }
        }


        //[TearDown]
        //public void stop()
        //{
        //    driver.Quit();
        //    driver = null;
        //}
    }
}
