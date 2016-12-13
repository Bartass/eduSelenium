using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Litecart
{
    [TestFixture]
    public class litecart12
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
        public void litecart12task()
        {
            //login
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.CssSelector(".input-wrapper [name='username']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".input-wrapper [name='password']")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".footer [name='login']")).Click();
            //Navigate           
            driver.Url = "http://localhost/litecart/admin/?category_id=0&app=catalog&doc=edit_product";
            //General
            driver.FindElement(By.CssSelector("input[type='radio'][value='1']")).Click(); //Enable
            driver.FindElement(By.CssSelector("input[name='name[en]']")).SendKeys("TestDuck");
            driver.FindElement(By.CssSelector("input[name='code']")).SendKeys("51436");
            driver.FindElement(By.CssSelector("input[data-name='Rubber Ducks']")).Click();
            driver.FindElement(By.CssSelector("input[name='product_groups[]'][value='1-3']")).Click(); //unisex
            driver.FindElement(By.CssSelector("input[name='quantity']")).Clear();
            driver.FindElement(By.CssSelector("input[name='quantity']")).SendKeys("99");
            driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(@"C:\1vs\FirstBlood\testduck.png");
            driver.FindElement(By.CssSelector("input[name='date_valid_from']")).SendKeys("13122016");
            driver.FindElement(By.CssSelector("input[name='date_valid_to']")).SendKeys("13122017");
            //Information
            driver.FindElement(By.CssSelector(".tabs .index li:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector("select[name='manufacturer_id']")).Click();
            driver.FindElement(By.CssSelector("select[name='manufacturer_id'] option[value='1']")).Click();
            driver.FindElement(By.CssSelector("input[name='keywords']")).SendKeys("duck test selenium");
            driver.FindElement(By.CssSelector("input[name='short_description[en]']")).SendKeys("testduck");
            driver.FindElement(By.CssSelector(".trumbowyg-editor")).Click();
            driver.FindElement(By.CssSelector(".trumbowyg-editor")).SendKeys("Full description testduck");
            driver.FindElement(By.CssSelector("input[name='head_title[en]']")).SendKeys("TestDuckHeader");
            driver.FindElement(By.CssSelector("input[name='meta_description[en]']")).SendKeys("TestDuckMeta");
            //Prices
            driver.FindElement(By.CssSelector(".tabs .index li:nth-child(4)")).Click();
            driver.FindElement(By.CssSelector("input[name='purchase_price']")).Clear();
            driver.FindElement(By.CssSelector("input[name='purchase_price']")).SendKeys("13");
            driver.FindElement(By.CssSelector("select[name='purchase_price_currency_code']")).Click();
            driver.FindElement(By.CssSelector("select[name='purchase_price_currency_code'] option[value='USD']")).Click();
            driver.FindElement(By.CssSelector("input[name='prices[USD]']")).SendKeys("15");
            driver.FindElement(By.CssSelector("input[name='prices[EUR]']")).SendKeys("14");
            //Save
            driver.FindElement(By.CssSelector(".button-set button[name='save']")).Click();
            //Test
            driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog";
            driver.FindElement(By.XPath("//*[contains(text(),'TestDuck')]")).Click();
        }

        //[TearDown]
        //public void stop()
        //{
        //    driver.Quit();
        //    driver = null;
        //}
    }
}