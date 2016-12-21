using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Litecart
{
    class Productpage : Page
    {
        public Productpage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        internal Productpage Open(string duck)
        {
            driver.FindElement(By.CssSelector(string.Format("#box-most-popular a[title='{0}']", duck))).Click();
            return this;
        }

        internal Productpage AddToCart()
        {
            driver.FindElement(By.CssSelector(".information button[name='add_cart_product']")).Click();
            return this;
        }

        internal Productpage CheckQuantity(int qnt)
        {
            wait.Until(d => d.FindElement(By.CssSelector("#cart .quantity")).Text.Contains(qnt.ToString()));
            return this;
        }

    }
}
