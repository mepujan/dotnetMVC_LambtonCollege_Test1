using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;
using Test.Services;

namespace Test.Tests
{
    [TestClass]
    public class ItemServiceTests
    {
        private const string XML_PROVIDER = "Microsoft.VisualStudio.TestTools.DataSource.XML";
        public TestContext TestContext { get; set; }
        //Inside XML\TestData.xml, for every CanBuyHouse node, create the appropriate child nodes to satisfy the expected results (one positive and one negative test)
        
        [DataSource(XML_PROVIDER, @"|DataDirectory|\XML\TestData.xml", "IsOnSale", DataAccessMethod.Sequential)]

        [TestMethod]
        public void IsOnSaleTest()
        {
            //Get the expected results and isOnSale from the XML
            bool onSale = Convert.ToBoolean(TestContext.DataRow["isOnSale"]);
            bool expected = Convert.ToBoolean(TestContext.DataRow["ExpectedResults"]);

            Item item = new Item { isOnSale = onSale, Name = "Test Item", Cost = 10 };
            ItemService itemService = new ItemService();

            var actual = itemService.IsOnSale(item);

            Assert.AreEqual(expected, actual);
        }
    }
}
