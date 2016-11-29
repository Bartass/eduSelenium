using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;


namespace Litecart
{
    [TestFixture]
    public class litecart9_1
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
        public void litecart9_1task()
        {
            //login
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.CssSelector(".input-wrapper [name='username']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".input-wrapper [name='password']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".footer [name='login']")).Click();
            //Navigate
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

            //SortCountries
            int count = driver.FindElements(By.CssSelector("form .row")).Count;
            bool issort = true;
            for (int i = 3; i <= count + 1; i++)
            {
                var country = ".row:nth-child(" + (i-1).ToString() + ") a";
                string Predname = driver.FindElement(By.CssSelector(country)).Text;
                country = ".row:nth-child(" + i.ToString() + ") a";
                string Postname = driver.FindElement(By.CssSelector(country)).Text;
                if (string.Compare(Predname,Postname,true) >= 0)
                { issort = false; break; } 
            }

            //SortZones
            List<int> links = new List<int>();
            List<int> states = new List<int>();
            int count2 = driver.FindElements(By.CssSelector("form .row")).Count;            
            for (int i = 2; i <= count2 +1; i++)
            {
                var country2 = ".row:nth-child(" + i.ToString() + ") td:nth-child(6)";
                string havezone = driver.FindElement(By.CssSelector(country2)).Text;
                int k = Convert.ToInt32(havezone);
                if (havezone != "0")
                { links.Add(i); states.Add(k); }
            }
            for (int k = 0; k <= states.Count-1; k++)
            {
                driver.FindElement(By.CssSelector(".row:nth-child(" + links[k].ToString() + ") a")).Click();
                for (int j = 1; j < states[k]; j++)
                {
                    var zone = "table#table-zones tr:nth-child(" + (j+1).ToString() + ") td:nth-child(3)";
                    string Predzone = driver.FindElement(By.CssSelector(zone)).Text;
                    zone = "table#table-zones tr:nth-child(" + (j+2).ToString() + ") td:nth-child(3)";
                    string Postzone = driver.FindElement(By.CssSelector(zone)).Text;
                    if (string.Compare(Predzone, Postzone, true) >= 0)
                    { issort = false; break; }                 
                }
                driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
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
