using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiskApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp.Tests
{
    [TestClass()]
    public class FileHandlerTests
    {

        [TestMethod()]
        public void GetBetsTest()
        {
            FileHandler fileHandler = new FileHandler(@"C:\temp\settled.csv", BetType.Settled);
            List<Bet> bets = fileHandler.GetBets();

            int expectedBetsCount = 50;
            int actualBetsCount = bets.Count;
            Assert.AreEqual(expectedBetsCount, actualBetsCount);
        }
    }
}