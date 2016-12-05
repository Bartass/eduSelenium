using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Litecart
{
    [TestFixture]
    public class litecart11
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
        public void litecart11task()
        {
            //Navigate           
            driver.Url = "http://localhost/litecart/en/create_account";
            //Рандомим почту
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new string(stringChars);
            //Заполняем форму
            driver.FindElement(By.CssSelector("input[name='firstname']")).SendKeys("Иван");
            driver.FindElement(By.CssSelector("input[name='lastname']")).SendKeys("Иванов");
            driver.FindElement(By.CssSelector("input[name='address1']")).SendKeys("Адрес регистрации");
            driver.FindElement(By.CssSelector("input[name='address2']")).SendKeys("Адрес прописки");
            driver.FindElement(By.CssSelector("input[name='postcode']")).SendKeys("333333");
            driver.FindElement(By.CssSelector("input[name='city']")).SendKeys("Москва");
            driver.FindElement(By.CssSelector("input[name='email']")).SendKeys(finalString+"@test.test");
            driver.FindElement(By.CssSelector("input[name='phone']")).SendKeys("88002000800");
            driver.FindElement(By.CssSelector("input[name='password']")).SendKeys("f9n348n9348rv");
            driver.FindElement(By.CssSelector("input[name='confirmed_password']")).SendKeys("f9n348n9348rv");
            driver.FindElement(By.CssSelector("form[name='customer_form'] button[name='create_account']")).Click();
            //Logout
            driver.Url = "http://localhost/litecart/en/logout";
            //Login
            driver.FindElement(By.CssSelector("form[name='login_form'] input[name='email']")).SendKeys(finalString+"@test.test");
            driver.FindElement(By.CssSelector("form[name='login_form'] input[name='password']")).SendKeys("f9n348n9348rv");
            driver.FindElement(By.CssSelector("form[name='login_form'] button[name='login']")).Click();
        }

        //[TearDown]
        //public void stop()
        //{
        //    driver.Quit();
        //    driver = null;
        //}
    }
}