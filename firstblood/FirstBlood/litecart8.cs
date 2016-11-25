using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.IO;


namespace Litecart
{
    [TestFixture]
    public class litecart8
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
        public void litecart8task()
        {            
            //Navigate
            driver.Url = "http://localhost/litecart/en/";
            //CheckStickers
            int count1 = driver.FindElements(By.CssSelector("#box-most-popular li")).Count;
            int count2 = driver.FindElements(By.CssSelector("#box-campaigns li")).Count;
            int count3 = driver.FindElements(By.CssSelector("#box-latest-products li")).Count;

            for (int i = 1; i <= count1; i++)
            {
                var duck = "#box-most-popular li:nth-child(" + i.ToString() + ") .sticker";
                int stick = driver.FindElements(By.CssSelector(duck)).Count;
                Assert.AreEqual(1, stick, "Стикера нет или их несколько :)");           
            }
            for (int j = 1; j <= count2; j++)
            {
                var duck = "#box-campaigns li:nth-child(" + j.ToString() + ") .sticker";
                int stick = driver.FindElements(By.CssSelector(duck)).Count;
                Assert.AreEqual(1, stick, "Стикера нет или их несколько :)");
            }
            for (int k = 1; k <= count3; k++)
            {
                var duck = "#box-latest-products li:nth-child(" + k.ToString() + ") .sticker";
                int stick = driver.FindElements(By.CssSelector(duck)).Count;
                Assert.AreEqual(1, stick, "Стикера нет или их несколько :)");
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
