using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace Litecart
{
    [TestFixture]
    public class litecart14
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
        public void litecart14task()
        {
            //login
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.CssSelector(".input-wrapper [name='username']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".input-wrapper [name='password']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".footer [name='login']")).Click();
            //Navigate           
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.LinkText("Russian Federation")).Click();
            string mainWindow = driver.CurrentWindowHandle;
            ICollection<string> oldWindows = driver.WindowHandles;
            string[] links = {
                "#content table tr:nth-child(2) a",
                "#content table tr:nth-child(3) a",
                "#content table tr:nth-child(6) a",
                "#content table tr:nth-child(7) a:nth-child(3)",
                "#content table tr:nth-child(8) a",
                "#content table tr:nth-child(9) a",
                "#content table tr:nth-child(10) a",
            };
            foreach (string i in links)
            {
                driver.FindElement(By.CssSelector(i)).Click();
                NewWind(oldWindows);
                driver.SwitchTo().Window(mainWindow);
            }
        }

        private void NewWind(ICollection<string> oldWindows)
        {
            while (driver.WindowHandles.Count == oldWindows.Count)
            {
                Thread.Sleep(100);
            }
            string newWindow = string.Empty;
            foreach (string str in driver.WindowHandles)
            {
                if (!oldWindows.Contains(str))
                {
                    newWindow = str;
                    break;
                }
            }
            driver.SwitchTo().Window(newWindow);

            string strSorc = string.Empty;
            while (strSorc != driver.SwitchTo().Window(newWindow).PageSource)
            {
                strSorc = driver.SwitchTo().Window(newWindow).PageSource;
                Thread.Sleep(100);
            }

            driver.Close();
        }

        //[TearDown]
        //public void stop()
        //{
        //    driver.Quit();
        //    driver = null;
        //}
    }
}