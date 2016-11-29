using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Litecart
{
    [TestFixture]
    public class litecart9_2
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
        public void litecart9_2task()
        {
            //login
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.CssSelector(".input-wrapper [name='username']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".input-wrapper [name='password']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".footer [name='login']")).Click();
            //Navigate
            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
            //SortGeoZones
            int countcount = driver.FindElements(By.CssSelector("form .row")).Count;
            bool issort = true;
            for (int i = 2; i <= countcount + 1; i++)
            {
                var geo = ".row:nth-child(" + i.ToString() + ") a";
                driver.FindElement(By.CssSelector(geo)).Click();
                int countzone = driver.FindElements(By.CssSelector("table#table-zones tr")).Count;
                for (int j = 2; j < countzone - 1; j++)
                {
                    var zone = ".dataTable tr:nth-child(" + j.ToString() + ") td:nth-child(3) select";
                    string predNameValue = driver.FindElement(By.CssSelector(zone)).GetAttribute("value");
                    string Predname = driver.FindElement(By.CssSelector(zone + " option[value='" + predNameValue + "']")).Text;

                    zone = ".dataTable tr:nth-child(" + (j+1).ToString() + ") td:nth-child(3) select";
                    string PostNameValue = driver.FindElement(By.CssSelector(zone)).GetAttribute("value");
                    string Postname = driver.FindElement(By.CssSelector(zone + " option[value='" + PostNameValue + "']")).Text;
                    if (string.Compare(Predname, Postname, true) >= 0)
                    { issort = false; break; }
                }
                driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
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
