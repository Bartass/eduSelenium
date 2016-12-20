using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Support.Events;
using System.Linq;

namespace Litecart
{
    [TestFixture]
    public class litecart17
    {
        private EventFiringWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new EventFiringWebDriver(new ChromeDriver("C:\\1vs\\FirstBlood"));
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //[Test]
        //public void testlogtask()
        //{
        //    driver.Url = "http://selenium2.ru";
        //    var logs = driver.Manage().Logs.GetLog("browser").ToArray();
        //    foreach (var log in logs)
        //    {
        //        Console.WriteLine(log.Message);
        //    }
        //    Assert.IsEmpty(logs);
        //}

        [Test]
        public void litecart17task()
        {
            //login
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.CssSelector(".input-wrapper [name='username']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".input-wrapper [name='password']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".footer [name='login']")).Click();
            //Navigate
            driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";

            int count = driver.FindElements(By.CssSelector(".dataTable .row img + a")).Count;
            for (int i = 1; i <= count; i++)
            {
                driver.FindElement(By.CssSelector(".dataTable .row:nth-child(" + (i + 4) + ") a")).Click();
                var logs = driver.Manage().Logs.GetLog("browser").ToArray();
                foreach (var log in logs)
                {
                    Console.WriteLine(log.Message);
                }
                Assert.IsEmpty(logs);               
                //Thread.Sleep(300);
                driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";
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