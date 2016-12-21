using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Litecart
{
    [TestFixture]
    public class TestCart : TestBase
    {
        [Test]
        public void CartTest()
        {
            app.NavigateToMain();
            myDuck[] testDucks = this.InitDataDucks();
            app.AddProducts(testDucks);
            app.NavigateToCart();
            app.DeleteProducts(testDucks);
        }

        public myDuck[] InitDataDucks()
        {
            myDuck[] ducks = new myDuck[3];
            ducks[0] = new myDuck("Green Duck", 1, 7);
            ducks[1] = new myDuck("Blue Duck", 2, 6);
            ducks[2] = new myDuck("Red Duck", 3, -1);
            return ducks;
        }
    }
}