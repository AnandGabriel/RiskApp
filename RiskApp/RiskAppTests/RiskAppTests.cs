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
        IFileHandler _fileHandlerSettled;
        IFileHandler _fileHandlerUnSettled;
        IBetAnalyzer _betAnalyzer;
        RiskApp _riskApp;

        [TestInitialize]
        public void InitializeTestData()
        {
            _fileHandlerSettled = new FileHandler(@"C:\temp\settled.csv", BetType.Settled);
            _fileHandlerUnSettled = new FileHandler(@"C:\temp\unsettled.csv", BetType.UnSettled);
            _betAnalyzer = new BetAnalyzer();

            _riskApp = new RiskApp(_fileHandlerSettled, _fileHandlerUnSettled, _betAnalyzer);
        }

        [TestMethod()]
        public void GetCustomersWithUnUsualRateTest()
        {
            List<BetStatistics> betStatistics = _riskApp.GetCustomersWithUnUsualRate();

            int expectedCount = 1;
            int actualCount = betStatistics.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod()]
        public void GetRiskyBetsByTenTimesMoreThanAverageTest()
        {
            List<Bet> bets = _riskApp.GetRiskyBetsByTenTimesMoreThanAverage();

            int expectedCount = 3;
            int actualCount = bets.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod()]
        public void GetRiskyBetsByThirtyTimesMoreThanAverageTest()
        {
            List<Bet> bets = _riskApp.GetRiskyBetsByThirtyTimesMoreThanAverage();

            int expectedCount = 0;
            int actualCount = bets.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod()]
        public void GetRiskyBetsByHigherWinAmountTest()
        {
            List<Bet> bets = _riskApp.GetRiskyBetsByHigherWinAmount();

            int expectedCount = 6;
            int actualCount = bets.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod()]
        public void GetTotalRiskyBetsTest()
        {
            List<Bet> bets = _riskApp.GetTotalRiskyBets();

            int expectedCount = 13;
            int actualCount = bets.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}