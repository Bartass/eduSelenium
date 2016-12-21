using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Litecart
{
    public class Application
    {
        public IWebDriver driver;

        private Mainpage mainPage;
        private Productpage productpage;
        private Cartpage cartpage;

        public Application()
        {
            driver = new ChromeDriver("C:\\1vs\\FirstBlood");
            mainPage = new Mainpage(driver);
            productpage = new Productpage(driver);
            cartpage = new Cartpage(driver);
        }

        public void Quit()
        {
            driver.Quit();
        }

        public void NavigateToMain()
        {
            mainPage.Open();
        }

        public void NavigateToCart()
        {
            cartpage.Open();
        }

        public void AddProducts(myDuck[] ducks)
        {
            Productpage testPage = new Productpage(driver);
            foreach (myDuck duck in ducks)
            {
                testPage.Open(duck.name);
                testPage.AddToCart();
                testPage.CheckQuantity(duck.qnt);
                NavigateToMain();
            }
        }

        public void DeleteProducts(myDuck[] ducks)
        {
            Cartpage myCart = new Cartpage(driver);
            foreach (myDuck duck in ducks)
            {
                myCart.DeleteItem();
                myCart.WaitDeleteItem(duck.pos);
            }
            myCart.CheckCartEmpty();
        }



    }
}
