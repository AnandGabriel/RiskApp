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
    public class RiskAppTests
    {
        [TestMethod()]
        public void GetCustomersWithUnUsualRateTest()
        {
            IFileHandler fileHandlerSettled = new FileHandler(@"C:\temp\settled.csv", BetType.Settled);
            IFileHandler fileHandlerUnSettled = new FileHandler(@"C:\temp\unsettled.csv", BetType.UnSettled);
            IBetAnalyzer betAnalyzer = new BetAnalyzer();
            RiskApp riskApp = new RiskApp(fileHandlerSettled, fileHandlerUnSettled, betAnalyzer);
            List<BetStatistics> betStatistics = riskApp.GetCustomersWithUnUsualRate();

            int expectedCount = 1;
            int actualCount = betStatistics.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod()]
        public void GetRiskyBetsFromUnUsualRateCustomers()
        {
            IFileHandler fileHandlerSettled = new FileHandler(@"C:\temp\settled.csv", BetType.Settled);
            IFileHandler fileHandlerUnSettled = new FileHandler(@"C:\temp\unsettled.csv", BetType.UnSettled);
            IBetAnalyzer betAnalyzer = new BetAnalyzer();
            RiskApp riskApp = new RiskApp(fileHandlerSettled, fileHandlerUnSettled, betAnalyzer);
            List<Bet> bets = riskApp.GetBetsFromRiskyCustomers();

            int expectedCount = 4;
            int actualCount = bets.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}