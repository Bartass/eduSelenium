using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Litecart
{
    [TestFixture]
    public class litecart13
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
        public void litecart13task()
        {
            //Navigate           
            driver.Url = "http://localhost/litecart/en/";
            driver.FindElement(By.CssSelector("#box-most-popular a[title='Green Duck']")).Click();
            driver.FindElement(By.CssSelector(".information button[name='add_cart_product']")).Click();
            //Cartwait
            wait.Until(d => d.FindElement(By.CssSelector("#cart .quantity")).Text.Contains("1"));
            //Comeback
            driver.Url = "http://localhost/litecart/en/";
            driver.FindElement(By.CssSelector("#box-most-popular a[title='Blue Duck']")).Click();
            driver.FindElement(By.CssSelector(".information button[name='add_cart_product']")).Click();
            //Cartwait
            wait.Until(d => d.FindElement(By.CssSelector("#cart .quantity")).Text.Contains("2"));
            //Comeback
            driver.Url = "http://localhost/litecart/en/";
            driver.FindElement(By.CssSelector("#box-most-popular a[title='Red Duck']")).Click();
            driver.FindElement(By.CssSelector(".information button[name='add_cart_product']")).Click();
            //Cartwait
            wait.Until(d => d.FindElement(By.CssSelector("#cart .quantity")).Text.Contains("3"));
            //To cart
            driver.Url = "http://localhost/litecart/en/checkout";
            driver.FindElement(By.CssSelector("#box-checkout-cart button[name='remove_cart_item']")).Click();
            wait.Until((IWebDriver d) => d.FindElements(By.CssSelector("table .dataTable tr")).Count == 7);
            driver.FindElement(By.CssSelector("#box-checkout-cart button[name='remove_cart_item']")).Click();
            wait.Until((IWebDriver d) => d.FindElements(By.CssSelector("table .dataTable tr")).Count == 6);
            driver.FindElement(By.CssSelector("#box-checkout-cart button[name='remove_cart_item']")).Click();
            //wait.Until(d => d.FindElement(By.CssSelector("#checkout-cart-wrapper")).Text.Contains("There are no items in your cart."));
            //Console.WriteLine("woohoo");
        }

        //[TearDown]
        //public void stop()
        //{
        //    driver.Quit();
        //    driver = null;
        //}
    }
}