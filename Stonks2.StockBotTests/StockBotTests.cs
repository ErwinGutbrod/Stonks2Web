using CsvHelper.TypeConversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stonks2.StockBot;
using System;

namespace Stonks2.StockBotTests
{
    [TestClass]
    public class StockBotTests
    {
        [TestMethod]
        public void CheckStockReturnsFormattedMessage()
        {
            //Arrange
            IStockBot stockBot = new Stonks2.StockBot.StockBot();

            //Execute
            string result = stockBot.CheckStock("AAPL.US");

            //Assert
            Assert.AreEqual("AAPL.US quote is", result.Substring(0, 16));
        }

        [TestMethod]
        [ExpectedException(typeof(TypeConverterException))]
        public void CheckStockThrowExceptionOnBadCode()
        {
            //Arrange
            IStockBot stockBot = new Stonks2.StockBot.StockBot();

            //Execute & Assert
            string formattedMessage = stockBot.CheckStock("SOMETHING.FAIL");

            //Assert
            Assert.Fail("CheckStock method should fire exception.");
        }
    }
}
