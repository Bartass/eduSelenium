using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Litecart
{
    class Cartpage : Page
    {
        public Cartpage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        internal Cartpage Open()
        {
            driver.Url = "http://localhost/litecart/en/checkout";
            return this;
        }

        internal Cartpage DeleteItem()
        {
            driver.FindElement(By.CssSelector("#box-checkout-cart button[name='remove_cart_item']")).Click();
            return this;
        }

        internal Cartpage WaitDeleteItem(int pos)
        {
            if (pos>0)
            wait.Until((IWebDriver d) => d.FindElements(By.CssSelector("table .dataTable tr")).Count == pos);
            return this;
        }

        internal Cartpage CheckCartEmpty()
        {
            wait.Until(d => d.FindElement(By.CssSelector("#checkout-cart-wrapper")).Text.Contains("There are no items in your cart."));
            Console.WriteLine("woohoo");
            return this;
        }

    }
}
