using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Litecart
{
    class Mainpage : Page
    {
        public Mainpage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        internal Mainpage Open()
        {
            driver.Url = "http://localhost/litecart/en/";
            return this;
        }

    }
}
