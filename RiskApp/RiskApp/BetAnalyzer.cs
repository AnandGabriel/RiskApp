using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    public class BetAnalyzer : IBetAnalyzer
    {
        public BetAnalyzer()
        {
            
        }

        public List<BetStatistics> AnalyzeBets(List<Bet> Bets)
        {
            //Get won bets count group by customer id
            var customersWonBets = Bets.Where(o => o.Win > 0).GroupBy(x => x.CustomerID).Select(group => new { CustomerID = group.Key, WinCount = group.Count() });

            //Get total bets count group customer id
            var customersTotalBets = Bets.GroupBy(x => x.CustomerID).Select(group => new { CustomerID = group.Key, BetCount = group.Count(), AverageStake = group.Average(x => x.Stake)});

            //join the above two groups on customer id
            var customerStatistics = from customerWon in customersWonBets
                                     join customerTotal in customersTotalBets on customerWon.CustomerID equals customerTotal.CustomerID
                                     select new BetStatistics(customerTotal.CustomerID, (decimal)customerWon.WinCount / (decimal)customerTotal.BetCount * 100, customerTotal.AverageStake);

            return customerStatistics.ToList();

        }
    }
}
