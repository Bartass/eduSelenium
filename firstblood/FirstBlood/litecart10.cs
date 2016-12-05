using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Litecart
{
    [TestFixture]
    public class litecart10
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
        public void litecart10task()
        {
            //Navigate
            driver.Url = "http://localhost/litecart/en/";
            //С главной страницы получаем название товара
            var name1 = driver.FindElement(By.CssSelector("#box-campaigns li:nth-child(1) .name")).GetAttribute("textContent");
            //цену старую и новую
            string sel1 = "#box-campaigns li:nth-child(1) .regular-price";
            string sel2 = "#box-campaigns li:nth-child(1) .campaign-price";
            var regprice1 = driver.FindElement(By.CssSelector(sel1)).GetAttribute("textContent");
            var campprice1 = driver.FindElement(By.CssSelector(sel2)).GetAttribute("textContent");
            //Проверяем стили цены первая цена серая, зачёркнутая, маленькая, вторая цена красная жирная, крупная.
            var regpricecol1 = driver.FindElement(By.CssSelector(sel1)).GetCssValue("color");
            var regpricedec1 = driver.FindElement(By.CssSelector(sel1)).GetCssValue("text-decoration");
            var regpricefont1 = driver.FindElement(By.CssSelector(sel1)).GetCssValue("font-weight");
            var regpricefontsize1 = driver.FindElement(By.CssSelector(sel1)).GetCssValue("font-size");
            Assert.AreEqual(regpricecol1, "rgba(119, 119, 119, 1)", "цвет неправильный");
            Assert.AreEqual(regpricedec1, "line-through", "декоратор неправильный");
            Assert.AreEqual(regpricefont1, "normal", "шрифт неправильный стиль");
            Assert.AreEqual(regpricefontsize1, "14.4px", "шрифт неправильный размер");
            var camppricecol1 = driver.FindElement(By.CssSelector(sel2)).GetCssValue("color");
            var camppricefont1 = driver.FindElement(By.CssSelector(sel2)).GetCssValue("font-weight");
            var camppricefontsize1 = driver.FindElement(By.CssSelector(sel2)).GetCssValue("font-size");
            Assert.AreEqual(camppricecol1, "rgba(204, 0, 0, 1)", "цвет неправильный");
            Assert.AreEqual(camppricefont1, "bold", "шрифт неправильный стиль");
            Assert.AreEqual(camppricefontsize1, "18px", "шрифт неправильный размер");
            //Open first in Campaigns
            driver.FindElement(By.CssSelector("#box-campaigns li:nth-child(1)")).Click();
            //Со страницы товара получаем название товара
            var name2 = driver.FindElement(By.CssSelector("#box-product .title")).GetAttribute("textContent");
            //цену старую и новую
            string sel3 = "#box-product .information .regular-price";
            string sel4 = "#box-product .information .campaign-price";
            var regprice2 = driver.FindElement(By.CssSelector(sel3)).GetAttribute("textContent");
            var campprice2 = driver.FindElement(By.CssSelector(sel4)).GetAttribute("textContent");
            //Проверяем стили цены первая цена серая, зачёркнутая, маленькая, вторая цена красная жирная, крупная.
            var regpricecol2 = driver.FindElement(By.CssSelector(sel3)).GetCssValue("color");
            var regpricedec2 = driver.FindElement(By.CssSelector(sel3)).GetCssValue("text-decoration");
            var regpricefont2 = driver.FindElement(By.CssSelector(sel3)).GetCssValue("font-weight");
            var regpricefontsize2 = driver.FindElement(By.CssSelector(sel3)).GetCssValue("font-size");
            Assert.AreEqual(regpricecol2, "rgba(102, 102, 102, 1)", "цвет неправильный");
            Assert.AreEqual(regpricedec2, "line-through", "декоратор неправильный");
            Assert.AreEqual(regpricefont2, "normal", "шрифт неправильный стиль");
            Assert.AreEqual(regpricefontsize2, "16px", "шрифт неправильный размер");
            var camppricecol2 = driver.FindElement(By.CssSelector(sel4)).GetCssValue("color");
            var camppricefont2 = driver.FindElement(By.CssSelector(sel4)).GetCssValue("font-weight");
            var camppricefontsize2 = driver.FindElement(By.CssSelector(sel4)).GetCssValue("font-size");
            Assert.AreEqual(camppricecol2, "rgba(204, 0, 0, 1)", "цвет неправильный");
            Assert.AreEqual(camppricefont2, "bold", "шрифт неправильный стиль");
            Assert.AreEqual(camppricefontsize2, "22px", "шрифт неправильный размер");
            //Сравниваем имена, старые цены, новые цены
            Assert.AreEqual(name1, name2, "Имена не совпадают");
            Assert.AreEqual(regprice1, regprice2, "Цены не совпадают");
            Assert.AreEqual(campprice1, campprice2, "Цены не совпадают");
        }

        //[TearDown]
        //public void stop()
        //{
        //    driver.Quit();
        //    driver = null;
        //}
    }
}