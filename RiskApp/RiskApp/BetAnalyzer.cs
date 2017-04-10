using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    class BetAnalyzer : IBetAnalyzer
    {
        private IEnumerable<Bet> Bets;

        public BetAnalyzer(List<Bet> bets)
        {
            Bets = bets;
        }

        public List<BetStatistics> AnalyzeBets()
        {
            //Get won bets count group by customer id
            var customersWonBets = Bets.GroupBy(x => x.CustomerID).Where(y => y.Any(o=>o.Win > 0)).Select(group => new { CustomerID = group.Key, WinCount = group.Count() });

            //Get total bets count group customer id
            var customersTotalBets = Bets.GroupBy(x => x.CustomerID).Select(group => new { CustomerID = group.Key, BetCount = group.Count() });

            //join the above two groups on customer id
            var customerStatistics = from customerWon in customersWonBets
                                     join customerTotal in customersTotalBets on customerWon.CustomerID equals customerTotal.CustomerID
                                     select new BetStatistics(customerTotal.CustomerID, customerWon.WinCount / customerTotal.BetCount * 100, 0);

            return customerStatistics.ToList();

        }
    }
}
