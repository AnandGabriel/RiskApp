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
            IFileHandler fileHandler = new FileHandler(@"C:\temp\settled.csv", BetType.Settled);
            IBetAnalyzer betAnalyzer = new BetAnalyzer();
            RiskApp riskApp = new RiskApp(fileHandler, betAnalyzer);
            List<BetStatistics> betStatistics = riskApp.GetCustomersWithUnUsualRate();

            int expectedCount = 1;
            int actualCount = betStatistics.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}